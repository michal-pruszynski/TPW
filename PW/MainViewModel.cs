using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using TPW.Models;

namespace TPW.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly Random _random = new Random();
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        public ObservableCollection<BallViewModel> Balls { get; } = new ObservableCollection<BallViewModel>();

        public MainViewModel()
        {
            _timer.Interval = TimeSpan.FromMilliseconds(50);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var ball in Balls)
            {
                // Move each ball randomly
                ball.X += _random.Next(-5, 6); // Random X movement
                ball.Y += _random.Next(-5, 6); // Random Y movement

                // Ensure the ball stays within the canvas bounds
                ball.X = Math.Max(0, Math.Min(ball.X, 800 - ball.Diameter)); // Canvas Width is 800
                ball.Y = Math.Max(0, Math.Min(ball.Y, 450 - ball.Diameter)); // Canvas Height is 450
            }
        }

        public ICommand AddBallCommand => new RelayCommand(AddBall);

        private void AddBall(object parameter)
        {
            var newBall = new Ball
            {
                X = _random.Next(0, 800), // Canvas Width is 800
                Y = _random.Next(0, 450), // Canvas Height is 450
                Diameter = _random.Next(20, 50) // Random Diameter
            };
            Balls.Add(new BallViewModel(newBall));
        }
    }
}
