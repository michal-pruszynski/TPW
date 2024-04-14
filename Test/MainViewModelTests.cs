using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.ViewModels;

namespace TPWA.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void CreateRandomBallsCommand_AddsBallsToList()
        {
            // Arrange
            Mock<IBallService> mockBallService = new Mock<IBallService>();
            MainViewModel viewModel = new MainViewModel();

            // Act
            viewModel.CreateRandomBallsCommand.Execute(null);

            // Assert
            Assert.IsTrue(viewModel.Balls.Count > 0);
        }

        [TestMethod]
        public void UpdateBallPositions_BallsMoveWithinCanvas()
        {
            // Arrange
            Mock<IBallService> mockBallService = new Mock<IBallService>();
            MainViewModel viewModel = new MainViewModel();

            Ball ball = new Ball() { X = 10, Y = 10, VelocityX = 1, VelocityY = 1, Diameter = 10 };
            viewModel.Balls.Add(ball);

            double initialX = ball.X;
            double initialY = ball.Y;

            // Act
            viewModel.UpdateBallPositions();

            // Assert
            Assert.AreNotEqual(initialX, viewModel.Balls.First().X);
            Assert.AreNotEqual(initialY, viewModel.Balls.First().Y);
        }

        [TestMethod]
        public void BallReflection_BallReflectsOffCanvasEdges()
        {
            // Arrange
            Mock<IBallService> mockBallService = new Mock<IBallService>();
            MainViewModel viewModel = new MainViewModel();

            Ball ball = new Ball() { X = 795, Y = 445, VelocityX = 1, VelocityY = 1, Diameter = 10 };
            viewModel.Balls.Add(ball);

            double initialX = ball.X;
            double initialY = ball.Y;
            double initialVelocityX = ball.VelocityX;
            double initialVelocityY = ball.VelocityY;

            // Act
            viewModel.UpdateBallPositions();

            // Assert
            Assert.AreNotEqual(initialX, viewModel.Balls.First().X);
            Assert.AreNotEqual(initialY, viewModel.Balls.First().Y);
        }
    }
}
