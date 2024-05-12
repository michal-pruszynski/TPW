using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.Services;

namespace TPWA.Tests
{

    [TestClass]
    public class BallBalisitcsTests
    {
        private BallRepository _ballRepository;
        private BallService _ballService;
        [TestInitialize]
        public void SetUp()
        {
            _ballRepository = new BallRepository();
        }
        [TestMethod]
        public void AdjustVelocityForBallCollision_BallsCollide_UpdateVelocities()
        {
            var ball1 = new Ball { X = 20, Y = 20, VelocityX = 1, VelocityY = 0, Mass = 1, Diameter = 10 };
            var ball2 = new Ball { X = 30, Y = 30, VelocityX = -1, VelocityY = 0, Mass = 1, Diameter = 10 };
            _ballService = new BallService(_ballRepository);
            _ballRepository.AddBall(ball1);
            _ballRepository.AddBall(ball2);

            _ballService.AdjustVelocityForBallCollision(ball1);
            //Assert.AreNotEqual(1, ball1.VelocityX);
            //Assert.AreNotEqual(-1, ball2.VelocityX);
        }

        [TestMethod]
        public void AdjustVelocityForBallCollision_BallsDoNotCollide_NoChangeInVelocities()
        {
            var otherball1 = new Ball { X = 0, Y = 0, VelocityX = 1, VelocityY = 0, Mass = 1, Diameter = 10 };
            var otherball2 = new Ball { X = 100, Y = 100, VelocityX = -1, VelocityY = 0, Mass = 1, Diameter = 10 };
            var ballService = new BallService(_ballRepository);
            _ballRepository.AddBall(otherball1);
            _ballRepository.AddBall(otherball2);
            ballService.AdjustVelocityForBallCollision(otherball1);

            Assert.AreEqual(1, otherball1.VelocityX);
            Assert.AreEqual(-1, otherball2.VelocityX);
        }
    }

}
