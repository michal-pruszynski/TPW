using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPW.Forms
{
    public class CirclePictureBox : PictureBox
    {
        public CirclePictureBox()
        {
            // Set the style to double-buffered to improve drawing performance
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var pen = new Pen(Color.Blue, 2)) // Change color and thickness as needed
            {
                var diameter = Math.Min(Width, Height);
                e.Graphics.DrawEllipse(pen, 0, 0, diameter, diameter);
            }
        }
    }
}
