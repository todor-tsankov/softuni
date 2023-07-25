using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputElements = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToArray();

            var enqueue = inputElements[0];
            var dequeue = inputElements[1];
            var find = inputElements[2];

            var inputIntegers = Console.ReadLine()
                                       .Split()
                                       .Select(int.Parse)
                                       .ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < enqueue; i++)
            {
                queue.Enqueue(inputIntegers[i]);
            }

            for (int i = 0; i < dequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(find))
            {
                Console.WriteLine("true");
            }
            else if (!queue.Any())
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
