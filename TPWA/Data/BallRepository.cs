using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPWA.Interfaces;
using TPWA.Models;

namespace TPWA.Data
{
    public class BallRepository : IBallRepository
    {
        private List<Ball> _balls = new List<Ball>();

        public List<Ball> GetBalls()
        {
            return _balls;
        }

        public void AddBall(Ball ball)
        {
            _balls.Add(ball);
        }

        public void ClearBalls()
        {
            _balls.Clear();
        }

    }
}
