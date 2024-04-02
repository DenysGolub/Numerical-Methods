using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Spline
    {
        double[] X;
        double[] Y;
        double[] h;
        double[] d;
        double[] u;
        double sx0;
        double sxn;
        double h1;

        public Spline(double[] x, double[] y, double sx0, double sxn, double h)
        {
            X = x;
            Y = y;
            this.sx0 = sx0;
            this.sxn = sxn;
            h1 = h;
        }

        public Dictionary<string, string> SolveString()
        {
            EvalfStartValue();
            double[,] slar = new double[,]
            {
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, X[1] - X[0], 0, 0, 0, Math.Pow((X[1] - X[0]), 2), 0, 0, 0, Math.Pow((X[1] - X[0]), 3), 0, 0, 0 },
                { 0, 1, 0, 0, 0, X[2] - X[1], 0, 0, 0, Math.Pow((X[2] - X[1]), 2), 0, 0, 0, Math.Pow((X[2] - X[1]), 3), 0, 0 },
                { 0, 0, 1, 0, 0, 0, X[3] - X[2], 0, 0, 0, Math.Pow((X[3] - X[2]), 2), 0, 0, 0, Math.Pow((X[3] - X[2]), 3), 0 },
                { 0, 0, 0, 1, 0, 0, 0, X[4] - X[3], 0, 0, 0, Math.Pow((X[4] - X[3]), 2), 0, 0, 0, Math.Pow((X[4] - X[3]), 3) },
                { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 6 * (X[4] - X[3]) },
                { 0, 0, 0, 0, 1, -1, 0, 0, 2 * (X[1] - X[0]), 0, 0, 0, 3 * (Math.Pow((X[1] - X[0]), 2)), 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, -1, 0, 0, 2 * (X[2] - X[1]), 0, 0, 0, 3 * (Math.Pow((X[2] - X[1]), 2)), 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, -1, 0, 0, 2 * (X[3] - X[2]), 0, 0, 0, 3 * (Math.Pow((X[3] - X[2]), 2)), 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 2, -1, 0, 0, 6 * (X[1] - X[0]), 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, -1, 0, 0, 6 * (X[2] - X[1]), 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, -1, 0, 0, 6 * (X[3] - X[2]), 0 }
            };

            double[] b = new double[16] { Y[0], Y[1], Y[2], Y[3], Y[1], Y[2], Y[3], Y[4], 0, 0, 0, 0, 0, 0, 0, 0 };

            SolveSLAR solveSLAR = new SolveSLAR(slar, b);
            double[,] C = solveSLAR.Solve();

            Dictionary<string, string> S = new Dictionary<string, string>();
            string Sx = $"Кубічний сплайн\n";
            for (int i = 0; i < 4; i++)
            {
                S.Add($"S{i}(x)" ,$"{C[3, i]}(x - {X[i]})^3  + ({C[2, i]}(x - {X[i]})^2) + ({C[1, i]}(x - {X[i]}) + {C[0, i]})");
            }
            return S;
        }
        public void SolveY(out double[] Xi, out double[] Yi)
        {
            int line = (int)((X[4] - X[0]) / h1) + 1;
            Xi = new double[line];
            Yi = new double[line];

            //зробить заповнення та вирішення слар
            double[,] slar = new double[,]
            {
                { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 1, 0, 0, 0, X[1] - X[0], 0, 0, 0, Math.Pow((X[1] - X[0]), 2), 0, 0, 0, Math.Pow((X[1] - X[0]), 3), 0, 0, 0 },
                { 0, 1, 0, 0, 0, X[2] - X[1], 0, 0, 0, Math.Pow((X[2] - X[1]), 2), 0, 0, 0, Math.Pow((X[2] - X[1]), 3), 0, 0 },
                { 0, 0, 1, 0, 0, 0, X[3] - X[2], 0, 0, 0, Math.Pow((X[3] - X[2]), 2), 0, 0, 0, Math.Pow((X[3] - X[2]), 3), 0 },
                { 0, 0, 0, 1, 0, 0, 0, X[4] - X[3], 0, 0, 0, Math.Pow((X[4] - X[3]), 2), 0, 0, 0, Math.Pow((X[4] - X[3]), 3) },
                { 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 6 * (X[4] - X[3]) },
                { 0, 0, 0, 0, 1, -1, 0, 0, 2 * (X[1] - X[0]), 0, 0, 0, 3 * (Math.Pow((X[1] - X[0]), 2)), 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, -1, 0, 0, 2 * (X[2] - X[1]), 0, 0, 0, 3 * (Math.Pow((X[2] - X[1]), 2)), 0, 0 },
                { 0, 0, 0, 0, 0, 0, 1, -1, 0, 0, 2 * (X[3] - X[2]), 0, 0, 0, 3 * (Math.Pow((X[3] - X[2]), 2)), 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 2, -1, 0, 0, 6 * (X[1] - X[0]), 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, -1, 0, 0, 6 * (X[2] - X[1]), 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, -1, 0, 0, 6 * (X[3] - X[2]), 0 }
            };

            double[] b = new double[16] { Y[0], Y[1], Y[2], Y[3], Y[1], Y[2], Y[3], Y[4], 0, 0, 0, 0, 0, 0, 0, 0 };

            SolveSLAR solveSLAR = new SolveSLAR(slar, b);
            double[,] SplineCoefficients = solveSLAR.Solve();

            double temp_x = X[0];
            double Sx = 0;
            for (int i = 0; i < line; i++)
            {
                Xi[i] = temp_x;
                if (temp_x >= X[0] && temp_x < X[1])
                {
                    Sx = SplineCoefficients[0, 0] +
                        SplineCoefficients[1, 0] * (Xi[i] - X[0]) +
                        SplineCoefficients[2, 0] * Math.Pow(Xi[i] - X[0], 2) +
                        SplineCoefficients[3, 0] * Math.Pow(Xi[i] - X[0], 3);

                }
                else if (temp_x >= X[1] && temp_x < X[2])
                {
                    Sx = SplineCoefficients[0, 1] +
                        SplineCoefficients[1, 1] * (Xi[i] - X[1]) +
                        SplineCoefficients[2, 1] * Math.Pow(Xi[i] - X[1], 2) +
                        SplineCoefficients[3, 1] * Math.Pow(Xi[i] - X[1], 3);

                }
                else if (temp_x >= X[2] && temp_x < X[3])
                {
                    Sx = SplineCoefficients[0, 2] +
                        SplineCoefficients[1, 2] * (Xi[i] - X[2]) +
                        SplineCoefficients[2, 2] * Math.Pow(Xi[i] - X[2], 2) +
                        SplineCoefficients[3, 2] * Math.Pow(Xi[i] - X[2], 3);

                }
                else if (temp_x >= X[3] && temp_x <= X[4])
                {
                    Sx = SplineCoefficients[0, 3] +
                        SplineCoefficients[1, 3] * (Xi[i] - X[3]) +
                        SplineCoefficients[2, 3] * Math.Pow(Xi[i] - X[3], 2) +
                        SplineCoefficients[3, 3] * Math.Pow(Xi[i] - X[3], 3);
                }
                temp_x += h1;
                Yi[i] = Sx;
            }
        }
        private void EvalfStartValue()
        {
            //hk
            h = new double[X.Length - 1];
            for (int k = 0; k < h.Length; k++)
            {
                h[k] = X[k + 1] - X[k];
            }
            //dk
            d = new double[X.Length - 1];
            for (int k = 0; k < d.Length; k++)
            {
                d[k] = (Y[k + 1] - Y[k]) / h[k];
            }
            //uk
            u = new double[d.Length - 1];
            for (int k = 1; k < u.Length + 1; k++)
            {
                u[k - 1] = 6 * (d[k] - d[k - 1]);
            }
        }

    }
    class SolveSLAR
    {
        private double[,] slar;
        private double[] b;
        public SolveSLAR(double[,] slar, double[] b)
        {
            this.slar = slar;
            this.b = b;
        }
        public double[,] Solve()
        {
            var matrixA = DenseMatrix.OfArray(slar);
            var vectorB = DenseVector.OfArray(b);

            var lu = matrixA.LU();
            var solution = lu.Solve(vectorB);

            MathNet.Numerics.LinearAlgebra.Storage.VectorStorage<double> vectorStorage = solution.Storage;

            int line = vectorStorage.Length / 4;
            double[,] result = new double[line, line];

            int k = 0;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = vectorStorage[k];
                    k++;
                }
            }
            return result;
        }
        public double[] SolveReturnArrayOneDimensional()
        {
            var matrixA = DenseMatrix.OfArray(slar);
            var vectorB = DenseVector.OfArray(b);

            var lu = matrixA.LU();
            var solution = lu.Solve(vectorB);

            MathNet.Numerics.LinearAlgebra.Storage.VectorStorage<double> vectorStorage = solution.Storage;

            double[] result = new double[vectorStorage.Length];

            for (int i = 0; i < vectorStorage.Length; i++)
            {
                result[i] = vectorStorage[i];
            }
            return result;

        }
    }

}
