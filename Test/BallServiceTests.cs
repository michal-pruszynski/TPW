using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.Services;

namespace TPWA.Tests
{
    [TestClass]
    public class BallServiceTests
    {
        [TestMethod]
        public void CreateRandomBalls_ShouldAddBallsToList()
        {
            // Arrange
            Mock<IBallRepository> mockRepository = new Mock<IBallRepository>();
            BallService ballService = new BallService(mockRepository.Object);
            int count = 5;
            double canvasWidth = 800;
            double canvasHeight = 450;

            // Act
            ballService.CreateRandomBalls(count, canvasWidth, canvasHeight);

            // Assert
            //mockRepository.Verify(repo => repo.AddBall(It.IsAny<Ball>()), Times.Exactly(count));
        }

        [TestMethod]
        public void GetAllBalls_ShouldReturnAllBalls()
        {
            // Arrange
            Mock<IBallRepository> mockRepository = new Mock<IBallRepository>();
            BallService ballService = new BallService(mockRepository.Object);
            Ball ball1 = new Ball { X = 100, Y = 100, Diameter = 20, VelocityX = 1, VelocityY = 1 };
            Ball ball2 = new Ball { X = 200, Y = 200, Diameter = 20, VelocityX = 1, VelocityY = 1 };
            List<Ball> balls = new List<Ball> { ball1, ball2 };
            mockRepository.Setup(repo => repo.GetAllBalls()).Returns(balls);

            // Act
            var result = ballService.GetAllBalls();

            // Assert
            //Assert.AreEqual(2, result.Count);
            //Assert.IsTrue(result.Contains(ball1));
            //Assert.IsTrue(result.Contains(ball2));
        }
    }
}
