using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TrafficLight
{
    [Serializable]
    public class Lane
    {
        public List<Point> Road = new List<Point>();

        private Point curveStart;
        private Point curveEnd;

        //STRAIGHT LANE
        public Lane(string id, Point entryPoint, Point stopPoint, Point exitPoint)
        {
            this.Id = id;
            this.EntryPoint = entryPoint;
            this.StopPoint = stopPoint;
            this.ExitPoint = exitPoint;
            this.CreatePath("straight");
            this.PreviousLanes = new List<Lane>();
            this.NextLanes = new List<Lane>();
        }

        //LEFT LANE
        public Lane(string id, Point entryPoint, Point stopPoint, Point curveEnd, Point exitPoint)
        {
            this.Id = id;
            this.EntryPoint = entryPoint;
            this.StopPoint = stopPoint;
            this.curveEnd = curveEnd;
            this.ExitPoint = exitPoint;
            this.CreatePath("left");
            this.PreviousLanes = new List<Lane>();
            this.NextLanes = new List<Lane>();
        }

        //RIGHT LANE
        public Lane(string id, Point entryPoint, Point stopPoint, Point curveStart, Point curveEnd, Point exitPoint)
        {
            this.Id = id;
            this.EntryPoint = entryPoint;
            this.StopPoint = stopPoint;
            this.curveStart = curveStart;
            this.curveEnd = curveEnd;
            this.ExitPoint = exitPoint;
            this.CreatePath("right");
            this.PreviousLanes = new List<Lane>();
            this.NextLanes = new List<Lane>();
            //Create the car path from the given points
        }

        public List<Lane> NextLanes { get; set; }

        public List<Lane> PreviousLanes { get; set; }

        public string Id { get; set; }

        public Point EntryPoint { get; private set; }

        public Point ExitPoint { get; private set; }

        public Point StopPoint { get; private set; }

        public void CreatePath(String direction)
        {
            switch (direction)
            {
                case "left":
                    this.Road.Add(this.EntryPoint);
                    this.Road.Add(this.StopPoint);
                    this.Road.Add(this.curveEnd);
                    this.Road.Add(this.ExitPoint);
                    break;
                case "right":
                    this.Road.Add(this.EntryPoint);
                    this.Road.Add(this.StopPoint);
                    this.Road.Add(this.curveStart);
                    this.Road.Add(this.curveEnd);
                    this.Road.Add(this.ExitPoint);
                    break;
                case "straight":
                    this.Road.Add(this.EntryPoint);
                    this.Road.Add(this.StopPoint);
                    this.Road.Add(this.ExitPoint);
                    break;
            }
        }
    }
}