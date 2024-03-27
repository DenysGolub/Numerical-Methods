using Accessibility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WpfApp1
{
    public static class Zeldel
    {
        public static double[,] TransposeCoefficientMatrix(double[,]matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1)-1;

            double[,] result = new double[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        public static double[,] GetMatrixWithoutVector(double[,] matrix)
        {
            double[,]coeff = new double[matrix.GetLength(0),matrix.GetLength(1)-1];

            for(int i = 0; i<matrix.GetLength(0); i++)
            {
                for(int j=0; j<matrix.GetLength(1)-1;j++)
                {
                    coeff[i, j] = matrix[i, j];
                }
            }
            return coeff;
        }

        public static double[,] MergeToSLAR(double[,]first, double[,] second)
        {
            double[,] arr = new double[first.GetLength(0), first.GetLength(1)+1];
            for (int i = 0; i < first.GetLength(0); i++)
            {
                for (int j = 0; j < first.GetLength(1); j++)
                {
                    arr[i, j] = first[i, j];
                }
            }
            for (int i = 0; i < second.GetLength(0); i++)
            {
                for (int j = 0; j < second.GetLength(1); j++)
                {
                    arr[i, j + first.GetLength(1)] = second[i, j];
                }
            }
            return arr;
        }

        public static double[,] GetVectorB(double[,]matrix)
        {
            double[,] vector_b = new double[matrix.GetLength(0), 1];
            int row=0;

            for(int i =0; i<=matrix.GetLength(0)-1; i++, row++)
            {
                var b = matrix.GetLength(1) - 1;
                vector_b[i, 0] = matrix[row, matrix.GetLength(1) - 1];
            }

            return vector_b;
        }

        public static double[,] MultiplyMatrixes(double[,]A, double[,] B)
        {

            int rA = A.GetLength(0);
            int cA = A.GetLength(1);
            int rB = B.GetLength(0);
            int cB = B.GetLength(1);

            if (cA != rB)
            {
                Console.WriteLine("Matrixes can't be multiplied!!");
            }
            else
            {
                double temp = 0;
                double[,] kHasil = new double[rA, cB];

                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            temp += A[i, k] * B[k, j];
                        }
                        kHasil[i, j] = temp;
                    }
                }

                return kHasil;
            }
            return new double[0, 0];
        }

        public static Dictionary<string, double> ZeroApproximation(double[,] matrix)
        {
            Dictionary<string, double> solutions = new Dictionary<string, double>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var up = matrix[i, matrix.GetLength(1) - 1];
                var denom = matrix[i, i];
                solutions.Add($"x{i + 1}0", (up / denom));
                //solutions.Add($"x{i + 1}0", Math.Round(up / denom, 6));

            }

            return solutions;
        }

        public static Dictionary<string, double> KIteration(double[,] matrix, Dictionary<string, double> solutions, double e, out int k)
        {
            k = 0;
            int x = 0;

            do
            {

                k++;
                x = 1;
                for (int i = 0; i <= matrix.GetLength(0) - 1; i++)  ///check k element and if solution is discovered put it to equation
                {
                    bool hasValue = false;
                    double x_delete_coeff = 1;
                    solutions.Add($"x{x}{k}", matrix[i, matrix.GetLength(1) - 1]);

                    int x_prev = 1;
                    for (int j = 0; j <= matrix.GetLength(1) - 2; j++)
                    {

                        if (j + 1 == x && !hasValue)
                        {
                            x_delete_coeff = matrix[i, j];
                            hasValue = true;
                        }
                        else if (x_prev != x)
                        {
                            if (IsK_SolutionExists(solutions, x_prev, k))
                            {
                                solutions[$"x{x}{k}"] += matrix[i, j] * (solutions[$"x{x_prev}{k}"] * (-1));
                            }
                            else
                            {
                                solutions[$"x{x}{k}"] += matrix[i, j] * (solutions[$"x{x_prev}{k - 1}"] * (-1));

                            }
                        }
                        x_prev++;
                    }

                    solutions[$"x{x}{k}"] /= x_delete_coeff;
                    //solutions[$"x{x}{k}"] = Math.Round(solutions[$"x{x}{k}"], 6);
                    solutions[$"x{x}{k}"] = (solutions[$"x{x}{k}"]);

                    x++;

                }
            }
            while (!IsIterationStopCondition(solutions, k, e, matrix.GetLength(0)));

            return solutions;
        }

        private static bool IsK_SolutionExists(Dictionary<string, double> solutions, int x, int k)
        {
            if (solutions.ContainsKey($"x{x}{k}"))
            {
                return true;
            }

            return false;
        }

        public static bool IsIterationStopCondition(Dictionary<string, double> solutions, int k, double e, int number_of_x)
        {
            var max_nev = 0.0;
            for (int x = 1; x <= number_of_x; x++)
            {                
                var nev = (Math.Abs(solutions[$"x{x}{k-1}"] - solutions[$"x{x}{k}"]));

                if(nev > max_nev)
                {
                    max_nev = nev;
                }  
            }

            if (!(max_nev < e))
            {
                return false;
            }
            return true;
        }
    }
}
