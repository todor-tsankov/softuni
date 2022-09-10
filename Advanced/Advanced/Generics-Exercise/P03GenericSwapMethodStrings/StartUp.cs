using System;
using System.Collections.Generic;
using System.Linq;

namespace P03GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var list = new List<Box<int>>();

            for (int i = 0; i < n; i++)
            {
                list.Add(new Box<int>(int.Parse(Console.ReadLine())));
            }

            var swapCommand = Console.ReadLine()
                                     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                     .Select(int.Parse)
                                     .ToArray();

            Swap(list, swapCommand[0], swapCommand[1]);

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }
        static void Swap<T>(List<T> list, int index1, int index2)
        {
            var first = list[index1];

            list[index1] = list[index2];
            list[index2] = first;
        }
    }
}
