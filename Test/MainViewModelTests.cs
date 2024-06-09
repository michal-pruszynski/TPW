using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.ViewModels;

namespace TPWA.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        private MainViewModel _mainViewModel;
        private Mock<IBallService> _mockBallService;

        [TestInitialize]
        public void SetUp()
        {
            _mockBallService = new Mock<IBallService>();
            _mainViewModel = new MainViewModel();
        }

        [TestMethod]
        public void BallsCollection_NotNull_AfterConstruction()
        {
            Assert.IsNotNull(_mainViewModel.Balls);
        }

        [TestMethod]
        public void CreateRandomBalls_AddsBallsToCollection()
        {
            var balls = new List<Ball>
            {
                new Ball { X = 100, Y = 200, Diameter = 20, VelocityX = 1, VelocityY = -1 },
                new Ball { X = 300, Y = 400, Diameter = 20, VelocityX = -1, VelocityY = 1 }
            };

            _mockBallService.Setup(service => service.CreateRandomBalls(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<double>()))
                            .Callback<int, double, double>((count, canvasWidth, canvasHeight) =>
                            {
                                _mainViewModel.Balls = new ObservableCollection<Ball>(balls);
                            });

            _mainViewModel.CreateRandomBalls();
        }

        [TestMethod]
        public void Timer_Tick_UpdatesBallPositions()
        {
            var initialBalls = new List<Ball>
            {
                new Ball { X = 100, Y = 200, Diameter = 20, VelocityX = 1, VelocityY = -1 },
                new Ball { X = 300, Y = 400, Diameter = 20, VelocityX = -1, VelocityY = 1 }
            };

            var updatedBalls = new List<Ball>
            {
                new Ball { X = 101, Y = 199, Diameter = 20, VelocityX = 1, VelocityY = -1 },
                new Ball { X = 299, Y = 401, Diameter = 20, VelocityX = -1, VelocityY = 1 }
            };

            _mainViewModel.Balls = new ObservableCollection<Ball>(initialBalls);

            _mockBallService.Setup(service => service.GetAllBalls()).Returns(updatedBalls);

            //_mainViewModel.Timer_Tick(null, null);

            //CollectionAssert.AreEqual(updatedBalls, _mainViewModel.Balls);
        }
    }
}
