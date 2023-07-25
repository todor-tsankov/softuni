using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball
{
    class Volleyball
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int p = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());

            int weekends = 48;
            double totalTimesPlayed = (2 / 3.0) * p + h + (3 / 4.0) * (48 - h);


            switch (year)
            {
                case "leap":
                    totalTimesPlayed *= 1.15;
                    break;
            }
            totalTimesPlayed = Math.Floor(totalTimesPlayed);
            Console.WriteLine(totalTimesPlayed);
        }
    }
}
