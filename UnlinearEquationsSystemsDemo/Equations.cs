using Antlr4.Runtime.Tree;
using NumericalMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class Equations
    {
        Dictionary<int, string> equations_x = new Dictionary<int, string>();
        Dictionary<int, string> equations_y = new Dictionary<int, string>();

        Dictionary<int, string> equations_iter_x = new Dictionary<int, string>();
        Dictionary<int, string> equations_iter_y = new Dictionary<int, string>();


        public Equations()
        {
            equations_x.Add(1, "2*x*x-4*Pow(y,3)-1.5");
            equations_y.Add(1, "Pow(x,3)-5*Pow(y,2)+0.25");

            equations_iter_x.Add(1, "(1.5-4*Pow(y,3))/2");
            equations_iter_y.Add(1, "Sqrt((-0.25-Pow(x,3))/-5)");

            ///////////////////
            equations_x.Add(2, "2*Pow(x,2)-3*Pow(y,3)-3");
            equations_y.Add(2, "x+2*y*y-5");

            /////////////////////
            equations_iter_x.Add(2, "(3*Pow(y,2)+1)/2");
            equations_iter_y.Add(2, "Sqrt((5-x)/2)");

            ////////////////////
            equations_x.Add(3, "x+x*Pow(y,3)-9");
            equations_y.Add(3, "x*y-4*x*Tan(y)-1.86");

            equations_iter_x.Add(3, "9/(1+Pow(y,3))");
            equations_iter_y.Add(3, "1.86/(4-Tan(x))");
            ////////////////////
            equations_x.Add(4, "x-3/2*Cos(y)");
            equations_y.Add(4, "x+9*y*y-2");

            equations_iter_x.Add(4, "3/2*Cos(y)");
            equations_iter_y.Add(4, "Sqrt((2-x)/9)");
            ////////////////////

            equations_x.Add(5, "Sin(x)+Sqrt(2*Pow(y,3))-4");
            equations_y.Add(5, "Tan(x)-y*y+4");

            equations_iter_x.Add(5, "Asin(4-Sqrt(2*Pow(y,3)))");
            equations_iter_y.Add(5, "Sqrt(4+Tan(x))");
            ////////////////////

            equations_x.Add(6, "Pow(x,2)-3.5*x*y+3*Pow(y,3)");
            equations_y.Add(6, "3*x-8*Pow(x,3)*Pow(y,2)-4.7*y");

            equations_iter_x.Add(6, "(7*y+y*Sqrt(49-48*y))/4");
            equations_iter_y.Add(6, "-80.0/47.0*Pow(x,5)+(30/47)*x");
            ////////////////////
            equations_x.Add(7, "4*x+11*y*y");
            equations_y.Add(7, "11*x+7*Pow(y,3)+33");

            equations_iter_x.Add(7, "(-11*Pow(y,2))/4");
            equations_iter_y.Add(7, "Pow((-33-11*x)/7, 1.0/3)");
            ////////////////////

            equations_x.Add(8, "8*Sin(x)-3*y-0.56");
            equations_y.Add(8, "x-Pow(Cos(y),2)");

            equations_iter_x.Add(8, "Asin((3*y+0.56)/8)");
            equations_iter_y.Add(8, "Pow(Acos(x),2)");
            ////////////////////

            equations_x.Add(9, "2*x*x-x*y-4*y-2");
            equations_y.Add(9, "x-2*Log(y,E)-2*y*y");

            equations_iter_x.Add(9, "(y+Sqrt(y*y+32*y-16))/4");
            equations_iter_y.Add(9, "Sqrt((x)/2)");
            ////////////////////

            equations_x.Add(10, "Sin(x)-y*y");
            equations_y.Add(10, "Pow(Tan(x),2)-y");

            equations_iter_x.Add(10, "Asin(y*y)");
            equations_iter_y.Add(10, "Pow(Tan(x),2)");
            ////////////////////




        }

        public string GetFirstEq(int var)
        {
            return equations_x[var];
        }

        public string GetSecondEq(int var)
        {
            return equations_y[var];
        }

        public Dictionary<string, double> Zeidel(Func<double, double> function_x_iter, Func<double, double> function_y_iter, double x0, double y0, double eps, out int k)
        {
            var solutions = new Dictionary<string, double>()
            {
                { "x_0",  x0},
                {"y_0", y0}
            };
            k = 0;
            do
            {
                k++;
                solutions.Add($"x_{k}", function_x_iter(solutions[$"y_{k-1}"]));
                solutions.Add($"y_{k}", function_y_iter(solutions[$"x_{k}"]));
            }
            while (IsIterationStopCondition(solutions, k, eps));
            return solutions;
        }

        public Dictionary<string, double> Newton(Func<double, double, double> function_first, Func<double, double, double> function_second, double x0, double y0, double eps, out int k)
        {
            var solutions = new Dictionary<string, double>()
            {
                { "x_0",  x0},
                {"y_0", y0}
            }; k = 0;
            Zeidel zeildel = new Zeidel();
            /// 2  4
            /// -1  2
            ///
            ///
            do
            {
                k++;
                var J = Jacobian(function_first, function_second, solutions[$"x_{k - 1}"], solutions[$"y_{k - 1}"]);

                var F = GetF(function_first, function_second, solutions[$"x_{k - 1}"], solutions[$"y_{k - 1}"]);
                var slar = zeildel.MergeToSLAR(J, F);
                var deltaP = zeildel.Solve(slar);
                solutions.Add($"x_{k}", solutions[$"x_{k - 1}"] + deltaP["x1"]);
                solutions.Add($"y_{k}", solutions[$"y_{k - 1}"] + deltaP["x2"]);

                /* solutions.Add($"x_{k}", -F[0,0] + deltaP["x1"]);
                 solutions.Add($"y_{k}", -F[1,0] + deltaP["x2"]);*/
            }
            while (IsIterationStopConditionNewton(solutions, k, eps));


            return solutions;
        }

        private double[,] GetF(Func<double, double, double> function_first, Func<double, double, double> function_second, double x, double y)
        {
            double[,] matrix = new double[2, 1];
            matrix[0, 0] = -function_first(x, y);
            matrix[1, 0] = -function_second(x, y);
            return matrix;

        }

        public Dictionary<string, double> SimpleIterations(Func<double, double> function_x_iter, Func<double, double> function_y_iter, double x0, double y0, double eps, out int k)
        {
            var solutions = new Dictionary<string, double>()
            {
                { "x_0",  x0},
                {"y_0", y0}
            };


            k = 0;

            do
            {
                k++;
                solutions.Add($"x_{k}", function_x_iter(solutions[$"y_{k - 1}"]));
                solutions.Add($"y_{k}", function_y_iter(solutions[$"x_{k - 1}"]));
            }
            while (IsIterationStopCondition(solutions, k, eps));

            return solutions;
        }

        private double[,] Jacobian(Func<double, double, double> function_first, Func<double, double, double> function_second, double x, double y)
        {
            double[,] matrix = new double[2,2];
            matrix[0, 0] = Dx(function_first, x, y);
            matrix[0, 1] = Dy(function_first, x, y);

            matrix[1,0]= Dx(function_second, x, y);
            matrix[1,1]= Dy(function_second, x,y);

            ///  
            ///

            return matrix;
        }

        private double Dy(Func<double, double, double> function, double x, double y)
        {
            return (function(x, y + 0.0001) - function(x, y)) / 0.0001;
        }

        private double Dx(Func<double, double, double> function, double x, double y)
        {
            return (function(x + 0.0001, y) - function(x, y)) / 0.0001;
        }

        private static bool IsIterationStopCondition(Dictionary<string, double> solutions, int k, double e)
        {
            var nev_x = (Math.Abs(solutions[$"x_{k - 1}"] - solutions[$"x_{k}"]));
            var nev_y = (Math.Abs(solutions[$"y_{k - 1}"] - solutions[$"y_{k}"]));

           
            if (nev_x < e || nev_y < e)
            {
                return false;
            }
            return true;
        }

        private static bool IsIterationStopConditionNewton(Dictionary<string, double> solutions, int k, double e)
        {
            var nev_x = (Math.Abs(solutions[$"x_{k}"] - solutions[$"x_{k-1}"]));
            var nev_y = (Math.Abs(solutions[$"y_{k}"] - solutions[$"y_{k-1}"]));


            if (nev_x < e || nev_y < e)
            {
                return false;
            }
            return true;
        }

        public string GetIterFirstEq(int variant)
        {
            return equations_iter_x[variant];
        }

        public string GetIterSecondEq(int variant)
        {
            return equations_iter_y[variant];
        }
    }
}
