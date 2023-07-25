using System;
using System.Linq;

namespace P05AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToArray();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }
                else if (command == "print")
                {
                    numbers.ToList()
                           .ForEach(x => Console.Write(x + " "));

                    Console.WriteLine();
                }
                else
                {
                    numbers = numbers.Select(FuncSwitch(command))
                                     .ToArray();
                }
            }
        }

        static Func<int, int> FuncSwitch(string command) 
        {
            Func<int, int> myFunc = x => x;

            if (command == "add")
            {
                myFunc = x => x + 1;
            }
            else if (command == "multiply")
            {
                myFunc = x => x * 2;
            }
            else if (command == "subtract")
            {
                myFunc = x => x - 1;
            }

            return myFunc;
        }
    }
}
