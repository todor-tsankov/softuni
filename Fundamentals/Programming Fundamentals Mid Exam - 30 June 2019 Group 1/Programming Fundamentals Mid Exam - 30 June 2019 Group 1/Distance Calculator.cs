using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Fundamentals_Mid_Exam___30_June_2019_Group_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double stepLength = double.Parse(Console.ReadLine());   // centimeters
            int finalDistance = int.Parse(Console.ReadLine());      // meters

            double traveledDistance = 0;
            
            for (int i = 1; i <= stepsMade; i++)
            {
                if (i % 5 == 0)
                {
                    traveledDistance += stepLength * 0.7;
                }
                else
                {
                    traveledDistance += stepLength;
                }
            }

            double percentage = traveledDistance / finalDistance;

            Console.WriteLine($"You travelled {percentage:f2}% of the distance!");
        }
    }
}
