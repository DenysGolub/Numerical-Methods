using MathNet.Numerics.Providers.LinearAlgebra;
using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    /// <summary>
    /// Class that solves systems of two unlinear equations. 
    /// Notice, that you need to provide iteration formula for 
    /// every equation if you're using Zeildel or Simple iterations!
    /// Mention, all equations should be in double format (numbers with dot)
    /// </summary>
    internal class UnlinearSystem
    {

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
                solutions.Add($"x_{k}", function_x_iter(solutions[$"y_{k - 1}"]));
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
            }; 
            k = 0;
            Zeidel zeildel = new Zeidel();
            do
            {
                k++;
                var J = Jacobian(function_first, function_second, solutions[$"x_{k - 1}"], solutions[$"y_{k - 1}"]);

                var F = GetF(function_first, function_second, solutions[$"x_{k - 1}"], solutions[$"y_{k - 1}"]);
                var slar = LinearSystem.MergeToSLAR(J, F);
                var deltaP = zeildel.Solve(slar);
                solutions.Add($"x_{k}", solutions[$"x_{k - 1}"] + deltaP["x1"]);
                solutions.Add($"y_{k}", solutions[$"y_{k - 1}"] + deltaP["x2"]);
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
            double[,] matrix = new double[2, 2];
            matrix[0, 0] = Dx(function_first, x, y);
            matrix[0, 1] = Dy(function_first, x, y);

            matrix[1, 0] = Dx(function_second, x, y);
            matrix[1, 1] = Dy(function_second, x, y);

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
            var nev_x = (Math.Abs(solutions[$"x_{k}"] - solutions[$"x_{k - 1}"]));
            var nev_y = (Math.Abs(solutions[$"y_{k}"] - solutions[$"y_{k - 1}"]));


            if (nev_x < e || nev_y < e)
            {
                return false;
            }
            return true;
        }
    }

}
