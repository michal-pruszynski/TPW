﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPW.Interfaces;
using TPW.Models;

namespace TPW.Services
{
    public class BallService : IBallService
    {
        private readonly IBallRepository _ballRepository;
        private readonly Random _random = new Random();

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
                    Diameter = _random.Next(20, 50)
                };
                _ballRepository.AddBall(ball);
            }
        }

        public List<Ball> GetAllBalls()
        {
            return _ballRepository.GetAllBalls();
        }
    }
}