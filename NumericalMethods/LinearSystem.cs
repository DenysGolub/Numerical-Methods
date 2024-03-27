using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    /// <summary>
    /// Class that solves system of linear equations by using numerical methods
    /// </summary>
    public abstract class LinearSystem
    {
        public virtual Dictionary<string, double> Solve(double[,] system)
        {
            return new Dictionary<string, double>();
        }

        public static double[,] TransposeCoefficientMatrix(double[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1) - 1;

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
            double[,] coeff = new double[matrix.GetLength(0), matrix.GetLength(1) - 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    coeff[i, j] = matrix[i, j];
                }
            }
            return coeff;
        }

        public static double[,] MergeToSLAR(double[,] first, double[,] second)
        {
            double[,] arr = new double[first.GetLength(0), first.GetLength(1) + 1];
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

        public static double[,] GetVectorB(double[,] matrix)
        {
            double[,] vector_b = new double[matrix.GetLength(0), 1];
            int row = 0;

            for (int i = 0; i <= matrix.GetLength(0) - 1; i++, row++)
            {
                var b = matrix.GetLength(1) - 1;
                vector_b[i, 0] = matrix[row, matrix.GetLength(1) - 1];
            }

            return vector_b;
        }

        public static double[,] MultiplyMatrixes(double[,] A, double[,] B)
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

        private protected void PrintSystem(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private protected double[,] NormalizeSlar(double[,] system)
        {
            var transposed = TransposeCoefficientMatrix(system);
            var matrix_coeff_without_vector = GetMatrixWithoutVector(system);
            var vector = GetVectorB(system);
            var vector_at = MultiplyMatrixes(transposed, vector);

            var multiplied_coeff_matrix = MultiplyMatrixes(transposed, matrix_coeff_without_vector);

            var slar = MergeToSLAR(multiplied_coeff_matrix, vector_at);

            return slar;
        }

        protected double accuracy = 0.1;
        public double Epsilon { get { return accuracy;} set { accuracy = value; } }
    }
    
    public class Gauss: LinearSystem
    {
        public new void Solve(double[,]system)
        {

        }

        private void Forward()
        {
            //for(int i = 0; i<)
            //MathNet.Numerics.Interpolation.LinearSpline.
        }

        private void Backward()
        {

        }
    }

    public class LU: LinearSystem
    {
        public override Dictionary<string, double> Solve(double[,] system)
        {
            ///AX=B => LUX=B
            ///LY=B => Y
            ///UX=Y => B
            var U = GetMatrixWithoutVector(system);
            var vector_b = GetVectorB(system);

            GetLU(U, out double[,] L);

            return new Dictionary<string, double>();
        }

        private void AddRow(double[,]matrix, int from_row, int to_row, double value)
        {
            for(int columns = 0; columns<matrix.GetLength(1); columns++)
            {
                var b = value / matrix[to_row, columns] * matrix[from_row, columns];
                matrix[to_row, columns] += b;
            }
        }

        public static (double[,] L, double[,] U) Decompose(double[,] source)
        {
            if (source.GetLength(0) != source.GetLength(1))
            {
                throw new ArgumentException("Source matrix is not square shaped.");
            }

            var pivot = source.GetLength(0);
            var lower = new double[pivot, pivot];
            var upper = new double[pivot, pivot];

            for (var i = 0; i < pivot; i++)
            {
                for (var k = i; k < pivot; k++)
                {
                    double sum = 0;

                    for (var j = 0; j < i; j++)
                    {
                        sum += lower[i, j] * upper[j, k];
                    }

                    upper[i, k] = source[i, k] - sum;
                }

                for (var k = i; k < pivot; k++)
                {
                    if (i == k)
                    {
                        lower[i, i] = 1;
                    }
                    else
                    {
                        double sum = 0;

                        for (var j = 0; j < i; j++)
                        {
                            sum += lower[k, j] * upper[j, i];
                        }

                        lower[k, i] = (source[k, i] - sum) / upper[i, i];
                    }
                }
            }

            return (L: lower, U: upper);
        }


        private void GetLU(double[,]U, out double[,]L)
        {
            L = GetUnitMatrix(U.GetLength(0));

            for(int diag_elem = 0; diag_elem<U.GetLength(0); diag_elem++)
            {
               for(int down_elem = diag_elem+1; down_elem<U.GetLength(0); down_elem++)
                {
                    var del_elem = U[down_elem, diag_elem]/U[diag_elem, diag_elem];

                    if (U[down_elem, diag_elem] > 0)
                    {
                        AddRow(U, diag_elem, down_elem, -del_elem);
                    }
                    else if (U[down_elem, diag_elem]<0)
                    {
                        if(diag_elem<0)
                        {
                            diag_elem = Math.Abs(diag_elem);
                        }
                        AddRow(U, diag_elem, down_elem, del_elem);
                    }
                    L[down_elem, diag_elem] = del_elem;
                    Console.WriteLine();
                }   
            }

            PrintSystem(L);
            Console.WriteLine();
            PrintSystem(U);

            Console.WriteLine();

            PrintSystem(MultiplyMatrixes(L, U));

        }

        private double [,] GetUnitMatrix(int size)
        {
            double[,]matrix = new double[size, size];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 1;
                    }
                }
            }
            return matrix;
        }

    }

    public class Zeidel:LinearSystem
    {
        public override Dictionary<string, double> Solve(double[,] system)
        {
            var transposed = TransposeCoefficientMatrix(system);
            var matrix_coeff_without_vector = GetMatrixWithoutVector(system);
            var vector = GetVectorB(system);
            var vector_at = MultiplyMatrixes(transposed, vector);

            var multiplied_coeff_matrix =MultiplyMatrixes(transposed, matrix_coeff_without_vector);

            var slar = MergeToSLAR(multiplied_coeff_matrix, vector_at);

            var item = ZeroApproximation(slar);

            return KIteration(slar, item, accuracy); //зробити щоб повертало корені лише з останньої ітерації

        }
        
        private protected Dictionary<string, double> ZeroApproximation(double[,] matrix)
        {
            Dictionary<string, double> solutions = new Dictionary<string, double>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var up = matrix[i, matrix.GetLength(1) - 1];
                var denom = matrix[i, i];
                solutions.Add($"x{i + 1}_0", (up / denom));
            }

            return solutions;
        }

        private protected virtual Dictionary<string, double> KIteration(double[,] matrix, Dictionary<string, double> solutions, double e)
        {
            int k = 0;
            int x = 0;

            do
            {

                k++;
                x = 1;
                for (int i = 0; i <= matrix.GetLength(0) - 1; i++)  ///check k element and if solution is discovered put it to equation
                {
                    bool hasValue = false;
                    double x_delete_coeff = 1;
                    solutions.Add($"x{x}_{k}", matrix[i, matrix.GetLength(1) - 1]);

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
                                solutions[$"x{x}_{k}"] += matrix[i, j] * (solutions[$"x{x_prev}_{k}"] * (-1));
                            }
                            else
                            {
                                solutions[$"x{x}_{k}"] += matrix[i, j] * (solutions[$"x{x_prev}_{k - 1}"] * (-1));

                            }
                        }
                        x_prev++;
                    }

                    solutions[$"x{x}_{k}"] /= x_delete_coeff;
                    //solutions[$"x{x}{k}"] = Math.Round(solutions[$"x{x}{k}"], 6);
                    //solutions[$"x{x}_{k}"] = (solutions[$"x{x}_{k}"]);

                    x++;

                }
            }
            while (!IsIterationStopCondition(solutions, k, e, matrix.GetLength(0)));

            return ProcessOutput(solutions, k, x);
        }

        private protected Dictionary<string, double> ProcessOutput(Dictionary<string, double> all_solutions, int iteration, int count_x)
        {
            var only_needed_x = new Dictionary<string, double>();
            int count = count_x;
            for(int i=all_solutions.Count; count>1;i--, count--)
            {
                only_needed_x.Add(all_solutions.ElementAt(i - 1).Key.Replace("_"+iteration.ToString(), ""), all_solutions.ElementAt(i-1).Value);
            }

            return only_needed_x;

        }

        private bool IsK_SolutionExists(Dictionary<string, double> solutions, int x, int k)
        {
            if (solutions.ContainsKey($"x{x}_{k}"))
            {
                return true;
            }

            return false;
        }

        private protected virtual bool IsIterationStopCondition(Dictionary<string, double> solutions, int k, double e, int number_of_x)
        {
            var max_nev = 0.0;
            for (int x = 1; x <= number_of_x; x++)
            {
                var nev = (Math.Abs(solutions[$"x{x}_{k - 1}"] - solutions[$"x{x}_{k}"]));

                if (nev > max_nev)
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

    public class Relaxation: LinearSystem
    {

    }

    public class SimpleIteration: Zeidel
    {
        public override Dictionary<string, double> Solve(double[,] system)
        {
            system = NormalizeSlar(system);
            var item = ZeroApproximation(system);
            return KIteration(system, item, accuracy);
        }

        private protected override Dictionary<string, double> KIteration(double[,] matrix, Dictionary<string, double> solutions, double e)
        {
            int k = 0;
            int x = 0;
            do
            {
                k++;
                x = 1;
                for (int i = 0; i <= matrix.GetLength(0) - 1; i++, x++)  ///check k element and if solution is discovered put it to equation
                {
                    bool hasValue = false;
                    double x_delete_coeff = 1;
                    solutions.Add($"x{x}_{k}", matrix[i, matrix.GetLength(1) - 1]);

                    int x_prev = 1;
                    for (int j = 0; j <= matrix.GetLength(1) - 2; j++)
                    {
                        if (!hasValue)
                        {
                            x_delete_coeff = matrix[i, i];
                            hasValue = true;
                        }

                        if(i!=j)
                        {
                            solutions[$"x{x}_{k}"] -= ((matrix[i, j] * (solutions[$"x{x_prev}_{k - 1}"])));
                        }
                        x_prev++;

                    }
                    solutions[$"x{x}_{k}"] /= x_delete_coeff;
                    //Console.WriteLine($"x{x}_{k}" + ":" + solutions[$"x{x}_{k}"]);
                }
            }
            while (!IsIterationStopCondition(solutions, k, e, matrix.GetLength(0)));

            return ProcessOutput(solutions, k, x);
        }

        private protected override bool IsIterationStopCondition(Dictionary<string, double> solutions, int k, double e, int number_of_x)
        {
            var max_nev = 0.0;
            for (int x = 1; x <= number_of_x; x++)
            {
                var nev = (Math.Abs(solutions[$"x{x}_{k}"] - solutions[$"x{x}_{k - 1}"])) / Math.Abs(solutions[$"x{x}_{k}"]);
                
                if (nev > max_nev)
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
