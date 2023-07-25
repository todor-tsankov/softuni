using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfIntervals
{
    class GameOfIntervals
    {
        static void Main()
        {
            double n = int.Parse(Console.ReadLine());
            double zero = 0;
            double ten = 0;
            double twenty = 0;
            double thirty = 0;
            double forty = 0;
            double invalid = 0;
            double totalPoints = 0;

            for (int i = 0; i < n; i++)
            {
                double currentNumber = int.Parse(Console.ReadLine());

                if (currentNumber < 0 || currentNumber > 50)
                {
                    totalPoints /= 2;
                    invalid++;
                }
                else if (currentNumber <= 9)
                {
                    totalPoints +=currentNumber * 0.2;
                    zero++;
                }
                else if (currentNumber <= 19)
                {
                    totalPoints += currentNumber * 0.3;
                    ten++;
                }
                else if (currentNumber <= 29)
                {
                    totalPoints += currentNumber * 0.4;
                    twenty++;
                }
                else if (currentNumber <= 39)
                {
                    totalPoints += 50;
                    thirty++;
                }
                else if (currentNumber <= 50)
                {
                    totalPoints += 100;
                    forty++;
                }
            }

            zero *= 100 / n;
            ten *= 100 / n;
            twenty *= 100 / n;
            thirty *= 100 / n;
            forty *= 100 / n;
            invalid *= 100 / n;

            Console.WriteLine($"{totalPoints:f2}");
            Console.WriteLine($"From 0 to 9: {zero:f2}%");
            Console.WriteLine($"From 10 to 19: {ten:f2}%");
            Console.WriteLine($"From 20 to 29: {twenty:f2}%");
            Console.WriteLine($"From 30 to 39: {thirty:f2}%");
            Console.WriteLine($"From 40 to 50: {forty:f2}%");
            Console.WriteLine($"Invalid numbers: {invalid:f2}%");
        }
    }
}
