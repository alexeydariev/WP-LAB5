using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    public class Controller
    {
        //FIELDS
        public List<Grid> ListOfGrids;

        //CONSTRUCTOR
        public Controller(string tabPage)
        {
            this.ListOfGrids = new List<Grid>();
            Grid newgrid = new Grid(tabPage);
            this.AddGrid(newgrid);
            this.ActiveGrid = newgrid;
        }

        //PROPERTIES
        public string LastSavePath { get; set; }

        public Grid ActiveGrid { get; set; }

        //METHODS
        public Grid GetGridByTabPage(ToolStripButton tabPage)
        {
            string tbName = tabPage.Name;
            foreach (Grid gr in this.ListOfGrids)
            {
                if (gr.TabPage.ToLower() == tbName.ToLower())
                {
                    return gr;
                }
            }
            return null;
        }

        public int getGridTabIndexByName(string gridName)
        {
            foreach (Grid gr in this.ListOfGrids)
            {
                if (gridName.ToLower() == gr.TabPage.ToLower())
                {
                    return this.ListOfGrids.IndexOf(gr) + 2;
                }
            }
            return -1;
        }

        //MANAGING GRIDS
        public bool AddGrid(Grid g)
        {
            if (this.ListOfGrids.Count == 10)
            {
                return false;
            }
            else
            {
                this.ListOfGrids.Add(g);
                return true;
            }
        }

        public bool RemoveGrid(Grid g)
        {
            if (!g.IsChanged)
            {
                this.ListOfGrids.Remove(g);
                return true;
            }
            else
            {
                return false;
            }
        }

        //FILES 
        public void Save(Grid gridToSave)
        {
            string fullFilePath = this.LastSavePath + "\\" + gridToSave.TabPage;
            if (File.Exists(fullFilePath) && !(gridToSave.TabPage.ToLower().Contains("unnamed")))
            {
                FileStream fs = null;
                BinaryFormatter bf = null;
                try
                {
                    fs = File.Create(fullFilePath);
                    bf = new BinaryFormatter();
                    bf.Serialize(fs, gridToSave);
                    foreach (Grid g in this.ListOfGrids)
                    {
                        if (g.TabPage == gridToSave.TabPage)
                        {
                            g.IsChanged = false;
                        }
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
                MessageBox.Show(this.LastSavePath);
            }
            else
            {
                this.SaveAs(gridToSave);
            }
        }

        public void SaveAs(Grid gridToSave)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Binary files Files (*.TSF*)|*.tsf";
            sfd.DefaultExt = "bin";
            sfd.AddExtension = true;
            if (!(gridToSave.ListOfCrossings.Count == 0))
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = null;
                    BinaryFormatter bf = null;
                    try
                    {
                        fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                        bf = new BinaryFormatter();
                        gridToSave.TabPage = Path.GetFileName(sfd.FileName);
                        bf.Serialize(fs, gridToSave);
                        foreach (Grid g in this.ListOfGrids)
                        {
                            if (g.TabPage == gridToSave.TabPage)
                            {
                                g.IsChanged = false;
                                g.TabPage = Path.GetFileName(sfd.FileName);
                            }
                        }
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show(e.Message);
                    }
                    finally
                    {
                        this.LastSavePath = Path.GetDirectoryName(sfd.FileName);
                        if (fs != null)
                        {
                            fs.Close();
                        }
                    }
                }
            }
        }

        public Grid Load()
        {
            Grid loadedGrid = null;
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                BinaryFormatter bf = null;

                try
                {
                    fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                    bf = new BinaryFormatter();
                    loadedGrid = (Grid)(bf.Deserialize(fs));
                }
                catch (IOException)
                {
                    MessageBox.Show("Input/Output error");
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
                MessageBox.Show("Loading done !");
                MainForm.ActiveForm.Invalidate();
            }
            return loadedGrid;
        }

        public void SaveAll()
        {
            foreach (Grid g in this.ListOfGrids)
            {
                if (g.IsChanged)
                {
                    this.Save(g);
                }
            }
        }
    }
}