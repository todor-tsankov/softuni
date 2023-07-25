using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepyTomCat
{
    class SleepyTomCat
    {
        static void Main(string[] args)
        {
            int numRestDays = int.Parse(Console.ReadLine());
            int numWorkDays = 365 - numRestDays;

            int totalTimeRestDays = numRestDays * 127;
            int totalTimeWorkdays = numWorkDays * 63;
            int totalTime = totalTimeRestDays + totalTimeWorkdays;
            int maxTime = 30000;
            int hours = Math.Abs((totalTime - maxTime) / 60);
            int minutes = Math.Abs((totalTime - maxTime) % 60);

            if (totalTime > maxTime)
            {
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }
            else if (totalTime < maxTime)
            {
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }


        }
    }
}
