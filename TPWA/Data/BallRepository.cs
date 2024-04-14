using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWA.Interfaces;
using TPWA.Models;

namespace TPWA.Data
{
    public class BallRepository : IBallRepository
    {
        private List<Ball> Balls { get; }

        public BallRepository()
        {
            Balls = new List<Ball>();
        }

        public List<Ball> GetAllBalls()
        {
            return Balls;
        }

        public void AddBall(Ball ball)
        {
            Balls.Add(ball);
        }

        public void RemoveBall(Ball ball)
        {
            Balls.Remove(ball);
        }
    }
}
