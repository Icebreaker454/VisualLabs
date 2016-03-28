using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;

namespace FunctionPlotterDataGrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextBox[] rangeBoxes = {xLow, xHigh, yLow, yHigh, tLow, tHigh};
            foreach (var box in rangeBoxes)
            {
                box.KeyPress += Validators.DoubleInputValidator;
            }
            paramPoints.KeyPress += Validators.IntInputValidator;
            implicitPoints.KeyPress += Validators.IntInputValidator;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var points = new List<double[]>();
            switch (tabControl1.SelectedTab.Text)
            {
                case "Implicit Plot":
                    {
                        
                            points = ImplicitFunctionPlot.PlotPoints(
                                double.Parse(xLow.Text),
                                double.Parse(xHigh.Text),
                                int.Parse(implicitPoints.Text)
                                );
                            chart1.ChartAreas[0].AxisY.Title = "X";
                            chart1.ChartAreas[0].AxisX.Title = "Y";
                            chart1.ChartAreas[0].AxisX.Minimum = double.Parse(xLow.Text);
                            chart1.ChartAreas[0].AxisX.Maximum = double.Parse(xHigh.Text);
                            try
                            {
                            chart1.ChartAreas[0].AxisY.Minimum = double.Parse(yLow.Text);
                            chart1.ChartAreas[0].AxisY.Maximum = double.Parse(yHigh.Text);
                            }
                            catch
                            {
                                var y_max = points.Aggregate((curMin, x) => (curMin == null || x[1] > curMin[1] ? x : curMin))[1];
                                var y_min = points.Aggregate((curMin, x) => (curMin == null || x[1] < curMin[1] ? x : curMin))[1];

                                chart1.ChartAreas[0].AxisY.Minimum = y_min * 0.85;
                                chart1.ChartAreas[0].AxisY.Maximum = y_max * 1.15;
                            }
                        
                    } break;
                case "Parametric Plot":
                    {
                        try
                        {
                            points = ParametricFunctionPlot.PlotPoints(
                                double.Parse(tLow.Text),
                                double.Parse(tHigh.Text),
                                int.Parse(paramPoints.Text)
                                );
                            chart1.ChartAreas[0].AxisY.Title = "X(t)";
                            chart1.ChartAreas[0].AxisX.Title = "Y(t)";

                            var y_max = points.Aggregate((curMin, x) => (curMin == null || x[1] > curMin[1] ? x : curMin))[1];
                            var y_min = points.Aggregate((curMin, x) => (curMin == null || x[1] < curMin[1] ? x : curMin))[1];

                            var x_max = points.Aggregate((curMin, x) => (curMin == null || x[0] > curMin[0] ? x : curMin))[0];
                            var x_min = points.Aggregate((curMin, x) => (curMin == null || x[0] < curMin[0] ? x : curMin))[0];

                            chart1.ChartAreas[0].AxisY.Minimum = y_min * 0.85;
                            chart1.ChartAreas[0].AxisY.Maximum = y_max * 1.15;

                            chart1.ChartAreas[0].AxisX.Minimum = x_min * 0.85;
                            chart1.ChartAreas[0].AxisX.Maximum = x_max * 1.15;

                        }
                        catch
                        {
                        }
                    } break;
            }
            dataGridView1.DataSource = points.Select(x => new { X = x[0], Y = x[1] }).ToList();
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].IsXValueIndexed = false;
          
            chart1.Series[0].Points.Clear();
            foreach (var element in points)
            {
                chart1.Series[0].Points.Add(new DataPoint(element[0], element[1]));
            }
        }
    }
}
