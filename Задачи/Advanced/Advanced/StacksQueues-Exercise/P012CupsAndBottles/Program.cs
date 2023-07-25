using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace P012CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            var cupsCapacitySequence = Console.ReadLine()
                                              .Split()
                                              .Select(int.Parse);

            var bottlesCapacitySequence = Console.ReadLine()
                                                 .Split()
                                                 .Select(int.Parse);

            var cups = new Queue<int>(cupsCapacitySequence);
            var bottles = new Stack<int>(bottlesCapacitySequence);

            var countCups = cups.Count;
            var wastedWater = 0;

            var currentCup = cups.Peek();

            while (cups.Any() && bottles.Any())
            {
                var currentBottle = bottles.Pop();
                currentCup -= currentBottle;

                if (currentCup <= 0)
                {
                    wastedWater -= currentCup;

                    cups.Dequeue();

                    if (cups.Any())
                    {
                        currentCup = cups.Peek();
                    }
                }
            }

            if (!bottles.Any())
            {
                var outPut = string.Join(" ", cups);

                Console.WriteLine($"Cups: {outPut}");
            }
            else
            {
                var outPut = string.Join(" ", bottles);

                Console.WriteLine($"Bottles: {outPut}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");

        }
    }
}
