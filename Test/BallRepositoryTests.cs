using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPWA.Data;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.Services;

namespace TPWA.Tests
{
    [TestClass]
    public class BallRepositoryTests
    {
        [TestMethod]
        public void AddBall_ShouldAddBallToList()
        {
            // Arrange
            IBallRepository ballRepository = new BallRepository();
            Ball ball = new Ball { X = 100, Y = 100, Diameter = 20, VelocityX = 1, VelocityY = 1 };

            // Act
            ballRepository.AddBall(ball);

            // Assert
            var balls = ballRepository.GetAllBalls();
            Assert.IsTrue(balls.Contains(ball));
        }

        [TestMethod]
        public void GetAllBalls_ShouldReturnAllBalls()
        {
            // Arrange
            IBallRepository ballRepository = new BallRepository();
            Ball ball1 = new Ball { X = 100, Y = 100, Diameter = 20, VelocityX = 1, VelocityY = 1 };
            Ball ball2 = new Ball { X = 200, Y = 200, Diameter = 20, VelocityX = 1, VelocityY = 1 };
            ballRepository.AddBall(ball1);
            ballRepository.AddBall(ball2);

            // Act
            var balls = ballRepository.GetAllBalls();

            // Assert
            Assert.AreEqual(2, balls.Count);
            Assert.IsTrue(balls.Contains(ball1));
            Assert.IsTrue(balls.Contains(ball2));
        }
    }
}
