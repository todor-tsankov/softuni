using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistics
{
    class Logistics
    {
        static void Main(string[] args)
        {
            double numberCargos = double.Parse(Console.ReadLine());
            double currentWeight = 0;
            double totalWeight = 0;
            double microbusTonsTransported = 0;
            double truckTonsTransported = 0;
            double trainTonsTransported = 0;
            double averagePrice = 0;

            for (int i = 0; i < numberCargos; i++)
            {
                currentWeight = double.Parse(Console.ReadLine());
                totalWeight += currentWeight;

                if (currentWeight <= 3)
                {
                    microbusTonsTransported += currentWeight;
                }
                else if (currentWeight <= 11)
                {
                    truckTonsTransported += currentWeight;
                }
                else
                {
                    trainTonsTransported += currentWeight;
                }
            }

            averagePrice = (microbusTonsTransported * 200 + truckTonsTransported * 175 + trainTonsTransported * 120) / totalWeight;

            Console.WriteLine($"{averagePrice:f2}");
            Console.WriteLine($"{microbusTonsTransported / totalWeight * 100:f2}%");
            Console.WriteLine($"{truckTonsTransported / totalWeight * 100:f2}%");
            Console.WriteLine($"{trainTonsTransported / totalWeight * 100:f2}%");
        }
    }
}
