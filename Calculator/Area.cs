using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    public static class AnyArea
    {
        public static double Area(double d1, double d2, int angle)
        {
            return d1 * d2 * Math.Sin(angle * Math.PI / 180.0) / 2.0;
        }
    }

    public static class RectangleArea
    {
        public static double Area(double a, double b)
        {
            return a * b;
        }
    }

    public static class ParalellogramArea
    {
        public static double Area(double a, double b, int angle)
        {
            return a * b * Math.Sin(angle * Math.PI / 180.0);
        }
        public static double Area(double a, double h)
        {
            return a * h;
        }
        
    }

    public static class RhombArea
    {
        public static double Area(double d1, double d2)
        {
            return d1 * d2 / 2.0;
        }
    }

    public static class TrapezeArea
    {
        public static double Area(double a, double b, double h)
        {
            return (a + b) * h / 2.0;
        }
    }
}
