using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using TPWA.Interfaces;
using TPWA.Models;
using TPWA.Services;

namespace TPWA.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IBallService _ballService;
        private readonly DispatcherTimer _timer;
        private ObservableCollection<Ball> _balls = new ObservableCollection<Ball>();

        public MainViewModel()
        {
            IBallRepository ballRepository = new BallRepository(); // Instantiate the Data layer
            _ballService = new BallService(ballRepository); // Instantiate the Logic layer

            CreateRandomBallsCommand = new RelayCommand(CreateRandomBall);

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(30); // Update interval
            _timer.Tick += Timer_Tick;

            // Start timer when MainViewModel is created
            _timer.Start();

            // Create random balls on startup
            CreateRandomBalls();
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

        public void Timer_Tick(object sender, EventArgs e)
        {
            UpdateBallPositions();
        }

        private void UpdateBallPositions()
        {
            foreach (var ball in Balls)
            {
                ball.X += ball.VelocityX;
                ball.Y += ball.VelocityY;

                // Reflect the ball if it hits the edges
                if (ball.X < 0 || ball.X > CanvasWidth - ball.Diameter)
                {
                    ball.VelocityX = -ball.VelocityX;
                    ball.X += ball.VelocityX; // Move the ball away from the edge
                }
                if (ball.Y < 0 || ball.Y > CanvasHeight - ball.Diameter)
                {
                    ball.VelocityY = -ball.VelocityY;
                    ball.Y += ball.VelocityY;
                }
            }
            OnPropertyChanged(nameof(Balls)); // Notifyz of property change
        }
    }
}
