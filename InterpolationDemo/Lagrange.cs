using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Lagrange
    {
        public static double LangrangeDouble(Point[] f, double xi, int n)
        {
            double result = 0; // Initialize result
            for (int i = 0; i < n; i++)
            {
                // Compute individual terms
                // of above formula
                double term = f[i].Y;
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                        term = term * (xi - f[j].X) /
                                (f[i].Y - f[j].X);
                }

                // Add current term to result
                result += term;
            }
            return result;
        }

        public static string LangrangeString(Point[] f, int n)
        {
            string result = ""; // Initialize result
            for (int i = 0; i < n; i++)
            {
                // Compute individual terms
                // of above formula
                string term = f[i].Y.ToString();
                string up = "";
                string denom = "";
                for (int j = 0; j < n; j++)
                {
                    if (j != i)
                    {
                        up += $"(x-{f[j].X})*";
                        denom += $"({f[i].X}-{f[j].X})*";
                    }
                }
                up = up.Substring(0, up.Length - 1);
                denom = denom.Substring(0, denom.Length - 1);

                result += term + "*" + $"({up})/({denom})";
                //Console.WriteLine(term + "*" + $"{up}/{denom}");
                result += "+";
            }
            result = result.Substring(0, result.Length - 1);
            Console.WriteLine(result);

            return result;
        }
    }
}
