using System;
using System.Collections;

namespace P06Supermarket
{
    class P06Supermarket
    {
        static void Main(string[] args)
        {
            var superMarketQueue = new Queue();

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }
                else if (command == "Paid")
                {
                    while (superMarketQueue.Count > 0)
                    {
                        Console.WriteLine(superMarketQueue.Dequeue());
                    }
                }
                else
                {
                    superMarketQueue.Enqueue(command);
                }
            }

            Console.WriteLine($"{superMarketQueue.Count} people remaining.");
        }
    }
}
