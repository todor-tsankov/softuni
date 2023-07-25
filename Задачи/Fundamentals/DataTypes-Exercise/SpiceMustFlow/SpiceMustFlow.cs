using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceMustFlow
{
    class SpiceMustFlow
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int days = 0;
            int totalExtractedSpice = 0;

            while (yield >= 100)
            {
                totalExtractedSpice += yield - 26;
                yield -= 10;
                days++;
            }
            if (days != 0)
            {
                totalExtractedSpice -= 26;
            }
            
            Console.WriteLine(days);
            Console.WriteLine(totalExtractedSpice);
        }
    }
}
