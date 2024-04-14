using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPW.Models
{
    public class Ball
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Diameter { get; set; }

        // Velocity along X and Y axes
        public double VelocityX { get; set; }
        public double VelocityY { get; set; }
    }
}
