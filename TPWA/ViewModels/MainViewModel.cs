using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TPWA.Data;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.Services;

namespace TPWA.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IBallService _ballService;
        private ObservableCollection<Ball> _balls = new ObservableCollection<Ball>();

        public MainViewModel()
        {
            IBallRepository ballRepository = new BallRepository(); // Instantiate the Data layer if needed
            _ballService = new BallService(ballRepository); // Instantiate the Logic layer
            CreateRandomBallsCommand = new RelayCommand(CreateRandomBalls);
        }

        public ICommand CreateRandomBallsCommand { get; }

        public ObservableCollection<Ball> Balls
        {
            get { return _balls; }
            set
            {
                _balls = value;
                OnPropertyChanged(nameof(Balls));
            }
        }

        private void CreateRandomBalls()
        {
            Balls.Clear();
            _ballService.CreateRandomBalls(5, CanvasWidth, CanvasHeight);
            var balls = _ballService.GetAllBalls();
            foreach (var ball in balls)
            {
                Balls.Add(ball);
            }
        }

        private const double CanvasWidth = 800;  // Canvas width
        private const double CanvasHeight = 450; // Canvas height
    }
}
