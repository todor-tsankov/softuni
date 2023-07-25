using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harvest
{
    class Harvest
    {
        static void Main()
        {
            int area = int.Parse(Console.ReadLine());
            double grapesPerMeter = double.Parse(Console.ReadLine());
            int litresWineNeeded = int.Parse(Console.ReadLine());
            int numWorkers = int.Parse(Console.ReadLine());

            double totalGrapes = grapesPerMeter * area;
            double totalLitresWine = totalGrapes / 2.5 * 0.4;
            double difference = Math.Abs(totalLitresWine - litresWineNeeded);

            if (totalLitresWine < litresWineNeeded)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(difference)} liters wine needed.");
            }
            else
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(totalLitresWine)} liters.");
                Console.WriteLine($"{Math.Ceiling(difference)} liters left -> {Math.Ceiling((double)difference/numWorkers)} liters per person.");
            }

        }
    }
}
