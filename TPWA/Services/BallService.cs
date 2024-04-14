using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPWA.Interfaces;
using TPWA.Models;

namespace TPWA.Services
{
    public class BallService : IBallService
    {
        private readonly Random _random = new Random();
        private readonly List<Ball> _balls = new List<Ball>();
        private readonly IBallRepository _ballRepository;

        public BallService(IBallRepository ballRepository)
        {
            _ballRepository = ballRepository;
        }

        public void CreateRandomBalls(int count, double canvasWidth, double canvasHeight)
        {
            for (int i = 0; i < count; i++)
            {
                var ball = new Ball
                {
                    X = _random.NextDouble() * canvasWidth,
                    Y = _random.NextDouble() * canvasHeight,
                    Diameter = _random.Next(20, 50),
                    VelocityX = _random.NextDouble() * 2 - 1, // Random velocity between -1 and 1
                    VelocityY = _random.NextDouble() * 2 - 1
                };
                _balls.Add(ball);
            }
        }

        public List<Ball> GetAllBalls()
        {
            return _balls;
        }
    }
}
