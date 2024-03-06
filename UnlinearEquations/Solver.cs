using NCalc;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Transactions;
using Expression = NCalc.Expression;
namespace UnlinearEquations
{
    public class Solver
    {
        public delegate double FunctionDelegate(double x);

        double accuracy = 0.000000000000001;

        string function_expression_string = "";

        FunctionDelegate function_delegate = null;
      
        public double Epsilon { get { return accuracy; } set { accuracy = value; } }

        public string Function
        {
            set
            {
                function_expression_string = value;
                function_delegate = (double x) => 
                {
                    var x_string = x.ToString().Replace(',','.');
                    var n = function_expression_string.Replace("x", x_string);
                    var eval = new Expression(n).Evaluate();
                    return double.Parse(eval.ToString());
                };
            }
        }

        public List<double> Chord(double a, double b)
        {
            var intervals = SeparateSolutions(a, b);
            
            List<double> solutions = new List<double>();

            int list_number = 0;
            while (list_number < intervals.Keys.Count)
            {
                double corin = 0;
                bool solution = false;
                a = intervals.ElementAt(list_number).Key;
                b = intervals.ElementAt(list_number + 1).Key;
                double c1 = a;

                if (function_delegate(a) * function_delegate(b) < 0 && !InfinityCheck(function_delegate(a), function_delegate(b)))
                {
                    while (true)
                    {
                        double fa = function_delegate(a);
                        double fb = function_delegate(b);

                        double c2 = a - ((fa * (a - b)) / (fa - fb));
                        double fc = function_delegate(c2);

                        if (Math.Abs(c1 - c2) < accuracy)
                        {
                            solution = true;
                            corin = c2;
                            break;
                        }

                        if ((fa < 0 && fc > 0) || (fc < 0 && fa > 0))
                        {
                            b = c2;
                        }
                        else
                        {
                            a = c2;
                        }
                        c1 = c2;
                    }
                }

                IsSolution(solution, ref solutions, intervals, list_number, corin);

                list_number++;

                if (list_number + 1 >= intervals.Keys.Count)
                {
                    break;
                }
            }
            return solutions;
        }

        public List<double> Newton(double a, double b)
        {
            var intervals = SeparateSolutions(a, b);

            List<double> solutions = new List<double>();

            int list_number = 0;
            while (list_number < intervals.Keys.Count)
            {
                double corin = 0;
                bool solution = false;
                a = intervals.ElementAt(list_number).Key;
                b = intervals.ElementAt(list_number + 1).Key;

                if (function_delegate(a) * function_delegate(b) < 0 && !InfinityCheck(function_delegate(a), function_delegate(b)))
                {
                    double x_next = 0;
                    double xk = b;

                    while (true)
                    {
                        var fd = function_delegate(xk);
                        var dx = Dx(xk);
                        x_next = xk - function_delegate(xk) / Dx(xk);
                        if(Math.Abs(xk-x_next)<accuracy)
                        {
                            corin = x_next;
                            solution = true;
                            break;
                        }
                        xk=x_next;
                    }
                }

                IsSolution(solution, ref solutions, intervals, list_number, corin);

                list_number++;

                if (list_number + 1 >= intervals.Keys.Count)
                {
                    break;
                }
            }
            return solutions;
        }

        public List<double> SimpleIteration(double a, double b)
        {
            var intervals = SeparateSolutions(a, b);

            List<double> solutions = new List<double>();

            int list_number = 0;
            while (list_number < intervals.Keys.Count)
            {
                double corin = 0;
                bool solution = false;
                a = intervals.ElementAt(list_number).Key;
                b = intervals.ElementAt(list_number + 1).Key;
                double x0 = a;

                if (function_delegate(a) * function_delegate(b) < 0 && !InfinityCheck(function_delegate(a), function_delegate(b)))
                {
                    while(true)
                    {
                        double d = Dx(a, b);
                        double x_next = x0 - 1 / Dx(a, b)*function_delegate(x0);

                        if(Math.Abs(x_next - x0)<accuracy)
                        {
                            solution = true;
                            corin=x_next;
                            break;
                        }
                        x0=x_next;
                    }
                }

                IsSolution(solution, ref solutions, intervals, list_number, corin);

                list_number++;

                if (list_number + 1 >= intervals.Keys.Count)
                {
                    break;
                }
            }
            return solutions;
        }

