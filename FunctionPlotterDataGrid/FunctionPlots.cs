using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionPlotterDataGrid
{
    internal static class ImplicitFunctionPlot
    {
        private static double F(double x)
        {
            return Math.Exp(-2 * x) * Math.Pow(Math.Sin(x), 2);
        }
        public static List<double[]> PlotPoints(double xLow, double xHigh, int pointNumber)
        {
            var points = new List<double[]>();
            var h = (xHigh - xLow)/pointNumber;
            for (var x = xLow; x <= xHigh; x += h )
            {
                points.Add(new [] {x, F(x)});
            }
            return points;
        }
    }

    internal static class ParametricFunctionPlot
    {
        private static double Y(double t)
        {
            var val = Math.Pow(Math.Abs(1.0 - t), 1.0 / 3.0);
            if (1 - t < 0)
                return -val;
            return val;
        }
        private static double X(double t)
        {
            var val =  Math.Pow(Math.Abs(t), 1.0 / 3.0);
            if (t < 0)
                return -val;
            return val;

        }
        public static List<double[]> PlotPoints(double xLow, double xHigh, int pointNumber)
        {
            var points = new List<double[]>();
            var h = (xHigh - xLow) / pointNumber;
            for (var x = xLow; x <= xHigh; x += h)
            {
                points.Add(new[] { X(x), Y(x) });
            }
            return points;
        }
    }
}
