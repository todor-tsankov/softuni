using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculus
{
    class Calculus
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string firstNumber = string.Empty;
            string secondNumber = string.Empty;
            bool firstOrSecond = true;
            bool plus = false;
            bool minus = false;
            bool multi = false;
            bool devide = false;

            for (int i = 0; i < input.Length; i++)
            {
                switch (input)
                {
                    case "0":
                    case "1":
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case ".":
                        if (firstOrSecond)
                        {
                            firstNumber += input;
                        }
                        else
                        {
                            secondNumber += input;
                        }

                        break;
                    case "+":
                        plus = true;
                        firstOrSecond = false;
                        break;
                    case "-":
                        minus = true;
                        firstOrSecond = false;
                        break;
                    case "*":
                        multi = true;
                        firstOrSecond = false;
                        break;
                    case "/":
                        devide = true;
                        firstOrSecond = false;
                        break;
                }
            }

            double first = double.Parse(firstNumber);
            double second = double.Parse(secondNumber);

            if (plus)
            {
                Console.WriteLine($"= {first + second}");
            }
            if (minus)
            {
                Console.WriteLine($"= {first - second}");
            }
            if (multi)
            {
                Console.WriteLine($"= {first * second }");
            }
            if (devide)
            {
                Console.WriteLine($"= {first / second}");
            }
        }
    }
}
