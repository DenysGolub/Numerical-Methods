using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericalMethods
{
    public class Differention
    {
        public double FirstDiff(Func<double, double> func, double x)
        {
            return (func(x+0.0001)-func(x))/0.0001;
        }

        public double FirstDiffX(Func<double, double, double> func, double x, double y)
        {
            return (func(x + 0.0001, y) - func(x, y)) / 0.0001;
        }

        public double FirstDiffY(Func<double, double, double> func, double x, double y)
        {
            return (func(x,y+0.0001) - func(x, y)) / 0.0001;
        }

        public double SecondDiff(Func<double, double> func, double x, double h=10)
        {
            return (func(x + h) - 2 * func(x) + func(1 - h)) / Math.Pow(h, 2);
        }
    }
}
