using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSwimmingRecord
{
    class WorldSwimmingRecord
    {
        static void Main(string[] args)
        {
            double recordSeconds = double.Parse(Console.ReadLine());
            double distanceMeters = double.Parse(Console.ReadLine());
            double speedSeconds1m = double.Parse(Console.ReadLine());

            double addSeconds = Math.Floor(distanceMeters / 15) * 12.5;
            double timeIvan = distanceMeters * speedSeconds1m + addSeconds;

            if (timeIvan < recordSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {timeIvan:f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(timeIvan - recordSeconds):f2} seconds slower.");
            }


        }
    }
}
