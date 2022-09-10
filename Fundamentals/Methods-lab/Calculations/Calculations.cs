using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    class Calculations
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            double x1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    Add(x1, x2);
                    break;
                case "subtract":
                    Subtract(x1, x2);
                        break;
                case "multiply":
                    Multiply(x1, x2);
                    break;
                case "divide":
                    Divide(x1, x2);
                    break;
            }
        }

        static void Add(double x1, double x2)
        {
            Console.WriteLine(x1 + x2);
        }

        static void Subtract(double x1, double x2)
        {
            Console.WriteLine(x1 - x2);
        }

        static void Multiply(double x1, double x2)
        {
            Console.WriteLine(x1 * x2);
        }

        static void Divide(double x1, double x2)
        {
            Console.WriteLine(x1 / x2);
        }
    }
}
