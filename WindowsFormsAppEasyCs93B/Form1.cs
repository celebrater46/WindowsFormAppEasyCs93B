using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppEasyCs93B
{
    public partial class Form1 : Form
    {
        private Ball bl;
        private Image im;
        private int dx, dy;
        private int t;
        public static string imgPath = "C:\\Users\\Enin\\RiderProjects\\WindowsFormsAppEasyCs92\\WindowsFormsAppEasyCs92\\img\\";
        
        public Form1()
        {
            InitializeComponent();
            this.Text = "Receive Apple";
            this.ClientSize = new Size(600, 300);
            this.DoubleBuffered = true;

            im = Image.FromFile(imgPath + "sky.bmp");
            bl = new Ball();

            Point p = new Point(0, 300);
            Color c = Color.White;
            dx = 0;
            dy = 0;
            t = 0;

            bl.Point = p;
            bl.Color = c;

            Timer tm = new Timer();
            tm.Interval = 100;
            tm.Start();

            this.Paint += new PaintEventHandler(FmPaint);
            tm.Tick += new EventHandler(TmTick);
        }

        public void FmPaint(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(im, 0, 0, im.Width, im.Height);

            Point p = bl.Point;
            Color c = bl.Color;
            SolidBrush br = new SolidBrush(c);
            
            g.FillEllipse(br, p.X, p.Y, 10, 10);
        }

        public void TmTick(Object sender, EventArgs e)
        {
            Point p = bl.Point;
            t++;

            if (p.X > this.ClientSize.Width)
            {
                dx = 0;
                dy = 0;
                t = 0;
                p.X = 0;
                p.Y = 300;
            }

            dx = (int) (80 * Math.Cos(Math.PI / 3));
            dy = (int) (80 * Math.Sin(Math.PI / 3) - 9.8 * t);
            p.X += dx;
            p.Y -= dy;
            bl.Point = p;
            this.Invalidate();
        }
    }
    
    class Ball
    {
        public Color Color;
        public Point Point;
        public Image Image;
    }
}