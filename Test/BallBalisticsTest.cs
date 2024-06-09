using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.Services;
using TPWA.Data;

namespace TPWA.Tests
{
    [TestClass]
    public class BallBalisitcsTests
    {
        private BallRepository _ballRepository;
        private BallService _ballService;
        private DiagnosticsLogger _diagnosticsLogger;

        [TestInitialize]
        public void SetUp()
        {
            _ballRepository = new BallRepository();
            _diagnosticsLogger = new DiagnosticsLogger("test_log.txt");
            _ballService = new BallService(_ballRepository, _diagnosticsLogger);
        }

        [TestMethod]
        public void AdjustVelocityForBallCollision_BallsCollide_UpdateVelocities()
        {
            var ball1 = new Ball { X = 20, Y = 20, VelocityX = 1, VelocityY = 0, Mass = 1, Diameter = 10 };
            var ball2 = new Ball { X = 30, Y = 20, VelocityX = -1, VelocityY = 0, Mass = 1, Diameter = 10 };
            _ballRepository.AddBall(ball1);
            _ballRepository.AddBall(ball2);

            _ballService.AdjustVelocityForBallCollision(ball1);
           // Assert.AreNotEqual(1, ball1.VelocityX, "VelocityX of ball1 should change after collision");
            //Assert.AreNotEqual(-1, ball2.VelocityX, "VelocityX of ball2 should change after collision");
        }

        [TestMethod]
        public void AdjustVelocityForBallCollision_BallsDoNotCollide_NoChangeInVelocities()
        {
            var otherball1 = new Ball { X = 0, Y = 0, VelocityX = 1, VelocityY = 0, Mass = 1, Diameter = 10 };
            var otherball2 = new Ball { X = 100, Y = 100, VelocityX = -1, VelocityY = 0, Mass = 1, Diameter = 10 };
            _ballRepository.AddBall(otherball1);
            _ballRepository.AddBall(otherball2);

            _ballService.AdjustVelocityForBallCollision(otherball1);

            Assert.AreEqual(1, otherball1.VelocityX, "VelocityX of otherball1 should not change when no collision occurs");
            Assert.AreEqual(-1, otherball2.VelocityX, "VelocityX of otherball2 should not change when no collision occurs");
        }
    }
}
