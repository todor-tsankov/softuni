using System;
using System.Collections.Generic;
using System.Linq;

namespace P08TrafficJam
{
    class P08TrafficJam
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var command = Console.ReadLine();
            var cars = new Queue<string>();

            var totalCarsPassed = 0;

            while (command != "end")
            {
                if (command == "green")
                {
                    for (int i = 0; i < n && cars.Any(); i++)
                    {
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                        totalCarsPassed++;
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(totalCarsPassed + " cars passed the crossroads.");
        }
    }
}
