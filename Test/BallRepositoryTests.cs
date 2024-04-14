using Microsoft.VisualStudio.TestTools.UnitTesting;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.Services;
using System.Collections.Generic;


namespace TPWA.Tests
{
    [TestClass]
    public class BallRepositoryTests
    {
        private BallRepository _ballRepository;

        [TestInitialize]
        public void SetUp()
        {
            _ballRepository = new BallRepository();
        }

        [TestMethod]
        public void AddBall_AddsBallToRepository()
        {
            Ball ball = new Ball { X = 100, Y = 200, Diameter = 20 };

            _ballRepository.AddBall(ball);
            List<Ball> balls = _ballRepository.GetBalls();

            CollectionAssert.Contains(balls, ball);
        }

        [TestMethod]
        public void ClearBalls_RemovesAllBallsFromRepository()
        {
            Ball ball1 = new Ball { X = 100, Y = 200, Diameter = 20 };
            Ball ball2 = new Ball { X = 300, Y = 400, Diameter = 20 };
            _ballRepository.AddBall(ball1);
            _ballRepository.AddBall(ball2);
            _ballRepository.ClearBalls();
            List<Ball> balls = _ballRepository.GetBalls();

            CollectionAssert.DoesNotContain(balls, ball1);
            CollectionAssert.DoesNotContain(balls, ball2);
        }

        [TestMethod]
        public void GetAllBalls_ReturnsAllBallsInRepository()
        {
            Ball ball1 = new Ball { X = 100, Y = 200, Diameter = 20 };
            Ball ball2 = new Ball { X = 300, Y = 400, Diameter = 20 };
            _ballRepository.AddBall(ball1);
            _ballRepository.AddBall(ball2);
            List<Ball> balls = _ballRepository.GetBalls();

            Assert.AreEqual(2, balls.Count);
            CollectionAssert.Contains(balls, ball1);
            CollectionAssert.Contains(balls, ball2);
        }
    }
}

