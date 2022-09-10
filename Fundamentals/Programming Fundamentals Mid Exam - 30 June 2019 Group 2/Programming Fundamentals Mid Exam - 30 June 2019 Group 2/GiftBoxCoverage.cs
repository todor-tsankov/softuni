using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Fundamentals_Mid_Exam___30_June_2019_Group_2
{
    class GiftBoxCoverage
    {
        static void Main(string[] args)
        {
            double sizeOfSide = double.Parse(Console.ReadLine());
            int numberOfSheets = int.Parse(Console.ReadLine());
            double singleSheetArea = double.Parse(Console.ReadLine());

            double boxArea = sizeOfSide * sizeOfSide * 6;
            double sheetsArea = 0;

            for (int i = 1; i <= numberOfSheets; i++)
            {
                if (i % 3 == 0)
                {
                    sheetsArea += singleSheetArea * 0.25;
                }
                else
                {
                    sheetsArea += singleSheetArea;
                }
            }

            double percentage = sheetsArea / boxArea * 100;

            Console.WriteLine($"You can cover {percentage:f2}% of the box.");
        }
    }
}
