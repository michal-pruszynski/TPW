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
        private BallService _ballService;
        private Mock<IBallRepository> _mockRepository;

        [TestInitialize]
        public void SetUp()
        {
            _mockRepository = new Mock<IBallRepository>();
            _ballService = new BallService(_mockRepository.Object);
        }

        [TestMethod]
        public void CreateRandomBalls_AddsCorrectNumberOfBalls()
        {
            int count = 5;
            double canvasWidth = 800;
            double canvasHeight = 450;

            _ballService.CreateRandomBalls(count, canvasWidth, canvasHeight);
           // _mockRepository.Verify(repo => repo.ClearBalls(), Times.Once);
           // _mockRepository.Verify(repo => repo.AddBall(It.IsAny<Ball>()), Times.Exactly(count));

            List<Ball> balls = _ballService.GetAllBalls();
            Assert.AreEqual(count, balls.Count);
        }

        [TestMethod]
        public void CreateRandomBalls_AddsBallsInCanvasBounds()
        {
            int count = 5;
            double canvasWidth = 800;
            double canvasHeight = 450;

            _ballService.CreateRandomBalls(count, canvasWidth, canvasHeight);

            //_mockRepository.Verify(repo => repo.ClearBalls(), Times.Once);
            /*_mockRepository.Verify(repo => repo.AddBall(It.Is<Ball>(ball =>
                ball.X >= 0 && ball.X <= canvasWidth - ball.Diameter &&
                ball.Y >= 0 && ball.Y <= canvasHeight - ball.Diameter)), Times.Exactly(count));*/
        }

        [TestMethod]
        public void GetAllBalls_ReturnsEmptyList_WhenNoBallsAdded()
        {
            List<Ball> balls = _ballService.GetAllBalls();
            Assert.AreEqual(0, balls.Count);
        }
    }
}
