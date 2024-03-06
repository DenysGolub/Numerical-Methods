using NCalc;
using UnlinearEquations;

namespace DemoApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Solver numerical_methods = new Solver();


            numerical_methods.Function = "x*x-Atan(x+x)";
            var chord = numerical_methods.Chord(-2.5,2.5);
            var secant = numerical_methods.Secant(-2.5, 2.5);
            var part_fraction = numerical_methods.PartFraction(-2.5, 2.5);
            var iter = numerical_methods.SimpleIteration(-2.5, 2.5);

            var newton = numerical_methods.Newton(-2.5, 2.5);
            Console.WriteLine("Chord|Secant|Part_fraction|SimpleIter|newton");
            for(int i = 0; i<chord.Count; i++)
            {
                Console.WriteLine($"{chord[i]}|{secant[i]}|{part_fraction[i]}|" +
                    $"{iter[i]}|{newton[i]}");
            }
        }
    }
}
