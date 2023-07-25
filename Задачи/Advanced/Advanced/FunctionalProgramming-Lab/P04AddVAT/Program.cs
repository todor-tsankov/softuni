using System;
using System.Linq;

namespace P04AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                   .Split(", ")
                   .Select(double.Parse)
                   .Select(x => x * 1.2)
                   .ToList()
                   .ForEach(x => Console.WriteLine($"{x:F2}"));
        }
    }
}
