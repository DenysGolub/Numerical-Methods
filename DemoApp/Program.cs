using NumericalMethods;
using System.ComponentModel;

namespace DemoApp
{
    internal class Program
    {
        static double F(double x)
        {
            return Math.Cos(x) + x * x;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Differention differention = new Differention();

            double number = 5.12;
            Console.WriteLine($"Похідна у точці '{number}': {differention.FirstDiff(F, number)}");
        }
    }
}
