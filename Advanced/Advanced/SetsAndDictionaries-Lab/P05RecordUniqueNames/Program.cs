using System;
using System.Collections.Generic;

namespace P05RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var uniqueNames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var currentName = Console.ReadLine();

                uniqueNames.Add(currentName);
            }

            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
