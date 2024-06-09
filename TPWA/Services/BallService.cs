using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.Data;

namespace TPWA.Services
{
    public class BallService : IBallService
    {
        private readonly Random _random = new Random();
        private readonly ConcurrentDictionary<int, Ball> _balls = new ConcurrentDictionary<int, Ball>();
        private readonly IBallRepository _ballRepository;
        private readonly DiagnosticsLogger _logger;
        private int _nextBallId = 1;

        public BallService(IBallRepository ballRepository, DiagnosticsLogger logger)
        {
            _ballRepository = ballRepository;
            _logger = logger;
        }

        public void CreateRandomBalls(int count, double canvasWidth, double canvasHeight)
        {
            for (int i = 0; i < count; i++)
            {
                var ball = new Ball
                {
                    Id = _nextBallId++,
                    X = _random.NextDouble() * (canvasWidth - 50),
                    Y = _random.NextDouble() * (canvasHeight - 50),
                    Diameter = _random.Next(30, 45),
                    VelocityX = _random.NextDouble() * 2 - 1, // Random velocity between -1 and 1
                    VelocityY = _random.NextDouble() * 2 - 1
                };
                _balls.TryAdd(ball.Id, ball);
            }
        }

        public List<Ball> GetAllBalls()
        {
            return _balls.Values.ToList();
        }

        public async Task UpdateBallPositionsAsync(double canvasWidth, double canvasHeight)
        {
            var tasks = _balls.Values.Select(ball => Task.Run(() =>
            {
                ball.PreviousVelocityX = ball.VelocityX;
                ball.PreviousVelocityY = ball.VelocityY;

                // Update ball position based on current velocity
                ball.X += ball.VelocityX;
                ball.Y += ball.VelocityY;

                // Check for collision with walls and adjust velocity if necessary
                AdjustVelocityForWallCollision(ball, canvasWidth, canvasHeight);

                // Check for collision with other balls and adjust velocity if necessary
                AdjustVelocityForBallCollision(ball);

                // Log the ball's position
                _logger.Log($"Ball {ball.Id} position: ({ball.X}, {ball.Y})");
            }));

            await Task.WhenAll(tasks);
        }

        public void AdjustVelocityForBallCollision(Ball ball)
        {
            foreach (var otherBall in _balls.Values)
            {
                if (ball != otherBall && IsCollision(ball, otherBall))
                {
                    double dx = otherBall.X - ball.X;
                    double dy = otherBall.Y - ball.Y;
                    double distance = Math.Sqrt(dx * dx + dy * dy);
                    double nx = dx / distance;
                    double ny = dy / distance;

                    double dvx = otherBall.VelocityX - ball.VelocityX;
                    double dvy = otherBall.VelocityY - ball.VelocityY;

                    double impact = 2.0 * (dvx * nx + dvy * ny) / (ball.Diameter + otherBall.Diameter);

                    ball.VelocityX += impact * otherBall.Diameter * nx;
                    ball.VelocityY += impact * otherBall.Diameter * ny;
                    otherBall.VelocityX -= impact * ball.Diameter * nx;
                    otherBall.VelocityY -= impact * ball.Diameter * ny;
                }
            }
        }

        public void AdjustVelocityForWallCollision(Ball ball, double canvasWidth, double canvasHeight)
        {
            if (ball.X - ball.Diameter < 0 || ball.X + ball.Diameter > canvasWidth)
            {
                ball.VelocityX = -ball.VelocityX;
            }

            if (ball.Y - ball.Diameter < 0 || ball.Y + ball.Diameter > canvasHeight)
            {
                ball.VelocityY = -ball.VelocityY;
            }
        }

        private bool IsCollision(Ball ball1, Ball ball2)
        {
            double dx = ball1.X - ball2.X;
            double dy = ball1.Y - ball2.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);
            return distance < ((ball1.Diameter / 2) + (ball2.Diameter / 2));
        }
    }
}
