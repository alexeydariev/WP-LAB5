using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    public partial class MainForm : Form
    {
        public enum WhatToDo
        {
            SimpleCrossing,
            ComplexCrossing,
            RemoveCrossing,
            AddEditCarStream,
            AddEditCarStreamEnd,
            RemoveCarStream,
            AddEditPedestrianStreamStart,
            AddEditPedestrianStreamEnd,
            RemovePedestrianStream,
            None
        };

        public static WhatToDo mouseMode;
        Controller cl;
        int y = 2; //index of FIRST grid after the initial. Used for numbering the unnamed tabs(grids)
        Stopwatch st;
        ToolStripButton tabButton1;
        int timertick = 1;
        public static List<Point> PossibleEndPoints;
        public static Point SelectedEndPoint;
        public static Point SelectedStartPoint;
        FormCarStream formNewStream;
        public static bool RemoveCarStreamToggle;
        public static bool EditCarStreamToggle;
        private Point selectedPedestrianEndPoint;
        private Point selectedPedestrianStartPoint;

        public MainForm()
        {
            this.InitializeComponent();
            PossibleEndPoints = new List<Point>();
            SelectedEndPoint = new Point(0, 0);
            this.selectedPedestrianStartPoint = new Point(0, 0);
            EditCarStreamToggle = false;
            this.toolStrip1.AllowItemReorder = true;
            //SET FORM STYLES FOR AVOIDING FLICKERING ISSUES
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.st = new Stopwatch();
            mouseMode = WhatToDo.None;
            //EVENTS
            this.MouseDown += this.GridMouseDown_Down;
            this.DoubleBuffered = true;
            this.UpdateStyles();

            //INITIALIZE OF FIRST GRID
            this.tabButton1 = new ToolStripButton();
            this.tabButton1.Text = "Unnamed Grid1";
            this.tabButton1.Name = this.tabButton1.Text;
            this.tabButton1.Font = new Font("Roboto", 10);
            this.tabButton1.ForeColor = Color.Blue;
            this.tabButton1.Click += this.CommonChangeTab_Click;
            this.tabButton1.MouseDown += this.CommonCloseTab_Click;
            this.toolStrip1.Items.Add(this.tabButton1);
            
            #region DESIGN 
            
            //DESIGN
            this.Location = new Point(0, 0);
            this.gpTools.ForeColor = Color.FromArgb(77, 188, 233);
            this.gpGrid.ForeColor = Color.FromArgb(77, 188, 233);
            this.label1.ForeColor = Color.FromArgb(77, 188, 233);
            this.label2.ForeColor = Color.FromArgb(77, 188, 233);
            this.btnAddSimple.BackColor = Color.FromArgb(95, 90, 92);
            this.btnAddComplex.BackColor = Color.FromArgb(95, 90, 92);
            this.btnRemoveCrossing.BackColor = Color.FromArgb(95, 90, 92);
            this.btnAddEditStream.BackColor = Color.FromArgb(95, 90, 92);
            this.btnRemoveCarStream.BackColor = Color.FromArgb(95, 90, 92);
            this.btnRemoveAllCarStreams.BackColor = Color.FromArgb(95, 90, 92);
            this.btnAddEditPedestrian.BackColor = Color.FromArgb(95, 90, 92);
            this.btnRemovePedestrian.BackColor = Color.FromArgb(95, 90, 92);
            this.btnRemoveAllPedestrians.BackColor = Color.FromArgb(95, 90, 92);
            this.btnClearGrid.BackColor = Color.FromArgb(162, 18, 47);
            this.btnClearGrid.ForeColor = Color.FromArgb(77, 188, 233);

            #endregion
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {
            this.cl = new Controller(this.tabButton1.Name);
        }
        
        #region Toolbox Button Click Events
            
        private void btnStopSimulation_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer2.Stop();
            this.st.Stop();
            this.st.Reset();
            this.btnStopSimulation.Hide();
            this.btnStartSimulation.Show();
            foreach (GroupBox gp in this.gpTools.Controls.OfType<GroupBox>())
            {
                foreach (Button btn in gp.Controls.OfType<Button>())
                {
                    btn.Enabled = true;
                }
            }
        }
            
        private void btnStartSimulation_Click(object sender, EventArgs e)
        {
            EditCarStreamToggle = false;
            if (this.cl.ActiveGrid.ListOfCarStreams.Count > 0)
            {
                this.cl.ActiveGrid.ListOfCarStreams[0].DriveAllCars();
                this.st.Start();
                this.timer2.Start();
                this.timer1.Start();
                this.btnStartSimulation.Hide();
                this.btnStopSimulation.Show();
                foreach (GroupBox gp in this.gpTools.Controls.OfType<GroupBox>())
                {
                    foreach (Button btn in gp.Controls.OfType<Button>())
                    {
                        btn.Enabled = true;
                    }
                }
            }
        }
            
        private void btnAddSimple_Click(object sender, EventArgs e)
        {
            mouseMode = WhatToDo.SimpleCrossing;
        }
            
        private void btnAddComplex_Click(object sender, EventArgs e)
        {
            mouseMode = WhatToDo.ComplexCrossing;
        }
            
        private void btnClearGrid_Click(object sender, EventArgs e)
        {
            this.cl.ActiveGrid.GetListOfCrossings().Clear();
            this.cl.ActiveGrid.AllRoads.Clear();
            this.cl.ActiveGrid.ListOfCarStreams.Clear();
            PossibleEndPoints.Clear();
            SelectedStartPoint = new Point(0, 0);
            SelectedEndPoint = new Point(0, 0);
            this.Invalidate();
        }
            
        private void btnRemoveCrossing_Click(object sender, EventArgs e)
        {
            mouseMode = WhatToDo.RemoveCrossing;
            this.Invalidate();
        }
        
        #endregion
            
        private void GridMouseDown_Down(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            Point pointClicked = new Point(0, 0);//To be used differently by the different cases
            if (e.Button == MouseButtons.Right)
            {
                mouseMode = WhatToDo.None;
                RemoveCarStreamToggle = false;
                EditCarStreamToggle = false;
            }
            if (((p.X >= 240) && (p.X <= 1140)) && ((p.Y >= 30) && (p.Y <= 710)))
            {
                int spotInput = this.cl.ActiveGrid.GetCrossingSlot(p);
                switch (mouseMode)
                {
                    case WhatToDo.SimpleCrossing:
                        if (this.cl.ActiveGrid.IsSpotFree(p))
                        {
                            SimpleCrossing cr = new SimpleCrossing(this.cl.ActiveGrid.CrossingSlots[spotInput], spotInput);
                            this.cl.ActiveGrid.AddCrossing(cr, spotInput);
                            this.cl.ActiveGrid.MakeNeighbours(cr);
                            //Reset Mouse mode
                            this.cl.ActiveGrid.IsChanged = true;
                            this.UpdateToolStrip();
                        }
                        else
                        {
                            MessageBox.Show("This slot is already taken, place the crossing on an EMPTY one!");
                        }
                        this.Refresh();
                        break;
                    case WhatToDo.ComplexCrossing:
                        if (this.cl.ActiveGrid.IsSpotFree(p))
                        {
                            ComplexCrossing crCom = new ComplexCrossing(this.cl.ActiveGrid.CrossingSlots[spotInput], spotInput);
                            this.cl.ActiveGrid.MakeNeighbours(crCom);
                            this.cl.ActiveGrid.AddCrossing(crCom, spotInput);
                            this.cl.ActiveGrid.IsChanged = true;
                            this.UpdateToolStrip();
                        }
                        else
                        {
                            MessageBox.Show("This slot is already taken, place the crossing on an EMPTY one!");
                        }
                        this.Refresh();
                        break;
                    case WhatToDo.RemoveCrossing:
                        Crossing s = this.cl.ActiveGrid.GetCrossing(p);
                            
                        if (this.cl.ActiveGrid.RemoveCrossing(s))
                        {
                            this.Invalidate();
                            this.cl.ActiveGrid.IsChanged = true;
                            this.UpdateToolStrip();
                        }
                        this.Refresh();
                        break;
                    case WhatToDo.AddEditCarStream:
                        SelectedStartPoint = this.cl.ActiveGrid.GetStartingPoint(p);
                        if (SelectedStartPoint != new Point(0, 0))
                        {
                            this.cl.ActiveGrid.GetCrossing(SelectedStartPoint).UserChosenStartPoint = SelectedStartPoint;
                            this.cl.ActiveGrid.CreateRoads(this.cl.ActiveGrid.GetCrossing(SelectedStartPoint), new List<Point>(), new List<Crossing>());
                            this.formNewStream = new FormCarStream(ref this.cl, this);
                            this.formNewStream.Show();
                            this.cl.ActiveGrid.ListOfAllStartPoints.Clear();
                        }
                        else
                        {
                            SelectedStartPoint = this.cl.ActiveGrid.FindPointInList(p, this.cl.ActiveGrid.GetAllCarStreamStartPoints(), 10);
                            if (SelectedStartPoint != new Point(0, 0))
                            {
                                CarStream selectedCarStream = this.cl.ActiveGrid.GetCarStreamByStartPoint(SelectedStartPoint);
                                PossibleEndPoints = this.cl.ActiveGrid.GetAllEndPointsWithStart(SelectedStartPoint);
                                this.formNewStream = new FormCarStream(ref this.cl, this, ref selectedCarStream);
                                this.formNewStream.Show();
                            }
                        }
                        this.Invalidate();
                        this.UpdateToolStrip();
                        
                        break;
                    case WhatToDo.AddEditCarStreamEnd:
                        pointClicked = this.cl.ActiveGrid.FindPointInList(p, this.cl.ActiveGrid.GetAllEndPointsWithStart(SelectedStartPoint), 10);
                        if (pointClicked != new Point(0, 0))
                        {
                            SelectedEndPoint = pointClicked;
                            this.formNewStream.Show();
                            PossibleEndPoints.Clear();
                            this.Refresh();
                            this.UpdateToolStrip();
                        }
                        break;
                    case WhatToDo.RemoveCarStream:
                        pointClicked = this.cl.ActiveGrid.FindPointInList(p, this.cl.ActiveGrid.GetAllCarStreamStartPoints(), 10);
                        if (pointClicked != new Point(0, 0))
                        {
                            this.cl.ActiveGrid.RemoveCarStream(pointClicked);
                        }
                        RemoveCarStreamToggle = false;
                        this.Refresh();
                        break;
                    case WhatToDo.AddEditPedestrianStreamStart:
                        foreach (List<Point> points in this.cl.ActiveGrid.ListOfPossiblePedestrianStreams)
                        {
                            pointClicked = this.cl.ActiveGrid.FindPointInList(p, points, 2);
                        }
                        if (pointClicked != new Point(0, 0))
                        {
                            this.selectedPedestrianStartPoint = pointClicked;
                            mouseMode = WhatToDo.AddEditPedestrianStreamEnd;
                        }
                        this.Refresh();
                        break;
                    case WhatToDo.AddEditPedestrianStreamEnd:
                        foreach (List<Point> possiblePedestrianStream in this.cl.ActiveGrid.ListOfPossiblePedestrianStreams)
                        {
                            pointClicked = this.cl.ActiveGrid.FindPointInList(p, possiblePedestrianStream, 2);
                        }
                        if (pointClicked != new Point(0, 0))
                        {
                            this.cl.ActiveGrid.ListOfPedestrianStreams.Add(new PedestrianStream(this.selectedPedestrianStartPoint, this.selectedPedestrianEndPoint, 5));
                        }
                        mouseMode = WhatToDo.None;
                        this.Refresh();
                        break;
                    case WhatToDo.None:
            
                        break;
                }
            }
            else
            {
                MessageBox.Show("Click inside!");
            }
        }
            
        private void TbNewGrid_Click(object sender, EventArgs e)
        {
            ToolStripButton tb = new ToolStripButton();
            tb.Name = "Unnamed Grid" + this.y;
            tb.Text = tb.Name;
            //tb.BackColor = Color.Green;
            tb.Font = new Font("Roboto", 10);
            tb.ForeColor = Color.Blue;
            //tb.Paint += CommonTabPage_Paint;
            tb.Click += this.CommonChangeTab_Click;
            tb.MouseDown += this.CommonCloseTab_Click;
            Grid g = new Grid(tb.Name);
            if (this.cl.AddGrid(g))
            {
                this.y++;
                this.toolStrip1.Items.Add(tb);
                this.cl.ActiveGrid = g;
                this.UpdateToolstripButtons();
                this.UpdateToolStrip();
                this.Invalidate();
            }
            else
            {
                MessageBox.Show("ouch");
            }
        }
            
        private void UpdateToolstripButtons()
        {
            if (this.cl.ListOfGrids.Count == 10)
            {
                this.tbNewGrid.Enabled = false;
                this.tbLoad.Enabled = false;
            }
            else
            {
                this.tbNewGrid.Enabled = true;
                this.tbLoad.Enabled = true;
            }
        }
            
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label2.Text = this.st.Elapsed.ToString(@"hh\:mm\:ss");
            if (this.cl.ActiveGrid.ListOfCarStreams.Count > 0)
            {
                foreach (CarStream cstream in this.cl.ActiveGrid.ListOfCarStreams)
                {
                    cstream.DriveAllCars();
                }
                this.cl.ActiveGrid.SetCurrentCrossingsToCars();
                this.Invalidate();
            }
        }
            
        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (Crossing cr in this.cl.ActiveGrid.ListOfCrossings)
            {
                cr.ChangeTrafficLights(this.timertick);
            }
            this.timertick = this.timertick + 2;
            if (this.timertick == 9)
            {
                this.timertick = 1;
            }
            this.Invalidate();
        }
            
        private void CommonChangeTab_Click(object sender, EventArgs e)
        {
            this.cl.ActiveGrid = this.cl.GetGridByTabPage(((ToolStripButton)sender));
            for (int i = 0; i < this.toolStrip1.Items.OfType<ToolStripButton>().Count() - 2; i++)
            {
                this.toolStrip1.Items.OfType<ToolStripButton>().ElementAt(i + 2).BackColor = Color.Transparent;
            }
            ((ToolStripButton)sender).BackColor = Color.DarkGoldenrod;
            
            this.Invalidate();
        }
            
        private void CommonCloseTab_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Grid g = this.cl.GetGridByTabPage((ToolStripButton)sender);
                if (g.IsChanged)
                {
                    this.cl.Save(g);
                    this.UpdateToolStrip();
                }
                if (this.cl.getGridTabIndexByName(((ToolStripButton)sender).Name) == 2)
                {
                    if (this.cl.ListOfGrids.Count > 1)
                    {
                        this.cl.ActiveGrid = this.cl.ListOfGrids[this.cl.getGridTabIndexByName(((ToolStripButton)sender).Name) - 1];
                        this.removeTab((ToolStripButton)sender);
                        this.cl.RemoveGrid(g);
                        this.y--;//Lower the default naming index
                    }
                    else
                    {
                        MessageBox.Show("ERROR! Please add more grids, in order to remove that one!");
                    }
                }
                else
                {
                    this.cl.ActiveGrid = this.cl.ListOfGrids[this.cl.getGridTabIndexByName(((ToolStripButton)sender).Name) - 3];
                    this.removeTab((ToolStripButton)sender);
                    this.cl.RemoveGrid(g);
                    this.y--;
                }
            }
            this.Invalidate();
            this.UpdateToolstripButtons();
        }
            
        private ToolStripButton getTabByName(string tabName)
        {
            foreach (ToolStripButton tb in this.toolStrip1.Items.OfType<ToolStripButton>())
            {
                if (tb.Name.ToLower() == tabName)
                {
                    return tb;
                }
            }
            return null;
        }
            
        private void removeTab(ToolStripButton tabToRemove)
        {
            tabToRemove.Click -= new System.EventHandler(this.CommonChangeTab_Click);
            tabToRemove.MouseDown -= this.CommonCloseTab_Click;
        
            this.toolStrip1.Items.Remove(tabToRemove);
            tabToRemove.Dispose();
        }
            
        private void tbLoad_Click(object sender, EventArgs e)
        {
            Grid loadedGrid = this.cl.Load();
            ToolStripButton tb = new ToolStripButton();
            tb.Name = loadedGrid.TabPage;
            tb.Text = tb.Name;
            //tb.BackColor = Color.Green;
            tb.Font = new Font("Roboto", 10);
            tb.ForeColor = Color.Blue;
            //tb.Paint += CommonTabPage_Paint;
            tb.Click += this.CommonChangeTab_Click;
            tb.MouseDown += this.CommonCloseTab_Click;
            if (this.cl.AddGrid(loadedGrid))
            {
                this.toolStrip1.Items.Add(tb);
                this.cl.ActiveGrid = loadedGrid;
                this.UpdateToolstripButtons();
                this.UpdateToolStrip();
                for (int i = 0; i < this.toolStrip1.Items.OfType<ToolStripButton>().Count() - 2; i++)
                {
                    this.toolStrip1.Items.OfType<ToolStripButton>().ElementAt(i + 2).BackColor = Color.Transparent;
                }
                (tb).BackColor = Color.DarkGoldenrod;
                this.Invalidate();
            }
            else
            {
                MessageBox.Show("ouch");
            }
        }
            
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.cl.Load();
        }
            
        private void UpdateToolStrip()
        {
            for (int i = 0; i < this.cl.ListOfGrids.Count; i++)
            {
                if (this.cl.ListOfGrids[i].IsChanged)
                {
                    this.toolStrip1.Items.OfType<ToolStripButton>().ElementAt(i + 2).Text = this.cl.ListOfGrids[i].TabPage + "*";
                }
                else
                {
                    this.toolStrip1.Items.OfType<ToolStripButton>().ElementAt(i + 2).Text = this.cl.ListOfGrids[i].TabPage;
                }
                this.toolStrip1.Items.OfType<ToolStripButton>().ElementAt(i + 2).Name = this.cl.ListOfGrids[i].TabPage;
            }
        }
            
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cl.SaveAs(this.cl.ActiveGrid);
            this.UpdateToolStrip();
            this.y--;
        }
            
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cl.Save(this.cl.ActiveGrid);
            this.UpdateToolStrip();
            this.y--;
        }
            
        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cl.SaveAll();
            this.UpdateToolStrip();
        }
        
        //FORM EVENTS
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //IF edit car stream button is clicked
            this.cl.ActiveGrid.DrawAllItems(e.Graphics, this.imageList1);
            if (EditCarStreamToggle)
            {
                this.cl.ActiveGrid.DrawAllCrossings(e.Graphics, this.imageList1);
                this.cl.ActiveGrid.DrawAllCarStreamStartPoints(e.Graphics, 'e');
            }
            //If remove car stream button is clicked
            if (RemoveCarStreamToggle)
            {
                this.cl.ActiveGrid.DrawAllCrossings(e.Graphics, this.imageList1);
                this.cl.ActiveGrid.DrawAllCarStreamStartPoints(e.Graphics, 'r');
            }
            //DRAW all
            if ((mouseMode == WhatToDo.AddEditCarStream || mouseMode == WhatToDo.AddEditCarStreamEnd))
            {
                this.cl.ActiveGrid.DrawAllRoads(e.Graphics);
            }
            
            //If create new stream is clicked
            if (mouseMode == WhatToDo.AddEditCarStream)
            {
                if (this.cl.ActiveGrid.ListOfAllStartPoints.Count > 0)
                {
                    this.cl.ActiveGrid.DrawAllPossibleStartPoints(e.Graphics);
                }
                //If start point is already selected for a stream and endPoint has to be selected
            }
            if (PossibleEndPoints.Count > 0)
            {
                this.cl.ActiveGrid.DrawAllEndPoints(e.Graphics, PossibleEndPoints);
            }
            if (this.cl.ActiveGrid.ListOfPossiblePedestrianStreams.Count > 0 && mouseMode == WhatToDo.AddEditPedestrianStreamStart)
            {
                this.cl.ActiveGrid.DrawAllPedestrianStartPoints(e.Graphics, this.imageList1);
            }
            else if (this.cl.ActiveGrid.ListOfPossiblePedestrianStreams.Count > 0 && mouseMode == WhatToDo.AddEditPedestrianStreamEnd)
            {
                this.cl.ActiveGrid.DrawAllPedestrianEndPoints(e.Graphics, this.imageList1, this.selectedPedestrianStartPoint);
            }
            if (!this.cl.ActiveGrid.IsChanged)
            {
                //Save button is disabled - there's nothing to save
                this.saveToolStripMenuItem.Enabled = false;
                    
                if (this.cl.ActiveGrid.ListOfCrossings.Count == 0)
                {
                    //Save as button is disabled - the active grid is empty
                    this.saveAsToolStripMenuItem.Enabled = false;
                }
                else
                {
                    //Active grid is not empty, so the save button is enabled
                    this.saveAsToolStripMenuItem.Enabled = true;
                }
            }
            else
            {
                //Active grid is changed, so the save button is enabled
                this.saveToolStripMenuItem.Enabled = true;
            }
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Crossing crozz in this.cl.ActiveGrid.ListOfCrossings)
            {
                this.cl.ActiveGrid.MakeNeighbours(crozz);
            }
            this.cl.ActiveGrid.SetAllStartPoints();
            MessageBox.Show(this.cl.ActiveGrid.ListOfAllStartPoints.Count.ToString());
            
            Lane l = this.cl.ActiveGrid.ListOfCrossings.ElementAt(0).LisftOfLanes.ElementAt(0);
            
            Crossing c = this.cl.ActiveGrid.ListOfCrossings[0];
            c.UserChosenStartPoint = c.LisftOfLanes[0].Road[0];
            this.cl.ActiveGrid.CreateRoads(c, new List<Point>(), new List<Crossing>());
            CarStream cs = new CarStream(0, 10, this.cl.ActiveGrid.AllRoads.First());
            this.cl.ActiveGrid.AddCarStream(cs);
            this.cl.ActiveGrid.SetCurrentCrossingsToCars();
        
            MessageBox.Show(this.cl.ActiveGrid.AllRoads.Count.ToString());
            this.Invalidate();
        }
            
        private void btnAddEditStream_Click(object sender, EventArgs e)
        {
            foreach (Crossing crozz in this.cl.ActiveGrid.ListOfCrossings)
            {
                this.cl.ActiveGrid.MakeNeighbours(crozz);
            }
            this.cl.ActiveGrid.SetAllStartPoints();
            this.cl.ActiveGrid.AllRoads.Clear();
            EditCarStreamToggle = true;
            //
            //FormNewStream.Show();
        
            mouseMode = WhatToDo.AddEditCarStream;
            this.Invalidate();
        }
            
        private void btnRemoveCarStream_Click(object sender, EventArgs e)
        {
            mouseMode = WhatToDo.RemoveCarStream;
            RemoveCarStreamToggle = true;
            this.cl.ActiveGrid.GetAllCarStreamStartPoints();
            this.Refresh();
        }
            
        private void btnRemoveAllCarStreams_Click(object sender, EventArgs e)
        {
            this.cl.ActiveGrid.ListOfCarStreams.Clear();
            this.Refresh();
        }
            
        private void btnAddEditPedestrian_Click(object sender, EventArgs e)
        {
            foreach (Button btn in this.gpGrid.Controls.OfType<Button>())
            {
                btn.Enabled = false;
            }
            this.cl.ActiveGrid.SetPossiblePedestrianStreams();
            mouseMode = WhatToDo.AddEditPedestrianStreamStart;
            this.Refresh();
        }
            
        private void btnRemovePedestrian_Click(object sender, EventArgs e)
        {
            mouseMode = WhatToDo.RemovePedestrianStream;
        }
            
        private void btnRemoveAllPedestrians_Click(object sender, EventArgs e)
        {
            this.cl.ActiveGrid.ListOfPedestrianStreams.Clear();
        }
    }
}