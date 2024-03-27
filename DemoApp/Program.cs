using NumericalMethods;
using System.ComponentModel;

namespace DemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*UnlinearEquations numerical_methods = new UnlinearEquations();

           
            numerical_methods.Function = "Cos(x)*Log(x+1,3)+1";

            var chord = numerical_methods.Chord(2, 9);
            var part_fraction = numerical_methods.PartFraction(2, 9);

            Console.WriteLine("\tChord\t\t PartFraction");
            for (int i = 0; i < chord.Count; i++)
            {
                Console.WriteLine($"{chord[i]}\t{part_fraction[i]}");
            }*/

            /*Console.WriteLine("Chord|Secant|Part_fraction|SimpleIter|newton");
            for (int i = 0; i < chord.Count; i++)
            {
                Console.WriteLine($"{chord[i]}|{secant[i]}|{part_fraction[i]}|" +
                    $"{iter[i]}|{newton[i]}");
            }*/

            /*Zeidel zeidel = new Zeidel();
            double[,] numbers = { 
                { 2,1,5,17}, 
                {3,4.5,4,25}, 
                {4,2,1,20}, 
                };
            var m = zeidel.Solve(numbers);*/

            SimpleIteration si = new SimpleIteration();

            double[,] system = new double[,]
            {
                { 2.66, 0.9, 15.3, 7.1 },
                { 1.3, 22.8, 3.3, 6.89 },
                { 15.8, -4.1, -1.7, 2.8 }
            };
            si.Epsilon = 0.1;

            
            //var solutions = si.Solve(system);

            LU lu = new LU();
            var b = lu.Solve(system);

            var decompos = LU.Decompose(lu.GetMatrixWithoutVector(system));
            ///AX=B => LUX=B
            ///LY=B => Y
            ///UX=Y => X
            Zeidel zeidel = new Zeidel();
            zeidel.Epsilon = 0.00000000000001;
            var Y = zeidel.Solve(zeidel.MergeToSLAR(decompos.L, zeidel.GetVectorB(system)));
            //var X = zeidel.Solve(zeidel.MergeToSLAR(decompos.U, Y.ToArray()));

            double[,] array_b = new double[Y.Count, 1];

            for(int i = Y.Count-1, x=0; i>=0; i--, x++)
            {
                array_b[x, 0] = Y.ElementAt(i).Value;
            }
            var X = zeidel.Solve(zeidel.MergeToSLAR(decompos.U, array_b));

        }
    }
}
