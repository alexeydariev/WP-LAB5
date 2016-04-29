using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TrafficLight
{
    [Serializable]
    public class TrafficMember
    {
        //fields
        //prop
        public int Speed { get; set; }

        //METHODS
        public virtual void Draw(Graphics gr, ImageList il)
        {
        }
    }
}