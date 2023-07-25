using System;
using System.Linq;

namespace P03CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var smallestInt = Console.ReadLine()
                                     .Split()
                                     .Select(int.Parse)
                                     .Min();

            Console.WriteLine(smallestInt);
        }
    }
}
