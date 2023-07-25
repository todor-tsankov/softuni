using System;
using System.Collections.Generic;
using System.Linq;

namespace P07TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pumps = new Queue<Pump>();

            for (int i = 0; i < n; i++)
            {
                var pumpInfoArgs = Console.ReadLine()
                                          .Split()
                                          .Select(int.Parse)
                                          .ToArray();

                var amount = pumpInfoArgs[0];
                var distance = pumpInfoArgs[1];

                pumps.Enqueue(new Pump(amount, distance));
            }

            for (int i = 0; i < n; i++)
            {
                var winner = true;
                var currentPump = pumps.Dequeue();
                var totalFuel = 0;

                for (int j = 0; j < n; j++)
                {
                    totalFuel += currentPump.Amount;

                    if (totalFuel < currentPump.Distance)
                    {
                        winner = false;
                    }
                    else
                    {
                        totalFuel -= currentPump.Distance;
                    }

                    pumps.Enqueue(currentPump);
                    currentPump = pumps.Dequeue();
                }

                pumps.Enqueue(currentPump);

                if (winner)
                {
                    Console.WriteLine(i);
                    break;
                }
            }

        }
    }

    class Pump
    {
        public Pump(int amount, int distance)
        {
            this.Amount = amount;
            this.Distance = distance;
        }
        public int Amount { get; set; }
        public int Distance { get; set; }
    }
}
