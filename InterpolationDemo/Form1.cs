using ScottPlot;
using NCalc;
using System.Diagnostics;
using ScottPlot.Plottables;
using static System.Runtime.InteropServices.JavaScript.JSType;
using NumericalMethods;
using Point = NumericalMethods.Point;
namespace InterpolationDemo
{
    public partial class Form1 : Form
    {
        ScottPlot.Plottables.Scatter lagrangeLine;
        ScottPlot.Plottables.Scatter points;
        ScottPlot.Plottables.Scatter splineLine;
        ScottPlot.Plottables.Scatter partLinear;
        public Form1()
        {

            InitializeComponent();

            Point[] f = {
                new Point(0,1),
                new Point(4,3),
                new Point(7,7),
                new Point(10,5),
                new Point(12,6)};


            graph.Plot.Add.HorizontalLine(0, color: ScottPlot.Color.FromHex("#000000"));
            graph.Plot.Add.VerticalLine(0, color: ScottPlot.Color.FromHex("#000000"));

            CreateGraphs(f);

        }

        private void CreateGraphs(Point[] data_points)
        {
            GetXYArrayLagrange(data_points, out double[] x_arr, out double[] y_arr_langrange);
            lagrangeLine = graph.Plot.Add.ScatterLine(x_arr, y_arr_langrange, color: ScottPlot.Color.FromHex("#008000"));

            GetXYArrayPoints(data_points, out double[] x_points, out double[] y_points);

            var spline = new Spline(x_points, y_points, double.Parse(SpoxX0.Text), double.Parse(SpoxXn.Text), double.Parse(h_textbox.Text));
            var str_spline = spline.SolveString();
            spline.SolveY(out double[] x_values, out double[] y_values_spline);
            splineLine = graph.Plot.Add.ScatterLine(x_values, y_values_spline, color: ScottPlot.Color.FromHex("#ffd800"));
            splineLine.LineWidth = 2;
            lagrangeLine.LineWidth = 2;
            points = graph.Plot.Add.ScatterPoints(x_points, y_points, color: ScottPlot.Color.FromHex("#FF0000"));
            graph.Plot.Title("Сплайн - Жовтий / Лагранж - Зелений / Вузлові точки - Червоний");
            points.MarkerSize = 10;
            graph.Plot.XLabel("X");
            graph.Plot.YLabel("Y");

            diff_plot.Plot.Title("Графік різниці функцій");
            string langr = Lagrange.LangrangeString(data_points, data_points.Length);

            DiferentPlot(x_arr, y_arr_langrange, y_values_spline);
            PrintFormulas(str_spline, langr);

            diff_plot.Refresh();
            graph.Refresh();

        }

        private void PrintFormulas(Dictionary<string, string> splines, string lagrange)
        {
            lagrange_textbox.Text = lagrange;

            spline_textbox.Clear();

            foreach (var kvp in splines)
            {
                spline_textbox.Text += $"{kvp.Key}={kvp.Value}\n";
            }
        }

        public void DiferentPlot(double[] XiL, double[] YiL, double[] YiS)
        {
            var difX = new double[XiL.Length];
            for (int i = 0; i < XiL.Length; i++)
            {
                difX[i] = XiL[i];
            }

            var difY = new double[YiL.Length];

            for (int i = 0; i < YiL.Length; i++)
            {
                difY[i] = Math.Abs(YiL[i] - YiS[i]);
            }
            ScottPlot.Plottables.Scatter diffScatter = diff_plot.Plot.Add.Scatter(difX, difY);
        }

        private void GetXYArrayLagrange(Point[] data, out double[] x_arr, out double[] y_arr)
        {
            double h = double.Parse(h_textbox.Text);
            GetMinAndMax_X(data, out double max_x, out double min_x);

            List<double> x_values = new List<double>();
            List<double> y_values = new List<double>();

            Func<double, double> function = (x) =>
            {
                string x_str = x.ToString().Replace(',', '.');
                string langr = Lagrange.LangrangeString(data, data.Length);
                Debug.WriteLine(langr.Replace(",", "."));

                string eval = langr.Replace("x", x_str);

                var expr = new Expression(eval.Replace(",", "."));

                return double.Parse(expr.Evaluate().ToString());
            };
            for (double x = min_x; x <= max_x; x += h)
            {
                x_values.Add(x);
                y_values.Add(function(x));
            }

            x_arr = x_values.ToArray(); y_arr = y_values.ToArray();
        }


        private void GetXYArrayPoints(Point[] data, out double[] x_arr, out double[] y_arr)
        {

            List<double> x_values = new List<double>();
            List<double> y_values = new List<double>();


            for (int x = 0; x < data.Length; x++)
            {
                x_values.Add(data[x].X);
                y_values.Add(data[x].Y);
            }

            x_arr = x_values.ToArray(); y_arr = y_values.ToArray();
        }

        private void GetMinAndMax_X(Point[] data, out double max, out double min)
        {
            min = double.MaxValue;
            max = double.MinValue;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].X < min)
                {
                    min = data[i].X;
                }

                if (data[i].X > max)
                {
                    max = data[i].X;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            diff_plot.Plot.Clear();
            graph.Plot.Clear();
            Point[] f = {
                new Point(double.Parse(x1.Text),double.Parse(y1.Text)),
                new Point(double.Parse(x2.Text),double.Parse(y2.Text)),
                new Point(double.Parse(x3.Text),double.Parse(y3.Text)),
                new Point(double.Parse(x4.Text),double.Parse(y4.Text)),
                new Point(double.Parse(x5.Text),double.Parse(y5.Text))
            };


            graph.Plot.Add.HorizontalLine(0, color: ScottPlot.Color.FromHex("#000000"));
            graph.Plot.Add.VerticalLine(0, color: ScottPlot.Color.FromHex("#000000"));

            CreateGraphs(f);
        }
    }
}
