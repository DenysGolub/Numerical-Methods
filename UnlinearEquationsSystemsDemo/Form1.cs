using NCalc;
using System.Diagnostics;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Equations eq = new Equations();
        public Form1()
        {
            InitializeComponent();

            for (int i = 1; i <= 10; i++)
            {
                variants.Items.Add(i);
            }

        }

        private void DrawGraph(object sender, EventArgs e)
        {
            // Make the Bitmap.
            Bitmap bm = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                // Clear.
                gr.Clear(Color.White);
                gr.ScaleTransform(70f, -70f, System.Drawing.Drawing2D.MatrixOrder.Append);
                gr.TranslateTransform(bm.Width * 0.5f, bm.Height * 0.5f,
                    System.Drawing.Drawing2D.MatrixOrder.Append);

                // Draw axes.
                using (Pen axis_pen = new Pen(Color.LightGray, 0))
                {
                    gr.DrawLine(axis_pen, -8, 0, 8, 0);
                    gr.DrawLine(axis_pen, 0, -8, 0, 8);
                    for (int i = -8; i <= 8; i++)
                    {
                        gr.DrawLine(axis_pen, i, -0.1f, i, 0.1f);

                        gr.DrawLine(axis_pen, -0.1f, i, 0.1f, i);
                    }
                }

                // Graph the equation.
                float dx = 20f / bm.Width;
                float dy = 20f / bm.Height;
                var timer = new Stopwatch();
                Func<float, float, float> first_eq = (float x, float y) =>
                {
                    var n = first_equation.Text;
                    if (n.Contains("E"))
                    {
                        n = n.Replace("E", Math.E.ToString().Replace(',', '.'));
                    }
                    var x_string = x.ToString().Replace(',', '.');
                    var y_string = y.ToString().Replace(",", ".");
                    n = n.Replace("x", x_string);
                    n = n.Replace("y", y_string);

                    var eval = new Expression(n).Evaluate();
                    return (float)Math.Round(float.Parse(eval.ToString()), 6);
                };

                Func<float, float, float> second_eq = (float x, float y) =>
                {
                    var n = second_equation.Text;
                    if (n.Contains("E"))
                    {
                        n = n.Replace("E", Math.E.ToString().Replace(',', '.'));
                    }
                    var x_string = x.ToString().Replace(',', '.');
                    var y_string = y.ToString().Replace(",", ".");
                    n = n.Replace("x", x_string);
                    n = n.Replace("y", y_string);


                    var eval = new Expression(n).Evaluate();

                    return (float)Math.Round(float.Parse(eval.ToString()), 6);
                };
                timer.Start();
                Plot(first_eq, gr, -5, -5, 5, 5, dx, dy);
                Plot(second_eq, gr, -5, -5, 5, 5, dx, dy);
                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;
                string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");
                MessageBox.Show(foo);

            } // using gr.

            // Display the result.
            pictureBox1.Image = bm;
        }

        // Plot the equations.
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void Plot(Func<float, float, float> function, Graphics gr,
           float xmin, float ymin, float xmax, float ymax,
           float dx, float dy)
        {
            // Plot the function.
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                // Horizontal comparisons.
                for (float x = xmin; x <= xmax; x += dx)
                {
                    float last_y = function(x, ymin);
                    for (float y = ymin + dy; y <= ymax; y += dy)
                    {
                        float next_y = function(x, y);
                        if (
                            ((last_y <= 0f) && (next_y >= 0f)) ||
                            ((last_y >= 0f) && (next_y <= 0f))
                           )
                        {
                            // Plot this point.
                            gr.DrawLine(thin_pen, x, y - dy, x, y);
                        }
                        last_y = next_y;
                    }
                } // Horizontal comparisons.

                // Vertical comparisons.
                for (float y = ymin + dy; y <= ymax; y += dy)
                {
                    float last_x = function(xmin, y);
                    for (float x = xmin + dx; x <= xmax; x += dx)
                    {
                        float next_x = function(x, y);
                        if (
                            ((last_x <= 0f) && (next_x >= 0f)) ||
                            ((last_x >= 0f) && (next_x <= 0f))
                           )
                        {
                            // Plot this point.
                            gr.DrawLine(thin_pen, x - dx, y, x, y);
                        }
                        last_x = next_x;
                    }
                } // Vertical comparisons.
            } // using thin_pen.
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void variants_SelectedIndexChanged(object sender, EventArgs e)
        {
            var var = int.Parse(variants.SelectedItem.ToString());

            first_equation.Text = eq.GetFirstEq(var);
            second_equation.Text = eq.GetSecondEq(var);

            iter_x.Text = eq.GetIterFirstEq(var);
            iter_y.Text = eq.GetIterSecondEq(var);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void solvesystem_button_Click(object sender, EventArgs e)
        {
            try
            {
                var x_equation = (double y) =>
                {
                    var n = iter_x.Text;
                    if (n.Contains("E"))
                    {
                        n = n.Replace("E", Math.E.ToString().Replace(',', '.'));
                    }
                    var y_string = y.ToString().Replace(",", ".");
                    n = n.Replace("y", y_string);


                    var eval = new Expression(n).Evaluate();

                    return Math.Round(float.Parse(eval.ToString()), 6);
                };

                var y_equation = (double x) =>
                {
                    var n = iter_y.Text;
                    if (n.Contains("E"))
                    {
                        n = n.Replace("E", Math.E.ToString().Replace(',', '.'));
                    }
                    var x_string = x.ToString().Replace(',', '.');
                    n = n.Replace("x", x_string);


                    var eval = new Expression(n).Evaluate();

                    return Math.Round(float.Parse(eval.ToString()), 6);
                };


                var x0 = double.Parse(x0_text.Text.Replace(".", ","));
                var y0 = double.Parse(y0_text.Text.Replace(".", ","));
                var accuracy = double.Parse(accuracy_text.Text.Replace(".", ","));


                Dictionary<string, double> b = null;
                int k = 0;
                if (ZeidelRadio.Checked)
                {
                    b = eq.Zeidel(x_equation, y_equation, x0, y0, accuracy, out k);
                }
                else if(IterationsRation.Checked)
                {
                    b=eq.SimpleIterations(x_equation, y_equation, x0, y0, accuracy, out k);
                }
                else if(NewtonRadio.Checked)
                {
                    Func<double, double, double> first_eq = (double x, double y) =>
                    {
                        var n = first_equation.Text;
                        if (n.Contains("E"))
                        {
                            n = n.Replace("E", Math.E.ToString().Replace(',', '.'));
                        }
                        var x_string = x.ToString().Replace(',', '.');
                        var y_string = y.ToString().Replace(",", ".");
                        n = n.Replace("x", x_string);
                        n = n.Replace("y", y_string);

                        var eval = new Expression(n).Evaluate();
                        return Math.Round(double.Parse(eval.ToString()), 6);
                    };

                    Func<double, double, double> second_eq = (double x, double y) =>
                    {
                        var n = second_equation.Text;
                        if (n.Contains("E"))
                        {
                            n = n.Replace("E", Math.E.ToString().Replace(',', '.'));
                        }
                        var x_string = x.ToString().Replace(',', '.');
                        var y_string = y.ToString().Replace(",", ".");
                        n = n.Replace("x", x_string);
                        n = n.Replace("y", y_string);


                        var eval = new Expression(n).Evaluate();

                        return Math.Round(double.Parse(eval.ToString()), 6);
                    };

                    b = eq.Newton(first_eq, second_eq, x0, y0, accuracy, out k);
                }


                var check_answer = first_equation.Text.Replace("x", b[$"x_{k}"].ToString().Replace(',', '.'));
                check_answer = check_answer.Replace("y", b[$"y_{k}"].ToString().Replace(',', '.'));
                var check_answer_second = second_equation.Text.Replace("y", b[$"y_{k}"].ToString().Replace(',', '.'));
                check_answer_second = check_answer_second.Replace("x", b[$"x_{k}"].ToString().Replace(',', '.'));

                var calculated_first = new Expression(check_answer).Evaluate().ToString();
                var calculated_second = new Expression(check_answer_second).Evaluate().ToString();

                answers_check.Text = calculated_first + "\n" + calculated_second + "\n";

                answers_textbox.Clear();
                int count = 0;
                int iter_number = 0;
                foreach (var answer in b)
                {
                    if (count % 2 == 0)
                    {
                        answers_textbox.Text += $"---------------Ітерація №{iter_number++}---------------\n";
                        count = 0;
                    }
                    count++;


                    answers_textbox.Text += $"{answer.Key}={answer.Value}\n";
                    
                }
                answers_textbox.AppendText("");
                answers_textbox.SelectionStart=answers_textbox.Text.Length;
                answers_textbox.ScrollToCaret(); 
            }
            catch(Exception ex)
            {
                MessageBox.Show("Оберіть інше наближення!");
            }
        }
    }
}
