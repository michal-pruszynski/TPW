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
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Graphics g = pe.Graphics;
            using (Pen pen = new Pen(Color.Black, 2))
            {
                g.DrawEllipse(pen, 0, 0, Width - 1, Height - 1);
            }
        }
    }
}
