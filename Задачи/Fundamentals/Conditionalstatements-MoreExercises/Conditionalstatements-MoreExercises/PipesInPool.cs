using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conditionalstatements_MoreExercises
{
    class PipesInPool
    {
        static void Main()
        {
            double volume = double.Parse(Console.ReadLine());
            double firstPipeFlow = double.Parse(Console.ReadLine());
            double secondPipeFlow = double.Parse(Console.ReadLine());
            double hours = double.Parse(Console.ReadLine());

            double totalWaterFirstPipe = firstPipeFlow * hours;
            double totalwaterSecondPipe = secondPipeFlow * hours;
            double totalAddedWater = totalWaterFirstPipe + totalwaterSecondPipe;

            if (totalAddedWater <= volume)
            {
                Console.WriteLine($"The pool is {(totalAddedWater / volume) * 100:f2}% full." +
                    $" Pipe 1: {((double)totalWaterFirstPipe / totalAddedWater) * 100:F2}%. Pipe 2: {(double)totalwaterSecondPipe /totalAddedWater * 100:F2}%.");
            }
            else
            {
                Console.WriteLine($"For {hours:f2} hours the pool overflows with {totalAddedWater - volume:f2} liters.");
            }

        }
    }
}
