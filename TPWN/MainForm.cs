using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPW.Dane;
using TPW.Interfaces;
using TPW.Models;
using TPW.Services;

namespace TPW.Forms
{
    public partial class MainForm : Form
    {
        private readonly IBallService _ballService;
        private const int CanvasWidth = 800;
        private const int CanvasHeight = 450;
        private Timer timer;

        public MainForm()
        {
            InitializeComponent();
            IBallRepository ballRepository = new BallRepository();
            _ballService = new BallService(ballRepository);
            CreateRandomBalls(5); //Create some balls initially
            DisplayBalls();
            StartTimer();
        }

        private void CreateRandomBalls(int count)
        {
            _ballService.CreateRandomBalls(count, canvasPanel.Width, canvasPanel.Height);
        }

        private void DisplayBalls()
        {
            var balls = _ballService.GetAllBalls();
            foreach (var ball in balls)
            {
                DrawBall(ball);
            }
        }

        private void DrawBall(Ball ball)
        {
            // Here you can draw the ball on the form
            // This is a simple example, adjust as needed
            var circle = new CirclePictureBox
            {
                Location = new System.Drawing.Point((int)ball.X, (int)ball.Y),
                Size = new System.Drawing.Size((int)ball.Diameter, (int)ball.Diameter),
                BackColor = System.Drawing.Color.Blue,
                BorderStyle = BorderStyle.FixedSingle // Add border for visibility
            };

            circle.Tag = ball; // Store the ball object as a tag
            canvasPanel.Controls.Add(circle);
        }

        private void StartTimer()
        {
            timer = new Timer();
            timer.Interval = 20; // Adjust speed here (milliseconds)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MoveBalls();
        }

        private void MoveBalls()
        {
            var balls = _ballService.GetAllBalls();
            foreach (var ball in balls)
            {
                ball.X += ball.VelocityX;
                ball.Y += ball.VelocityY;

                // Check for collisions with walls
                if (ball.X < 0 || ball.X + ball.Diameter > canvasPanel.Width)
                {
                    ball.VelocityX *= -1; // Reverse velocity on collision with left or right walls
                }
                if (ball.Y < 0 || ball.Y + ball.Diameter > canvasPanel.Height)
                {
                    ball.VelocityY *= -1; // Reverse velocity on collision with top or bottom walls
                }

                UpdateBallPosition(ball);
            }
        }

        private void UpdateBallPosition(Ball ball)
        {
            // Update the position of the ball on the form
            foreach (Control control in canvasPanel.Controls)
            {
                if (control is CirclePictureBox circle && circle.Tag == ball)
                {
                    circle.Location = new System.Drawing.Point((int)ball.X, (int)ball.Y);
                    break;
                }
            }
        }
        private void addButton_Click_Click(object sender, EventArgs e)
        {
            CreateRandomBalls(1);
            DisplayBalls();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
