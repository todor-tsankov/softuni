using System;
using System.Collections.Generic;

namespace P07HotPotato
{
    class P07HotPotato
    {
        static void Main(string[] args)
        {
            var childrenInput = Console.ReadLine()
                                       .Split();

            var n = int.Parse(Console.ReadLine());

            var children = new Queue<string>(childrenInput);
            var counter = 1;

            while (children.Count > 1)
            {
                if (counter == n)
                {
                    Console.WriteLine($"Removed {children.Dequeue()}");
                    counter = 0;
                }
                else
                {
                    children.Enqueue(children.Dequeue());
                }

                counter++;
            }

            Console.WriteLine($"Last is {children.Dequeue()}");
        }
    }
}
