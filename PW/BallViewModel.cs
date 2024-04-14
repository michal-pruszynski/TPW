using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPW.Models;
using TPW.ViewModels;

namespace TPW.ViewModels
{
    public class BallViewModel : ViewModelBase
    {
        private readonly Ball _ball;

        public BallViewModel(Ball ball)
        {
            _ball = ball;
        }

        public double X
        {
            get => _ball.X;
            set
            {
                _ball.X = value;
                OnPropertyChanged();
            }
        }

        public double Y
        {
            get => _ball.Y;
            set
            {
                _ball.Y = value;
                OnPropertyChanged();
            }
        }

        public double Diameter => _ball.Diameter;
    }
}

