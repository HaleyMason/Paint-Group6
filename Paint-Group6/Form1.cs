using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Group6
{
    public partial class Form1 : Form
    {

        Graphics g;
        int x = -1;
        int y = -1;
        bool moving = false;
        Point lastPoint = Point.Empty;
        Pen pen;
        int eraserWidth = 10;


        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
            lastPoint = e.Location;
            panel1.Cursor = Cursors.Cross;

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                g.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
                g.DrawLine(pen, lastPoint, e.Location);
                lastPoint = e.Location;
            }


        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
        }

        private void btn_eraser_Click(object sender, EventArgs e)
        {
            pen.Color = Color.White;
            pen.Width = eraserWidth;
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}
