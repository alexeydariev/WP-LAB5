using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    public class Crossing
    {
        public List<CarStream> StartingStreams;
        private Crossing[] listOfNeighbours;

        private List<CarTrafficLight> listOfCarTrafficLights { get; set; }

        //PROPERTIES
        public int ID { get; set; }

        public List<CarTrafficLight> ListOfCarTrafficLights
        {
            get
            {
                return this.listOfCarTrafficLights;
            }
            set
            {
                this.listOfCarTrafficLights = value;
            }
        }

        public List<PedestrianTrafficLight> ListOfPedestrianLights { get; set; }

        public Point UserChosenStartPoint { get; set; }

        public List<Point> ListOfPoints { get; set; }
     
        public List<Lane> LisftOfLanes { get; set; }

        public Point Position { get; set; }

        //Constructor

        public Crossing(Point position, int spotID)
        {
            this.Position = position;
            this.Slot = spotID;
            this.ListOfCarTrafficLights = new List<CarTrafficLight>();
            this.ListOfPedestrianLights = new List<PedestrianTrafficLight>();
            this.ListOfPoints = new List<Point>();
            this.listOfNeighbours = new Crossing[4];
            this.LisftOfLanes = new List<Lane>();
            this.LoadLanesFromFile("../../../lanePoints.txt");
            this.StartingStreams = new List<CarStream>();
            this.UserChosenStartPoint = new Point(-1, -1);
            
            #region Create Car Traffic Lights
            
            this.ListOfCarTrafficLights.Add(new CarTrafficLight("4 8",new Point(this.Position.X + 82, this.Position.Y + 129)));//1
            this.ListOfCarTrafficLights.Add(new CarTrafficLight("6 10", new Point(this.Position.X + 132, this.Position.Y + 85)));//5
            this.ListOfCarTrafficLights.Add(new CarTrafficLight("2", new Point(this.Position.X + 132, this.Position.Y + 99)));//4
            this.ListOfCarTrafficLights.Add(new CarTrafficLight("0", new Point(this.Position.X + 82, this.Position.Y + 115)));//0
            this.ListOfCarTrafficLights.Add(new CarTrafficLight("7 11", new Point(this.Position.X + 128, this.Position.Y + 132)));//3
            this.ListOfCarTrafficLights.Add(new CarTrafficLight("5 9", new Point(this.Position.X + 85, this.Position.Y + 82)));//7
            this.ListOfCarTrafficLights.Add(new CarTrafficLight("3", new Point(this.Position.X + 114, this.Position.Y + 132)));//2
            this.ListOfCarTrafficLights.Add(new CarTrafficLight("1", new Point(this.Position.X + 99, this.Position.Y + 82)));//6
            
            #endregion
            
            #region Create Pedestrian Traffic Lights
            
            this.ListOfPedestrianLights.Add(new PedestrianTrafficLight(new Point(this.Position.X + 72, this.Position.Y + 77)));//1
            this.ListOfPedestrianLights.Add(new PedestrianTrafficLight(new Point(this.Position.X + 77, this.Position.Y + 72)));//5
            this.ListOfPedestrianLights.Add(new PedestrianTrafficLight(new Point(this.Position.X + 144, this.Position.Y + 72)));//4
            this.ListOfPedestrianLights.Add(new PedestrianTrafficLight(new Point(this.Position.X + 147, this.Position.Y + 77)));//0
            this.ListOfPedestrianLights.Add(new PedestrianTrafficLight(new Point(this.Position.X + 147, this.Position.Y + 144)));//3
            this.ListOfPedestrianLights.Add(new PedestrianTrafficLight(new Point(this.Position.X + 144, this.Position.Y + 147)));//7
            this.ListOfPedestrianLights.Add(new PedestrianTrafficLight(new Point(this.Position.X + 77, this.Position.Y + 147)));//2
            this.ListOfPedestrianLights.Add(new PedestrianTrafficLight(new Point(this.Position.X + 72, this.Position.Y + 144)));//6
            
            #endregion
        }
        
        public void LoadLanesFromFile(String filename)
        {
            StreamReader str = null;
            try
            {
                str = new StreamReader(new FileStream(filename, FileMode.Open, FileAccess.Read));
                String s = "";
                s = str.ReadLine();
                s = str.ReadLine();
                while (s.ToLower() != "right")
                {
                    string[] tokens = s.Split();
                    string id = tokens[0];
                    Point entryPoint = new Point(Convert.ToInt16(tokens[1]) + this.Position.X, Convert.ToInt16(tokens[2]) + this.Position.Y);
                    Point stopPoint = new Point(Convert.ToInt16(tokens[3]) + this.Position.X, Convert.ToInt16(tokens[4]) + this.Position.Y);
                    Point curveEnd = new Point(Convert.ToInt16(tokens[5]) + this.Position.X, Convert.ToInt16(tokens[6]) + this.Position.Y);
                    Point exitPoint = new Point(Convert.ToInt16(tokens[7]) + this.Position.X, Convert.ToInt16(tokens[8]) + this.Position.Y);
                    Lane newLane = new Lane(id, entryPoint, stopPoint, curveEnd, exitPoint);
                    List<Point> leftTurnPoints = new List<Point>();
                    for (int i = 9; i < tokens.Length; i += 2)
                    {
                        leftTurnPoints.Add(new Point((Convert.ToInt16(tokens[i]) + this.Position.X),(Convert.ToInt16(tokens[i + 1])) + this.Position.Y));
                    }
                    newLane.Road.InsertRange(2, leftTurnPoints);
                    this.LisftOfLanes.Add(newLane);
                    s = str.ReadLine();
                }
                s = str.ReadLine();
                while (s.ToLower() != "straight")
                {
                    string[] tokens = s.Split();
                    string id = tokens[0];
                    Point entryPoint = new Point(Convert.ToInt16(tokens[1]) + this.Position.X, Convert.ToInt16(tokens[2]) + this.Position.Y);
                    Point stopPoint = new Point(Convert.ToInt16(tokens[3]) + this.Position.X, Convert.ToInt16(tokens[4]) + this.Position.Y);
                    Point curveStart = new Point(Convert.ToInt16(tokens[5]) + this.Position.X, Convert.ToInt16(tokens[6]) + this.Position.Y);
                    Point curveEnd = new Point(Convert.ToInt16(tokens[7]) + this.Position.X, Convert.ToInt16(tokens[8]) + this.Position.Y);
                    Point exitPoint = new Point(Convert.ToInt16(tokens[9]) + this.Position.X, Convert.ToInt16(tokens[10]) + this.Position.Y);
                    
                    Lane newLane = new Lane(id, entryPoint, stopPoint, curveStart, curveEnd, exitPoint);
                    this.LisftOfLanes.Add(newLane);
                    s = str.ReadLine();
                }
                s = str.ReadLine();
                while (s.ToLower() != "end")
                {
                    string[] tokens = s.Split();
                    string id = tokens[0];
                    Point entryPoint = new Point(Convert.ToInt16(tokens[1]) + this.Position.X, Convert.ToInt16(tokens[2]) + this.Position.Y);
                    Point stopPoint = new Point(Convert.ToInt16(tokens[3]) + this.Position.X, Convert.ToInt16(tokens[4]) + this.Position.Y);
                    Point exitPoint = new Point(Convert.ToInt16(tokens[5]) + this.Position.X, Convert.ToInt16(tokens[6]) + this.Position.Y);
                    Lane newLane = new Lane(id, entryPoint, stopPoint, exitPoint);
                    this.LisftOfLanes.Add(newLane);
                    s = str.ReadLine();
                }
            }
            catch (IOException)
            {
            }
            finally
            {
                if (str != null)
                {
                    str.Close();
                }
            }
        }
        
        public Lane GetLaneById(string id)
        {
            foreach (Lane ln in this.LisftOfLanes)
            {
                if (ln.Id == id)
                {
                    return ln;
                }
            }
            return null;
        }
        
        public Crossing[] GetNeighborList()
        { 
            return this.listOfNeighbours;
        }
        
        public int Slot { get; set; }
        
        //Checks whether this crossing has the selected point. E.g. mouse position when clicked
        public bool ContainsPoint(Point p)
        {
            if ((p.X <= this.Position.X + 220) && (p.X >= this.Position.X) && (p.Y <= this.Position.Y + 220) && (p.Y >= this.Position.Y))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public bool AddCarStream(CarStream carsteam)
        {
            this.StartingStreams.Add(carsteam);
            return true;
        }
        
        public bool EditStream(int numberOfCars, int streamID, string endPoint) 
        {
            return false; 
        }
        
        public void StartAllStreams()
        {
        }
        
        #region DRAW METHODS
        
        public virtual void DrawAllTrafficLights(Graphics gr)
        {
            foreach (CarTrafficLight tl in this.ListOfCarTrafficLights)
            {
                Pen pen = new Pen(tl.LightColor);
                gr.DrawEllipse(pen, tl.Pos.X, tl.Pos.Y, tl.Radius, tl.Radius);
                gr.FillEllipse(pen.Brush, tl.Pos.X, tl.Pos.Y, tl.Radius, tl.Radius);
            }
        }
        
        public virtual void DrawItself(Graphics gr, ImageList il)
        {
            gr.DrawImage(il.Images[0], this.Position.X, this.Position.Y);
            this.DrawAllTrafficLights(gr);
            this.DrawAllStartingStreams(gr, il);
        }
        
        public void DrawAllStartingStreams(Graphics gr, ImageList il)
        {
            foreach (CarStream cstream in this.StartingStreams)
            {
                cstream.DrawAllCars(gr, il);
            }
        }
        
        #endregion
        
        public bool AddNeighbour(Crossing cross, int neighbourPosition)
        {
            if (cross != null)
            {
                if (this.listOfNeighbours[neighbourPosition] == null)
                {
                    this.listOfNeighbours[neighbourPosition] = cross;
                    
                    return true;
                }
            }
            return false;
        }
        
        public int GetIndexOfLane(Lane l)
        {
            for (int i = 0; i < this.LisftOfLanes.Count; i++)
            {
                if (this.LisftOfLanes[i] == l)
                {
                    return i;
                }
            }
            return -1;
        }
        
        public void ConnectLanes(Crossing cr)
        {
            int indexOfThisCrossingInNeighbourList = cr.GetNeighbourIndex(this);
            foreach (Lane l in this.LisftOfLanes)
            {
                if (Convert.ToInt16(l.Id.Substring(0, 1)) == this.GetNeighbourIndex(cr))
                {
                    foreach (Lane laneToAdd in cr.LisftOfLanes)
                    {
                        if (Convert.ToInt16(laneToAdd.Id.Substring(1, 1)) == indexOfThisCrossingInNeighbourList)
                        {
                            laneToAdd.NextLanes.Add(l);
                            l.PreviousLanes.Add(laneToAdd);
                        }
                    }
                }
                else if (Convert.ToInt16(l.Id.Substring(1, 1)) == this.GetNeighbourIndex(cr))
                {
                    foreach (Lane laneToAdd in cr.LisftOfLanes)
                    {
                        if (Convert.ToInt16(laneToAdd.Id.Substring(0, 1)) == indexOfThisCrossingInNeighbourList)
                        {
                            l.NextLanes.Add(laneToAdd);
                            laneToAdd.PreviousLanes.Add(l);
                        }
                    }
                }
            }
        }
        
        public int GetNeighbourIndex(Crossing c)
        {
            for (int i = 0; i < this.listOfNeighbours.Length; i++)
            {
                if (this.listOfNeighbours[i] == c)
                {
                    return i;
                }
            }
            return -1;
        }
        
        public bool RemoveNeighbour(Crossing cross)
        {
            if (cross != null)
            {
                for (int i = 0; i < this.listOfNeighbours.Length; i++)
                {
                    if (this.listOfNeighbours[i] == cross)
                    {
                        this.listOfNeighbours[i] = null;
                        return true;
                    }
                }
            }
            return false;
        }
        
        public Crossing GetNeighborCrossing(Point positionMouse)
        {
            foreach (Crossing cross in this.listOfNeighbours)
            {
                if (cross.Position == positionMouse)
                {
                    return cross;
                }
            }
            return null;
        }
        
        public virtual void AllRed()
        {
            foreach (TrafficLight tl in this.ListOfCarTrafficLights)
            {
                tl.SetTrafficLight(Color.Red);
            }
        }
        
        public virtual void ChangeTrafficLights(int i)
        {
            this.AllRed();
            this.listOfCarTrafficLights[i - 1].SetTrafficLight(Color.LightGreen);
            this.listOfCarTrafficLights[i].SetTrafficLight(Color.LightGreen);
        }
    }

    class SimpleCrossing : Crossing
    {
        public SimpleCrossing(Point position, int spot) : base(position, spot)
        {
        }

        public override void DrawItself(Graphics gr, ImageList il)
        {
            gr.DrawImage(il.Images[0], this.Position.X, this.Position.Y);
            this.DrawAllTrafficLights(gr);
            this.DrawAllStartingStreams(gr, il);
        }
    }

    class ComplexCrossing : Crossing
    {
        public ComplexCrossing(Point pos, int spot) : base(pos, spot)
        {
            this.ListOfPedestrians = new List<PedestrianStream>();
            // TODO: Complete member initialization
        }

        public List<PedestrianStream> ListOfPedestrians { get; set; }

        public bool addPedestrianStream(PedestrianStream stream)
        {
            this.ListOfPedestrians.Add(stream);
            //TODO - Disable the pedestrian point, 
            //so you cannot add new pedestrian stream on same place
            //You can use Edit then
            return false;
        }

        public override void DrawItself(Graphics gr, ImageList il)
        {
            gr.DrawImage(il.Images[1], this.Position.X, this.Position.Y);
            this.DrawAllTrafficLights(gr);
            this.DrawAllStartingStreams(gr, il);
        }

        public void ChangePedestrianLights(string whatIsGreen)
        {
        }
    }
}