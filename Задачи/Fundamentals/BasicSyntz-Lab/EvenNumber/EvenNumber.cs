using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvenNumber
{
    class EvenNumber
    {
        static void Main(string[] args)
        {
            int number = 3;

            while (number % 2 != 0)
            {
                number = int.Parse(Console.ReadLine());

                if (number % 2 != 0)
                {
                    Console.WriteLine("Please write an even number.");
                }
            }
            Console.WriteLine("The number is: " + Math.Abs(number));
        }
    }
}
