using System;
using System.Collections.Generic;

namespace P05GenericCountMethodStrings
{
    public class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var elements = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                var current = new Box<string>(Console.ReadLine());

                elements.Add(current);
            }

            var comparator = Console.ReadLine();

            Console.WriteLine(FindCount(elements, comparator));
        }

        static int FindCount<T>(List<Box<T>> elements, T comparator)
        {
            var count = 0;

            foreach (var box in elements)
            {
                if (box.IsGreaterThan(comparator))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
