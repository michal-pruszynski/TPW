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
        private const int CanvasWidth = 800;  // Canvas width
        private const int CanvasHeight = 450; // Canvas height

        public MainForm()
        {
            InitializeComponent();
            IBallRepository ballRepository = new BallRepository(); // Instantiate the Data layer
            _ballService = new BallService(ballRepository); // Instantiate the Logic layer
            CreateRandomBalls(5); // Example: Create some balls initially
            DisplayBalls();
        }

        private void CreateRandomBalls(int count)
        {
            _ballService.CreateRandomBalls(count, CanvasWidth, CanvasHeight);
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

            canvasPanel.Controls.Add(circle);
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
