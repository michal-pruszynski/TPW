using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
                    X = _random.NextDouble() * (canvasWidth - 50),
                    Y = _random.NextDouble() * (canvasHeight - 50),
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
        public async Task UpdateBallPositionsAsync(double canvasWidth, double canvasHeight)
        {
            await Task.Run(() =>
            {
                foreach (var ball in _balls)
                {
                    // Save previous velocity
                    ball.PreviousVelocityX = ball.VelocityX;
                    ball.PreviousVelocityY = ball.VelocityY;

                    // Update ball position based on current velocity
                    ball.X += ball.VelocityX;
                    ball.Y += ball.VelocityY;

                    // Check for collision with walls and adjust velocity if necessary
                    AdjustVelocityForWallCollision(ball, canvasWidth, canvasHeight);

                    // Check for collision with other balls and adjust velocity if necessary
                    AdjustVelocityForBallCollision(ball);
                }
            });
        }
        private void AdjustVelocityForBallCollision(Ball ball)
        {
            foreach (var otherBall in _balls)
            {
                if (ball != otherBall && IsCollision(ball, otherBall))
                {

                    // Calculate the distance and direction between the two balls
                    double dx = otherBall.X - ball.X;
                    double dy = otherBall.Y - ball.Y;
                    double distance = Math.Sqrt(dx * dx + dy * dy);
                    double nx = dx / distance;
                    double ny = dy / distance;

                    // Calculate the relative velocity
                    double dvx = otherBall.VelocityX - ball.VelocityX;
                    double dvy = otherBall.VelocityY - ball.VelocityY;

                    // Calculate the impact factor
                    double impact = 2.0 * (dvx * nx + dvy * ny) / (ball.Diameter + otherBall.Diameter);

                    // Update the velocities of the balls
                    ball.VelocityX += impact * otherBall.Diameter * nx;
                    ball.VelocityY += impact * otherBall.Diameter * ny;
                    otherBall.VelocityX -= impact * ball.Diameter * nx;
                    otherBall.VelocityY -= impact * ball.Diameter * ny;

                }
            }
        }
        private void AdjustVelocityForWallCollision(Ball ball, double canvasWidth, double canvasHeight)
        {
            // Left and right wall
            if (ball.X - ball.Diameter < 0 || ball.X + ball.Diameter > canvasWidth)
            {
                ball.VelocityX = -ball.VelocityX;
            }

            // Up and down wall
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
            return distance < ((ball1.Diameter / 2) + (ball2.Diameter) / 2);
        }

    }
}
