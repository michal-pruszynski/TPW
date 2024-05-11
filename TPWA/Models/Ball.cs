using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWA.ViewModels;

namespace TPWA.Models
{
    public class Ball : ViewModelBase
    {
        private double _x;
        private double _y;
        private double _velocityX;
        private double _velocityY;
        private double _diameter;
        private double _mass;
        private double _velocityPX;
        private double _velocityPY;
        public double X
        {
            get { return _x; }
            set { _x = value; OnPropertyChanged(); }
        }
        public double Y
        {
            get { return _y; }
            set { _y = value; OnPropertyChanged(); }
        }

        public double Mass
        {
            get { return _mass; }
            set { _mass = value; OnPropertyChanged(); }
        }
        public double PreviousVelocityX
        {
            get { return _velocityPX; }
            set { _velocityPX = value; OnPropertyChanged(); }
        }
        public double PreviousVelocityY
        {
            get { return _velocityPY; }
            set { _velocityPY = value; OnPropertyChanged(); }
        }

        public double VelocityX
        {
            get { return _velocityX; }
            set { _velocityX = value; OnPropertyChanged(); }
        }

        public double VelocityY
        {
            get { return _velocityY; }
            set { _velocityY = value; OnPropertyChanged(); }
        }
        public double Diameter
        {
            get { return _diameter; }
            set { _diameter = value; OnPropertyChanged(); }
        }
    }
}

