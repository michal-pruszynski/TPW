using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.Services;
using TPWA.Data;

namespace TPWA.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IBallService _ballService;
        private ObservableCollection<Ball> _balls = new ObservableCollection<Ball>();

        public MainViewModel()
        {
            IBallRepository ballRepository = new BallRepository(); // Instantiate the Data layer
            DiagnosticsLogger logger = new DiagnosticsLogger("log.txt"); // Instantiate the Diagnostics logger
            _ballService = new BallService(ballRepository, logger); // Instantiate the Logic layer

            CreateRandomBallsCommand = new RelayCommand(CreateRandomBall);

            // Create random balls on startup
            CreateRandomBalls();
            StartUpdatingBalls();
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

        public double CanvasWidth { get; } = 800;
        public double CanvasHeight { get; } = 450;

        public void CreateRandomBalls()
        {
            Balls.Clear();
            _ballService.CreateRandomBalls(3, CanvasWidth, CanvasHeight);
            var balls = _ballService.GetAllBalls();
            foreach (var ball in balls)
            {
                Balls.Add(ball);
            }
        }
        private void CreateRandomBall()
        {
            _ballService.CreateRandomBalls(1, CanvasWidth, CanvasHeight);
            var balls = _ballService.GetAllBalls();
            foreach (var ball in balls)
            {
                Balls.Add(ball);
            }
        }
        private async void StartUpdatingBalls()
        {
            while (true)
            {
                await Task.Delay(30); // Update interval
                await _ballService.UpdateBallPositionsAsync(CanvasWidth, CanvasHeight);
                Application.Current.Dispatcher.Invoke(() => OnPropertyChanged(nameof(Balls)));
            }
        }
    }
}
