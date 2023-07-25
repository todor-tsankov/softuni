using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            var foodAmount = int.Parse(Console.ReadLine());

            var orders = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            var queue = new Queue<int>(orders);

            var biggestOrder = queue.Max();

            for (int i = 0; i < orders.Length; i++)
            {
                var currentOrder = queue.Peek();

                if (foodAmount >= currentOrder)
                {
                    queue.Dequeue();

                    foodAmount -= currentOrder;
                }
            }

            Console.WriteLine(biggestOrder);

            if (!queue.Any())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                var ordersLeft = "Orders left: " + string.Join(" ", queue);

                Console.WriteLine(ordersLeft);
            }
        }
    }
}
