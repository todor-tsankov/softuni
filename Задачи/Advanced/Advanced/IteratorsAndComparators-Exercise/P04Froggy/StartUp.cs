using System;
using System.Collections.Generic;
using System.Linq;

namespace P04Froggy
{
    public class StartUp
    {
        static void Main()
        {
            var inputNumbers = Console.ReadLine()
                                      .Split(", ")
                                      .Select(int.Parse)
                                      .ToArray();

            var evenPositionNumbers = new List<int>();
            var oddPositionNumbers = new List<int>();

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                var currentNumber = inputNumbers[i];

                if (i % 2 == 0)
                {
                    evenPositionNumbers.Add(currentNumber);
                }
                else
                {
                    oddPositionNumbers.Add(currentNumber);
                }
            }

            var allNumbers = new Lake(evenPositionNumbers);

            oddPositionNumbers.Reverse();

            foreach (var item in oddPositionNumbers)
            {
                allNumbers.Items.Add(item);
            }

            Console.WriteLine(string.Join(", ", allNumbers.Items));
        }
    }
}
