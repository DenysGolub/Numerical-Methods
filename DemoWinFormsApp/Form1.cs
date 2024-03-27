using NCalc;
using NumericalMethods;
using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DemoWinFormsApp
{
    public partial class Form1 : Form
    {
        UnlinearEquations ueq = new UnlinearEquations();
        public Form1()
        {
            InitializeComponent();
        }

        private void GetXYArrays(Func<double, double> function, double a, double b, out double[] dataX, out double[] dataY)
        {

            double step = Math.Round(Math.Abs(b - a) / 600.0, 3);
            List<double> x_values = new List<double>();
            List<double> y_values = new List<double>();


            for (double x = a; x <= b; x += step)
            {
                x_values.Add(x);
                y_values.Add(function(x));
            }


            dataX = x_values.ToArray();
            dataY = y_values.ToArray();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formsPlot1.Plot.Clear();
            formsPlot1.Plot.Add.HorizontalLine(0);
            formsPlot1.Plot.Add.VerticalLine(0);
            ueq.Function = function_text.Text;

            double a = double.Parse(a_interval.Text);
            double b = double.Parse(b_interval.Text);

            GetXYArrays(ueq.FunctionEval, a,b, out double[] data_x, out double[] data_y);
            ScottPlot.Plottables.Scatter MyScatter = formsPlot1.Plot.Add.Scatter(data_x, data_y);
            MyScatter.LineWidth = 2;

            formsPlot1.Refresh();

            List<double> solutions = null;

            if(radioChord.Checked)
            {
                solutions = ueq.Chord(a, b);
            }
            else if(radioNewton.Checked)
            {
                solutions= ueq.Newton(a, b);
            }
            else if(radioPF.Checked)
            {
                solutions = ueq.PartFraction(a, b);
            }
            else if(radioSecant.Checked)
            {
                solutions= ueq.Secant(a, b);
            }
            else if(radioSI.Checked)
            {
                solutions=ueq.SimpleIteration(a, b);
            }

            answers.Clear();

            foreach(var k in solutions)
            {
                answers.Text += k.ToString() + "\n";
            }
        }
    }
}