        private double Dx(double a, double b)
        {
            double dx = int.MinValue;
            double step = Math.Abs((a - b) / 10);
            for (double x=a; x <= b; x += step)
            {
                double temp = (function_delegate(x + 0.001) - function_delegate(x)) / 0.001;
                if (temp > dx)
                {
                    dx = temp;
                }
            }
            return dx;
        }

        private double Dx(double x)
        {
            return (function_delegate(x + 0.0001) - function_delegate(x)) / 0.0001;
        }

        public List<double> PartFraction(double a, double b)
        {
            var intervals = SeparateSolutions(a, b);

            List<double> solutions = new List<double>();

            int list_number = 0;
            while (list_number < intervals.Keys.Count)
            {
                double corin = 0;
                bool solution = false;
                a = intervals.ElementAt(list_number).Key;
                b = intervals.ElementAt(list_number + 1).Key;

                if (function_delegate(a) * function_delegate(b) < 0 && !InfinityCheck(function_delegate(a), function_delegate(b)))
                {
                    while (true)
                    {
                        corin = (a + b) / 2.0;
                        double a_values = function_delegate(a);
                        double b_values = function_delegate(b);
                        double c_values = function_delegate(corin);

                        if (Math.Abs(a-b) < 2*accuracy)
                        {
                            solution = true;
                            break;
                        }

                        if (a_values * c_values < 0)
                        {
                            b = corin;
                        }
                        else
                        {
                            a = corin;
                        }
                    }
                }

                IsSolution(solution, ref solutions, intervals, list_number, corin);

                list_number++;

                if (list_number + 1 >= intervals.Keys.Count)
                {
                    break;
                }
            }
            return solutions;
        }

        public List<double> Secant(double a, double b)
        {
            var intervals = SeparateSolutions(a, b);

            List<double> solutions = new List<double>();

            int list_number = 0;
            while (list_number < intervals.Keys.Count)
            {
                double corin = 0;
                bool solution = false;
                a = intervals.ElementAt(list_number).Key;
                b = intervals.ElementAt(list_number + 1).Key;

                if (function_delegate(a) * function_delegate(b) < 0 && !InfinityCheck(function_delegate(a), function_delegate(b)))
                {
                    double x_prev = 0;
                    double x_curr = b;
                    double temp = 0;

                    while (true)
                    {
                        x_prev = x_curr;


                        double x_next = x_curr - (function_delegate(x_curr) * (x_curr - x_prev)) / (function_delegate(x_curr) - function_delegate(x_prev));


                        if (Math.Abs(x_curr-x_prev) < accuracy)
                        {
                            corin = x_curr;
                            solution = true;
                            break;
                        }

                        x_curr = x_next;

                        temp = x_prev;

                    }
                }

                IsSolution(solution, ref solutions, intervals, list_number, corin);

                list_number++;

                if (list_number + 1 >= intervals.Keys.Count)
                {
                    break;
                }
            }
            return solutions;
        }

        private Dictionary<double, double> SeparateSolutions(double a, double b)
        {
            double step = Math.Round(Math.Abs(b - a) / 300.0, 5); //300 all ok

            Dictionary<double, double> list = new Dictionary<double, double>();

            for (double i = a; i <= b; i = Math.Round(i += step, 5))
            {
                list.Add(Math.Round(i, 3), Math.Round(function_delegate(i), 3));
            }

            return list;
        }

        private static bool InfinityCheck(double a, double b)
        {
            if (double.IsInfinity(a) || double.IsInfinity(b))
            {
                return true;
            }
            return false;
        }

        private void IsSolution(bool solution, ref List<double> solutions, Dictionary<double, double> intervals, int list_number, double corin)
        {
            if (!solution && Math.Round(function_delegate(intervals.ElementAt(list_number).Key), 6) == 0)
            {
                corin = intervals.ElementAt(list_number).Key;
                solution = true;
            }

            if (solution)
            {
                solutions.Add(corin);
            }
        }
    }
}
