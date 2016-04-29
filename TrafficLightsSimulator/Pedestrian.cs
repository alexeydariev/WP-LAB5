using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    class Pedestrian : TrafficMember
    {
        public Pedestrian(int pedestrianID, List<Point> pedestrianPath)
        {
            this.PedestrianID = pedestrianID;
            this.Speed = 0;
            this.Position = pedestrianPath.First();
            this.CurrentDestination = pedestrianPath.Last();
        }

        public bool CanPass { get; set; }

        public Point StartPosition { get; set; }

        public Point CurrentDestination { get; set; }

        public int PedestrianID { get; set; }

        public Point Position { get; set; }

        public void Walk()
        {
            if (this.Position == this.StartPosition)
            {
                if (this.CanPass)
                {
                    this.Speed = 2;
                    if (this.Position.X < this.CurrentDestination.X)
                    {
                        this.Position = new Point(this.Position.X + this.Speed, this.Position.Y);
                    }
                    else if (this.Position.X > this.CurrentDestination.X)
                    {
                        this.Position = new Point(this.Position.X - this.Speed, this.Position.Y);
                    }
                    if (this.Position.Y < this.CurrentDestination.Y)
                    {
                        this.Position = new Point(this.Position.X, this.Position.Y + this.Speed);
                    }
                    else if (this.Position.Y > this.CurrentDestination.Y)
                    {
                        this.Position = new Point(this.Position.X, this.Position.Y - this.Speed);
                    }
                }
            }
        }

        public override void Draw(Graphics gr, ImageList il)
        {
            int radius = 4;
            base.Draw(gr, il);
            gr.FillEllipse(Brushes.Coral, new Rectangle(new Point(this.Position.X - radius, this.Position.Y - radius), new Size(radius * 2, radius * 2)));
        }
    }

    public class PedestrianStream
    {
        private Point startPedestrianLight;
        private Point endPedestrianLight;
        private List<Pedestrian> listOfPedestrians;

        public PedestrianStream(Point startPoint, Point endPoint, int numberOfPedestrians)
        {
            this.startPedestrianLight = startPoint;
            this.endPedestrianLight = endPoint;
            this.listOfPedestrians = new List<Pedestrian>();
            this.SetNumberOfPedestrians(numberOfPedestrians);
        }

        public void SetNumberOfPedestrians(int numberOfPedestrians)
        {
            this.listOfPedestrians.Clear();
            List<Point> pedestrianPath = new List<Point> { this.startPedestrianLight, this.endPedestrianLight };
            for (int i = 0; i < numberOfPedestrians; i++)
            {
                this.listOfPedestrians.Add(new Pedestrian(0, pedestrianPath));
            }
        }

        public void DrawAllPedestrians(Graphics gr, ImageList il)
        {
            foreach (Pedestrian ped in this.listOfPedestrians)
            {
                ped.Draw(gr, il);
            }
        }
    }

    public class PedestrianTrafficLight : TrafficLight
    {
        public PedestrianTrafficLight(Point pos) : base(pos)
        {
        }
    }
}