using System;
using System.Linq;

namespace TextProcessing_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string inputReverse = string.Join("",input.Reverse());
                Console.WriteLine($"{input} = {inputReverse}");
            }
        }
    }
}
