using System.Collections;
using System.Drawing;
using System.Linq;

namespace VPLab2
{
    internal class PointArray
    {
        public ArrayList PtArray;

        private Pen _pen;
        private readonly SolidBrush _basicBrush;
        private readonly SolidBrush _highlightBrush;

        public PointArray()
        {
            PtArray = new ArrayList();

            _pen = new Pen(Color.Black);
            _basicBrush = new SolidBrush(Color.DarkCyan);
            _highlightBrush = new SolidBrush(Color.Chocolate);
        }

        private bool IsHighlited(Point pt)
        {

            /* Assert if point is outside all point triangles */
            return PtArray.Count >= 4 && PtArray.Cast<Point>().Any(
                    pt1 => PtArray.Cast<Point>().Any(
                        pt2 => (from Point pt3 in PtArray where pt1 != pt2 && pt2 != pt3 && pt != pt1 && pt != pt2 && pt != pt3 select PointInTriangle(pt, pt1, pt2, pt3)).Any(
                            result => result)));
        }

        private static float Sign(Point p1, Point p2, Point p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }

        private static bool PointInTriangle(Point pt, Point v1, Point v2, Point v3)
        {
            var b1 = Sign(pt, v1, v2) < 0.0f;
            var b2 = Sign(pt, v2, v3) < 0.0f;
            var b3 = Sign(pt, v3, v1) < 0.0f;

            return ((b1 == b2) && (b2 == b3));
        }

        public void Draw(Graphics g)
        {
            foreach (Point pt in PtArray)
            {
                g.FillEllipse(
                    IsHighlited(pt)? _highlightBrush : _basicBrush,
                    pt.X,
                    pt.Y,
                    10,
                    10
                );
            }
        }
    }
}
