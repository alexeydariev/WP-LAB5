using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    public class Grid
    {
        //FIELDS
        //LISTS
        //PROPERTIES
        public List<Point> CrossingSlots { get; set; }

        public List<Crossing> ListOfCrossings { get; set; }

        public List<List<Point>> AllRoads;

        public List<Point> ListOfAllStartPoints { get; set; }

        public List<Crossing> ListOfVisitedCrossings { get; set; }

        public List<CarStream> ListOfCarStreams { get; set; }

        public List<PedestrianStream> ListOfPedestrianStreams { get; set; }

        public List<List<Point>> ListOfPossiblePedestrianStreams { get; set; }

        public string TabPage { get; set; }

        public Point Position { get; set; }

        public bool IsChanged { get; set; }

        //CONSTRUCTOR
        public Grid(string tbName)
        {
            this.TabPage = tbName;
            this.Position = new Point(260, 40);
            this.ListOfCrossings = new List<Crossing>();
            this.CrossingSlots = new List<Point>();
            this.ListOfCarStreams = new List<CarStream>();
            this.ListOfPossiblePedestrianStreams = new List<List<Point>>();
            int Yg = 0;
            for (int k = 0; k < 3; k++)
            {
                for (int j = 0; j <= 3; j++)
                {
                    Point p = new Point(218 * j + this.Position.X, Yg + this.Position.Y);
                    this.CrossingSlots.Add(p);
                }
                Yg = 218 * (k + 1);
            }
            this.AllRoads = new List<List<Point>>();
            this.IsChanged = false;
            this.ListOfVisitedCrossings = new List<Crossing>();
            this.ListOfAllStartPoints = new List<Point>();
        }

        #region Crossing methods
        
        public List<Crossing> GetListOfCrossings()
        {
            return this.ListOfCrossings;
        }
        
        public bool AddToVisitedCrossings(Crossing newCrossing)
        {
            foreach (Crossing cro in this.ListOfVisitedCrossings)
            {
                if (cro == newCrossing)
                {
                    return false;
                }
            }
            this.ListOfVisitedCrossings.Add(newCrossing);
            return true;
        }
        
        public bool IsVisitedCrossing(Crossing cr, List<Crossing> visitedCrossings)
        {
            foreach (Crossing visitedCrossing in visitedCrossings)
            {
                if (visitedCrossing.Position == cr.Position)
                {
                    return true;
                }
            }
            return false;
        }
        
        public Crossing GetCrossing(Point mousePos)
        {
            foreach (Crossing cr in this.ListOfCrossings)
            {
                if (cr.ContainsPoint(mousePos))
                {
                    return cr;
                }
            }
            return null;
        }
        
        public Crossing GetCrossingBySlot(int slot)
        {
            foreach (Crossing cr in this.ListOfCrossings)
            {
                if (cr.Slot == slot)
                {
                    return cr;
                }
            }
            return null;
        }
        
        public int GetCrossingSlot(Point p)
        {
            for (int i = 0; i < this.CrossingSlots.Count; i++)
            {
                if ((p.X >= this.CrossingSlots[i].X) && (p.X <= this.CrossingSlots[i].X + 220) && ((p.Y >= this.CrossingSlots[i].Y)) && ((p.Y <= this.CrossingSlots[i].Y + 220)))
                {
                    return i;
                }
            }
            return -1;
        }
        
        public bool IsSpotFree(Point p)
        {
            foreach (Crossing cr in this.ListOfCrossings)
            {
                if (cr.ContainsPoint(p))
                {
                    return false;
                }
            }
            return true;
        }
        
        public bool AddCrossing(Crossing cr, int crplace)
        {
            if (cr is SimpleCrossing)
            {
                this.ListOfCrossings.Add(cr);
                return true;
            }
            else if (cr is ComplexCrossing)
            {
                this.ListOfCrossings.Add(cr);
                return true;
            }
            return false;
        }
        
        public bool RemoveCrossing(Crossing cross)
        {
            if (cross != null)
            {
                this.ListOfCrossings.Remove(cross);
                return true;
            }
            return false;
        }
        
        public void MakeNeighbours(Crossing crossOne)
        {
            int[] neighbourSlotsOffset = new int[4] { -1, 1, -4, 4 };
            
            for (int i = 0; i < neighbourSlotsOffset.Length; i++)
            {
                Crossing cr = this.GetCrossingBySlot(crossOne.Slot + neighbourSlotsOffset[i]);
                if (cr != null)
                {
                    switch (neighbourSlotsOffset[i])
                    {
                        case -1:
                            if (!((crossOne.Slot == 4) && (cr.Slot == 3)) &&
                                (!((crossOne.Slot == 8) && (cr.Slot == 7))))
                            {
                                crossOne.AddNeighbour(cr, 0);
                            }
                            break;
                        case -4:
                            crossOne.AddNeighbour(cr, 1);
                            break;
                        case 1:
                            if (!((crossOne.Slot == 3) && (cr.Slot == 4)) &&
                                (!((crossOne.Slot == 7) && (cr.Slot == 8))))
                            {
                                crossOne.AddNeighbour(cr, 2);
                            }
                            break;
                        case 4:
                            crossOne.AddNeighbour(cr, 3);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        
        #endregion
        
        #region Car Stream Methods
        
        public Point GetStartingPoint(Point mousePos)
        {
            int radius = 10;
            foreach (Point p in this.ListOfAllStartPoints)
            {
                if ((p.X - mousePos.X) * (p.X - mousePos.X) + (p.Y - mousePos.Y) * (p.Y - mousePos.Y) <= radius * radius)
                {
                    return p;
                }
            }
            return new Point(0, 0);
        }
        
        public void SetCurrentCrossingsToCars()
        {
            foreach (CarStream stream in this.ListOfCarStreams)
            {
                foreach (Car car in stream.CarList)
                {
                    car.CurrentCrossing = this.GetCrossing(car.Position);
                }
            }
        }
        
        public bool AddCarStream(CarStream c)
        {
            if (c != null)
            {
                this.ListOfCarStreams.Add(c);
                return true;
            }
            return false;
        }
        
        public void CreateRoads(Crossing cr, List<Point> tempRoad, List<Crossing> visitedCrossings)
        {
            for (int i = 0; i < cr.GetNeighborList().Length; i++)
            {
                #region If there is a neighbour on the searched position
                
                if (cr.GetNeighborList()[i] != null)
                {
                    if (!this.IsVisitedCrossing(cr.GetNeighborList()[i], visitedCrossings))
                    {
                        foreach (Lane l in cr.LisftOfLanes)
                        {
                            // NOT USED
                            string endIndex = Convert.ToInt16(l.Id.Substring(1, 1)).ToString();
                            string startIndex = "";
                            if (endIndex == i.ToString())
                            {
                                if (tempRoad.Count != 0)
                                {
                                    startIndex = cr.GetNeighbourIndex(visitedCrossings[visitedCrossings.Count - 1]).ToString();
                                }
                                else
                                {
                                    foreach (Lane lanes in cr.LisftOfLanes)
                                    {
                                        if (lanes.EntryPoint == cr.UserChosenStartPoint)
                                        {
                                            startIndex = lanes.Id.Substring(0, 1);
                                            break;
                                        }
                                    }
                                }
                                if (startIndex != endIndex)
                                {
                                    List<Point> laneToAdd = cr.GetLaneById(startIndex + endIndex).Road;
                                    
                                    tempRoad.AddRange(laneToAdd);
                                    visitedCrossings.Add(cr);
                                    this.CreateRoads(cr.GetNeighborList()[i], new List<Point>(tempRoad), new List<Crossing>(visitedCrossings));
                                    visitedCrossings.Remove(cr);
                                    tempRoad.RemoveRange(((tempRoad.Count - (laneToAdd.Count))), laneToAdd.Count);
                                }
                            }
                        }
                    }
                    else
                    {
                    }
                }
                
                #endregion
                
                #region If there is no neighbour on the checked position
                    
                else
                {
                    string startIndex = "";
                    string endIndex = "";
                    if (tempRoad.Count > 0)
                    {
                        startIndex = cr.GetNeighbourIndex(visitedCrossings.Last()).ToString();
                        endIndex = i.ToString();
                        List<Point> roadToCreate = tempRoad;
                        List<Point> laneToAdd = cr.GetLaneById(startIndex + endIndex).Road;
                        roadToCreate.AddRange(laneToAdd);
                        this.AllRoads.Add(new List<Point>(roadToCreate));
                        tempRoad.RemoveRange(((tempRoad.Count - (laneToAdd.Count))), laneToAdd.Count);
                    }
                    else
                    {
                        //Find on which side is the UserChosenStartPoint and set it as startIndex of the crossing
                        //Which will be chosen 
                        foreach (Lane lanes in cr.LisftOfLanes)
                        {
                            if (lanes.EntryPoint == cr.UserChosenStartPoint)
                            {
                                startIndex = lanes.Id.Substring(0, 1);
                                break;
                            }
                        }
                        if (startIndex != i.ToString())
                        {
                            endIndex = i.ToString();
                            List<Point> roadToAdd = tempRoad;
                            roadToAdd.AddRange(cr.GetLaneById(startIndex + endIndex).Road);
                            if (cr.GetLaneById(startIndex + endIndex).Road.First() == cr.UserChosenStartPoint)
                            {
                                this.AllRoads.Add(new List<Point>(roadToAdd));
                            }
                            tempRoad.Clear();
                            //listOfVisitedCrossings.Clear();
                        }
                    }
                }
        
                #endregion
            }
        }
            
        public List<List<Point>> GetRoadsWithStartPoint(Point startPoint)
        {
            List<List<Point>> selectedRoads = new List<List<Point>>();
            foreach (List<Point> road in this.AllRoads)
            {
                if (road.First() == startPoint)
                {
                    selectedRoads.Add(road);
                }
            }
            return selectedRoads;
        }
            
        public List<Point> GetRoadByPoints(Point startPoint, Point endPoint)
        {
            List<Point> shortestRoad = new List<Point>();
            List<List<Point>> matchingRoads = new List<List<Point>>();
            foreach (List<Point> road in this.GetRoadsWithStartPoint(startPoint))
            {
                if (road.Last() == endPoint)
                {
                    matchingRoads.Add(road);
                }
            }
            shortestRoad = matchingRoads.First();
            foreach (List<Point> matchingRoad in matchingRoads)
            {
                if (matchingRoad.Count < shortestRoad.Count)
                {
                    shortestRoad = matchingRoad;
                }
            }
            if (shortestRoad.Count > 0)
            {
                return shortestRoad;
            }
            else
            {
                return new List<Point>();
            }
        }
            
        public void SetAllStartPoints()
        {
            this.ListOfAllStartPoints = new List<Point>();
            foreach (Crossing cross in this.ListOfCrossings)
            {
                bool partOfStream = false;
                for (int i = 0; i < cross.GetNeighborList().Length; i++)
                {
                    //Check if this neighbour position is empty 
                    if (cross.GetNeighborList()[i] == null)
                    {
                        foreach (Lane l in cross.LisftOfLanes)
                        {
                            //Check if this start point is already added
                            if (!this.ListOfAllStartPoints.Contains(l.EntryPoint))
                            {
                                if (l.Id.Substring(0, 1) == i.ToString())
                                {
                                    foreach (CarStream carstream in this.ListOfCarStreams)
                                    {
                                        if ((carstream.Road.First() == l.EntryPoint))
                                        {
                                            partOfStream = true;
                                        }
                                    }
                                    if (!partOfStream)
                                    {
                                        this.ListOfAllStartPoints.Add(l.EntryPoint);
                                    }
                                }
                                partOfStream = false;
                            }
                        }
                    }
                }
            }
        }
                
        public CarStream GetCarStreamByStartPoint(Point startPoint)
        {
            foreach (CarStream cs in this.ListOfCarStreams)
            {
                if (cs.Road.First() == startPoint)
                {
                    return cs;
                }
            }
            return null;
        }
            
        public List<Point> GetAllCarStreamStartPoints()
        {
            List<Point> allstartPoints = new List<Point>();
            foreach (CarStream carStream in this.ListOfCarStreams)
            {
                allstartPoints.Add(carStream.Road.First());
            }
            return allstartPoints;
        }
            
        public List<Point> GetAllEndPointsWithStart(Point startPoint)
        {
            List<Point> listOfEndPoints = new List<Point>();
            foreach (List<Point> road in this.GetRoadsWithStartPoint(startPoint))
            {
                listOfEndPoints.Add(road.Last());
            }
            return listOfEndPoints;
        }
                
        public Point FindPointInList(Point mousePos, List<Point> listOfPoints, int radius)
        {
            foreach (Point p in listOfPoints)
            {
                if (((p.X - mousePos.X) * (p.X - mousePos.X) + (p.Y - mousePos.Y) * (p.Y - mousePos.Y) <= radius * radius))
                {
                    return p;
                }
            }
            return new Point(0, 0);
        }
            
        public void RemoveCarStream(Point startPoint)
        {
            CarStream carStreamToRemove = null;
            foreach (CarStream carstream in this.ListOfCarStreams)
            {
                if (carstream.Road.First() == startPoint)
                {
                    carStreamToRemove = carstream;
                }
            }
            if (carStreamToRemove != null)
            {
                this.ListOfCarStreams.Remove(carStreamToRemove);
            }
        }
        
        #endregion
        
        //PEDESTRIAN METHODS
            
        #region Pedestrian methods
                
        public void SetPossiblePedestrianStreams()
        {
            foreach (ComplexCrossing cr in this.ListOfCrossings.OfType<ComplexCrossing>())
            {
                //CHECK
                for (int i = 1; i < cr.ListOfPedestrianLights.Count - 1; i += 2)
                {
                    this.ListOfPossiblePedestrianStreams.Add(new List<Point> { cr.ListOfPedestrianLights[i].Pos, cr.ListOfPedestrianLights[i + 1].Pos });
                }
                this.ListOfPossiblePedestrianStreams.Add(new List<Point> { cr.ListOfPedestrianLights[7].Pos, cr.ListOfPedestrianLights[0].Pos });
            }
        }
        
        #endregion
            
        #region Draw Methods
            
        public void DrawAllPossibleStartPoints(Graphics gr)
        {
            Pen pen = new Pen(Brushes.Red);
            foreach (Point p in this.ListOfAllStartPoints)
            {
                int radius = 6;
                float x = p.X - radius;
                float y = p.Y - radius;
                float width = 2 * radius;
                float height = 2 * radius;
                gr.FillEllipse(Brushes.Green, x, y, width, height);
            }
        }
                
        public void DrawAllPedestrianStreams(Graphics gr, ImageList il)
        {
            foreach (PedestrianStream pstream in this.ListOfPedestrianStreams)
            {
                pstream.DrawAllPedestrians(gr, il);
            }
        }
                
        public void DrawAllPedestrianStartPoints(Graphics gr, ImageList il)
        {
            foreach (List<Point> p in this.ListOfPossiblePedestrianStreams)
            {
                int radius = 6;
                float x = p.First().X - radius;
                float y = p.First().Y - radius;
                float width = 2 * radius;
                float height = 2 * radius;
                gr.FillEllipse(Brushes.Yellow, x, y, width, height);
            }
        }
                
        public void DrawAllPedestrianEndPoints(Graphics gr, ImageList il, Point startPoint)
        {
            foreach (List<Point> possiblePoints in this.ListOfPossiblePedestrianStreams)
            {
                if (possiblePoints.Contains(startPoint))
                {
                    int radius = 6;
                    float x = possiblePoints.Last().X - radius;
                    float y = possiblePoints.Last().Y - radius;
                    if (startPoint != new Point(Convert.ToInt16(x), Convert.ToInt16(y)))
                    {
                        float width = 2 * radius;
                        float height = 2 * radius;
                        gr.FillEllipse(Brushes.DarkMagenta, x, y, width, height);
                    }
                    else
                    {
                        x = possiblePoints.First().X - radius;
                        y = possiblePoints.First().Y - radius;
                        float width = 2 * radius;
                        float height = 2 * radius;
                        gr.FillEllipse(Brushes.DarkMagenta, x, y, width, height);
                    }
                }
            }
        }
                
        public void DrawAllCarStreamStartPoints(Graphics gr, char removeOrEdit)
        {
            foreach (Point p in this.GetAllCarStreamStartPoints())
            {
                int radius = 6;
                float x = p.X - radius;
                float y = p.Y - radius;
                float width = 2 * radius;
                float height = 2 * radius;
                if (removeOrEdit == 'r')
                {
                    gr.FillEllipse(Brushes.DarkRed, x, y, width, height);
                }
                else if (removeOrEdit == 'e')
                {
                    gr.FillEllipse(Brushes.Orange, x, y, width, height);
                }
            }
        }
                
        public void DrawAllCrossings(Graphics gr, ImageList il)
        {
            foreach (Crossing cr in this.ListOfCrossings)
            {
                cr.DrawItself(gr, il);
            }
        }
        
        public void DrawAllItems(Graphics gr, ImageList il)
        {
            this.DrawAllCrossings(gr, il);
            this.DrawAllCarStreamsInGrid(gr, il);
        }
                
        public void DrawAllCarStreamsInGrid(Graphics gr, ImageList il)
        {
            foreach (CarStream cs in this.ListOfCarStreams)
            {
                cs.DrawAllCars(gr, il);
            }
        }
            
        public void DrawAllRoads(Graphics gr)
        {
            System.Drawing.Pen p = new System.Drawing.Pen(System.Drawing.Brushes.GreenYellow);
            for (int i = 0; i < this.AllRoads.Count; i++)
            {
                gr.DrawLines(p, this.AllRoads[i].ToArray());
            }
        }
            
        public void DrawAllEndPoints(Graphics gr, List<Point> endPoints)
        {
            Pen pen = new Pen(Brushes.Red);
            foreach (Point p in endPoints)
            {
                int radius = 6;
                float x = p.X - radius;
                float y = p.Y - radius;
                float width = 2 * radius;
                float height = 2 * radius;
                gr.FillEllipse(Brushes.IndianRed, x, y, width, height);
            }
        }

        #endregion
    }
}