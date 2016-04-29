using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    public class Car : TrafficMember
    {
        private int radius;

        public Car(int carId, List<Point> carRoad)
        {
            this.CarId = carId;
            this.Position = carRoad.First();
            this.CarRoad = carRoad;
            this.CurrentDestination = this.CarRoad.First();
            this.CanPass = true;
            this.radius = 8;
        }

        public delegate void CheckColorOfTrafficLight(Car car);

        public Crossing CurrentCrossing { get; set; }

        public List<Point> CarRoad { get; set; }

        public Point CurrentDestination { get; set; }

        public Point NextDestination { get; set; }

        public bool CanPass { get; set; }

        public int CarId { get; set; }

        public Point Position { get; set; }

        public override void Draw(Graphics gr, ImageList il)
        {
            int dia = this.radius * 2;
            base.Draw(gr, il);
            gr.FillEllipse(Brushes.DarkCyan, new Rectangle(new Point(this.Position.X - this.radius, this.Position.Y - this.radius), new Size(dia, dia)));
        }
       
        public void SetNextDestination()
        {
            for (int i = 0; i < this.CarRoad.Count - 1; i++)
            {
                if (this.CarRoad[i] == this.CurrentDestination)
                {
                    this.NextDestination = this.CarRoad[i + 1];
                    break;
                }
            }
        }

        public void Drive(Point destination)
        {
            bool destinationReached = true;
            this.CurrentDestination = destination;
            this.Speed = 1;
            if (this.Position.X < this.CurrentDestination.X)
            {
                this.Position = new Point(this.Position.X + this.Speed, this.Position.Y);
                destinationReached = false;
            }
            else if (this.Position.X > this.CurrentDestination.X)
            {
                this.Position = new Point(this.Position.X - this.Speed, this.Position.Y);
                destinationReached = false;
            }
            if (this.Position.Y < this.CurrentDestination.Y)
            {
                this.Position = new Point(this.Position.X, this.Position.Y + this.Speed);
                destinationReached = false;
            }
            else if (this.Position.Y > this.CurrentDestination.Y)
            {
                this.Position = new Point(this.Position.X, this.Position.Y - this.Speed);
                destinationReached = false;
            }
            if (destinationReached)
            {
                this.SetNextDestination(); 
            }
        }

        public void TurnLeft(Point destination)
        {
        }

        public void TurnRight(Point destination)
        {
        }

        public void Stop(Point stoppoint)
        {
        }
    }

    public class CarStream
    {
        private int id;
        private int nrCars;

        public List<Car> CarList { get; set; }

        public List<Point> Road { get; set; }

        public CarStream(int id, int nrCars, List<Point> road)
        {
            this.id = id;

            this.nrCars = nrCars;
            this.CarList = new List<Car>();
            this.Road = road;
            this.SetNumberOfCars(nrCars);
        }

        public void SetNumberOfCars(int numberOfCars)
        {
            this.CarList.Clear();
            for (int i = 0; i < this.nrCars; i++)
            {
                Car k = new Car(i, this.Road);
                this.CarList.Add(k);
            }
        }

        public void DriveAllCars()
        {
            foreach (Car car in this.CarList)
            {
                car.Drive(car.CurrentDestination);
                if (car.CarRoad.Contains(car.Position))
                {
                    List<Lane> lanesOfThisCrossing = car.CurrentCrossing.LisftOfLanes;
                    for (int i = 0; i < lanesOfThisCrossing.Count; i++)
                    {
                        if (lanesOfThisCrossing[i].StopPoint == car.Position)
                        {
                            foreach (TrafficLight tfl in car.CurrentCrossing.ListOfCarTrafficLights)
                            {
                                //lanes - the two string values from the traffic light ID,
                                //which are indexes of the lanes, which are stopping on this traffic light
                                string[] lanes = tfl.Id.Split();
                                //If there are 2 lanes for this traffic light (straight + right turn)

                                #region If straight+right turn and LightColor is Red

                                if (lanes.Length > 1)
                                {
                                    if (lanes[0] == i.ToString() ||
                                        lanes[1] == i.ToString())
                                    {
                                        if (tfl.LightColor == Color.Red)
                                        {
                                            car.CanPass = false;
                                            break;
                                        }
                                        else
                                        {
                                            car.CanPass = true;
                                            break;
                                        }
                                    }
                                }

                                #endregion

                                //If there are is 1 lane for this traffic light (left turn)

                                #region if left turn and LightColor is Red

                                else
                                {
                                    //If the current looped lane is going through this traffic light
                                    if (lanes[0] == i.ToString())
                                    {
                                        //If the lightcolour is red - don't allow cars to pass. 
                                        if (tfl.LightColor == Color.Red)
                                        {
                                            car.CanPass = false;
                                            break;
                                        }
                                        else
                                        {
                                            car.CanPass = true;
                                            break;
                                        }
                                    }
                                }

                                #endregion
                            }
                        }
                    }
                    if (car.CanPass)
                    {
                        car.CurrentDestination = car.NextDestination;
                        car.SetNextDestination();
                    }
                }
            }
        }

        public void DrawAllCars(Graphics gr, ImageList il)
        {
            foreach (Car car in this.CarList)
            {
                car.Draw(gr, il);
            }
        }

        public bool IsStopPoint(Point carPosition)
        {
            foreach (Point p in this.Road)
            {
                if (p == carPosition)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class CarTrafficLight : TrafficLight
    {
        public CarTrafficLight(string id, Point pos) : base(pos)
        {
            this.Id = id;
        }
    }
}