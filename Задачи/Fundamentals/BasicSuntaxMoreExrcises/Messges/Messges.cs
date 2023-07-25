using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messges
{
    class Messges
    {
        static void Main(string[] args)
        {
            string currentNumber = "toshko";
            int counter = 0;

            while (true)
            {
                currentNumber = Console.ReadLine();

                if (counter != 0)
                {

                    if (currentNumber[0] == '2')
                    {
                        if (currentNumber.Length == 1)
                        {
                            Console.Write("a");
                        }
                        else if (currentNumber.Length == 2)
                        {
                            Console.Write("b");
                        }
                        else if (currentNumber.Length == 3)
                        {
                            Console.Write("c");
                        }
                    }
                    else if (currentNumber[0] == '3')
                    {
                        if (currentNumber.Length == 1)
                        {
                            Console.Write("d");
                        }
                        else if (currentNumber.Length == 2)
                        {
                            Console.Write("e");
                        }
                        else if (currentNumber.Length == 3)
                        {
                            Console.Write("f");
                        }
                    }
                    else if (currentNumber[0] == '4')
                    {
                        if (currentNumber.Length == 1)
                        {
                            Console.Write("g");
                        }
                        else if (currentNumber.Length == 2)
                        {
                            Console.Write("h");
                        }
                        else if (currentNumber.Length == 3)
                        {
                            Console.Write("i");
                        }
                    }
                    else if (currentNumber[0] == '5')
                    {
                        if (currentNumber.Length == 1)
                        {
                            Console.Write("j");
                        }
                        else if (currentNumber.Length == 2)
                        {
                            Console.Write("k");
                        }
                        else if (currentNumber.Length == 3)
                        {
                            Console.Write("l");
                        }
                    }
                    else if (currentNumber[0] == '6')
                    {
                        if (currentNumber.Length == 1)
                        {
                            Console.Write("m");
                        }
                        else if (currentNumber.Length == 2)
                        {
                            Console.Write("n");
                        }
                        else if (currentNumber.Length == 3)
                        {
                            Console.Write("o");
                        }
                    }
                    else if (currentNumber[0] == '7')
                    {
                        if (currentNumber.Length == 1)
                        {
                            Console.Write("p");
                        }
                        else if (currentNumber.Length == 2)
                        {
                            Console.Write("q");
                        }
                        else if (currentNumber.Length == 3)
                        {
                            Console.Write("r");
                        }
                        else if (currentNumber.Length == 4)
                        {
                            Console.Write("s");
                        }
                    }
                    else if (currentNumber[0] == '8')
                    {
                        if (currentNumber.Length == 1)
                        {
                            Console.Write("t");
                        }
                        else if (currentNumber.Length == 2)
                        {
                            Console.Write("u");
                        }
                        else if (currentNumber.Length == 3)
                        {
                            Console.Write("v");
                        }
                    }
                    else if (currentNumber[0] == '9')
                    {
                        if (currentNumber.Length == 1)
                        {
                            Console.Write("w");
                        }
                        else if (currentNumber.Length == 2)
                        {
                            Console.Write("x");
                        }
                        else if (currentNumber.Length == 3)
                        {
                            Console.Write("y");
                        }
                        else if (currentNumber.Length == 4)
                        {
                            Console.Write("z");
                        }
                    }
                    else if (currentNumber[0] == '0')
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                counter++;
            }

        }
    }
}
