using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumPrimeNonPrime
{
    class SumPrimeNonPrimeProgram
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            double finalAverage = 0;
            string namePresentaion = Console.ReadLine();

            while (namePresentaion != "Finish")
            {
                double average = 0;

                for (int i = 0; i < n; i++)
                {
                    average += int.Parse(Console.ReadLine());
                }

                average /= n;
                Console.WriteLine($"{namePresentaion} - {average}.");
                counter++;
                finalAverage += average;
                namePresentaion = Console.ReadLine();
            }

            finalAverage /= counter;
            Console.WriteLine($"Student's final assessment is {finalAverage}." );
        }
    }
}
