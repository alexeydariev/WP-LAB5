using System;
using System.Drawing;
using System.Linq;

namespace TrafficLight
{
    [Serializable]
    public abstract class TrafficLight
    {
        public TrafficLight(Point pos)
        {
            //this.id = id;
            this.Pos = pos;
            this.Radius = 6;
            this.LightColor = Color.Red;
        }
        
        public string Id { get; set; }

        public Point Pos { get; set; }

        public Color LightColor { get; set; }

        public int Radius { get; set; }

        public virtual void SetTrafficLight(Color c)
        {
            this.LightColor = c;
        }
    }
}
