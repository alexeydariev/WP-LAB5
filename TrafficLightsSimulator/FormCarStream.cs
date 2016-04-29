using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    public partial class FormCarStream : Form
    {
        private CarStream editCarStream;
        private Controller controler;
        private Form mainForm;

        public FormCarStream(ref Controller cl, MainForm mf)
        {
            this.InitializeComponent();
            this.gpNewStream.ForeColor = Color.FromArgb(77, 188, 233);
            this.gpNewStream.BackColor = Color.FromArgb(95, 90, 92);
            this.BackColor = Color.FromArgb(95, 90, 92);
            this.controler = cl;
            this.mainForm = mf;
            this.btnCreateOrEdit.Text = "Create new stream";
            MainForm.mouseMode = MainForm.WhatToDo.AddEditCarStreamEnd;
        }

        public FormCarStream(ref Controller cl, MainForm mf, ref CarStream editedCarStream)
        {
            this.InitializeComponent();
            this.gpNewStream.ForeColor = Color.FromArgb(77, 188, 233);
            this.gpNewStream.BackColor = Color.FromArgb(95, 90, 92);
            this.BackColor = Color.FromArgb(95, 90, 92);
            this.controler = cl;
            this.mainForm = mf;
            this.editCarStream = editedCarStream;
            this.nmNrCars.Value = this.editCarStream.CarList.Count();
            this.Text = "Edit Car Stream";
            this.btnCreateOrEdit.Text = "Edit stream";
            if (editedCarStream != null)
            {
                this.nmNrCars.Value = editedCarStream.CarList.Count();
            }
            this.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.controler.ActiveGrid.SetAllStartPoints();
            this.Hide();
            this.mainForm.Invalidate();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            MainForm.mouseMode = MainForm.WhatToDo.AddEditCarStreamEnd;
            MainForm.PossibleEndPoints = this.controler.ActiveGrid.GetAllEndPointsWithStart(MainForm.SelectedStartPoint);
            this.Hide();
            this.mainForm.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.editCarStream == null)
            {
                List<Point> road = this.controler.ActiveGrid.GetRoadByPoints(MainForm.SelectedStartPoint, MainForm.SelectedEndPoint);
                this.controler.ActiveGrid.ListOfCarStreams.Add(new CarStream(1, Convert.ToInt16(this.nmNrCars.Value), road));
                this.controler.ActiveGrid.SetCurrentCrossingsToCars();
            }
            else
            {
                List<Point> road = this.controler.ActiveGrid.GetRoadByPoints(MainForm.SelectedStartPoint, MainForm.SelectedEndPoint);
                this.editCarStream.Road = road;
                this.editCarStream.SetNumberOfCars(Convert.ToInt16(this.nmNrCars.Value));
            }
            this.controler.ActiveGrid.AllRoads.Clear();
            this.mainForm.Invalidate();
            this.Hide();
        }
    }
}