using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandParts = command.Split();
                string operation = commandParts[0];

                if (operation == "Switch")
                {
                    int index = int.Parse(commandParts[1]);

                    if (index >= 0 && index < numberArray.Length)
                    {
                        numberArray[index] *= -1;
                    }
                }
                else if (operation == "Change")
                {
                    int index = int.Parse(commandParts[1]);

                    if (index >= 0 && index < numberArray.Length)
                    {
                        numberArray[index] = int.Parse(commandParts[2]);
                    }
                }
                else if (operation == "Sum")
                {
                    string operationTwo = commandParts[1];

                    if (operationTwo == "Negative")
                    {
                        PrintNegativeSum(numberArray);
                    }
                    else if (operationTwo == "Positive")
                    {
                        PrintPositiveSum(numberArray);
                    }
                    else if (operationTwo == "All")
                    {
                        PrinAllSum(numberArray);
                    }
                }
            }

            foreach (var item in numberArray)
            {
                if (item >= 0)
                {
                    Console.Write(item + " ");
                }
            }
        }

        static void PrintNegativeSum(int[] numberArray)
        {
            int sum = 0;

            foreach (var item in numberArray)
            {
                if (item < 0)
                {
                    sum += item;
                }
            }

            Console.WriteLine(sum);
        }

        static void PrintPositiveSum(int[] numberArray)
        {
            int sum = 0;

            foreach (var item in numberArray)
            {
                if (item >= 0)
                {
                    sum += item;
                }
            }

            Console.WriteLine(sum);
        }

        static void PrinAllSum(int[] numberArray)
        {
            int sum = 0;

            foreach (var item in numberArray)
            {
                    sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
