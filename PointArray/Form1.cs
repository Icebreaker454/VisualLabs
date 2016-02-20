using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace VPLab2
{
    public partial class Form1 : Form
    {
        private readonly PointArray _pointArray;

        public Form1()
        {
            InitializeComponent();
            _pointArray = new PointArray();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            drawingArea.MouseClick += DrawPoints;
            drawingArea.Paint += drawingArea_Paint;
        }

        private void DrawPoints(object sender, MouseEventArgs e)
        {

            var pt = new Point(e.X - 5, e.Y - 5);
            var fl = true;
            foreach (var pt2 in _pointArray.PtArray.ToArray().Cast<Point>().Where(pt2 => (Math.Pow(pt.X - pt2.X, 2) + Math.Pow(pt.Y - pt2.Y, 2)) < 100))
            {
                _pointArray.PtArray.Remove(pt2);
                fl = false;
                break;
            }

            if (fl)
            {
                _pointArray.PtArray.Add(pt);
            }

            drawingArea.Invalidate();
        }

        private void drawingArea_Paint(object sender, PaintEventArgs e)
        {   
            using (var g = e.Graphics)
            {
                _pointArray.Draw(g);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _pointArray.PtArray.Clear();
            drawingArea.Invalidate();
        }
    }
}
