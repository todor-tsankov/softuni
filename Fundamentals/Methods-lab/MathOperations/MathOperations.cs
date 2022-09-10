using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathOperations
{
    class MathOperations
    {
        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            string op = Console.ReadLine();
            double x2 = double.Parse(Console.ReadLine());

            double result = Calculus(x1, op, x2);
            Console.WriteLine(Math.Round(result, 2));
        }

        static double Calculus(double x1, string op, double x2)
        {
            double result = 0;

            switch (op)
            {
                case "+":
                    result = x1 + x2;
                    break;
                case "-":
                    result = x1 - x2;
                    break;
                case "*":
                    result = x1 * x2;
                    break;
                case "/":
                    result = x1 / x2;
                    break;
            }
            return result;
        }
    }
}
