using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;
using TPWA.Data;
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
            IBallRepository ballRepository = new BallRepository();
            _ballService = new BallService(ballRepository); 

            CreateRandomBallsCommand = new RelayCommand(CreateRandomBalls);

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(30); // Update interval
            _timer.Tick += Timer_Tick;
            _timer.Start();
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

        private void CreateRandomBalls()
        {
            Balls.Clear();
            _ballService.CreateRandomBalls(2, CanvasWidth, CanvasHeight);
            var balls = _ballService.GetAllBalls();
            foreach (var ball in balls)
            {
                Balls.Add(ball);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateBallPositions();
        }

        public void UpdateBallPositions()
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
                    ball.Y += ball.VelocityY; // Move the ball away from the edge
                }
            }
            OnPropertyChanged(nameof(Balls));
        }
    }
}
