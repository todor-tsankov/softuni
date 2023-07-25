using System;
using System.Collections.Generic;

namespace SetsDictionaries_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            var uniqueUsernames = new HashSet<string>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var currentUsername = Console.ReadLine();

                uniqueUsernames.Add(currentUsername);
            }

            foreach (var item in uniqueUsernames)
            {
                Console.WriteLine(item);
            }
        }
    }
}
