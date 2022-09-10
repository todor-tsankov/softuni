using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionalStatements_exercises
{
    class SumSeconds
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int wholeTimeSeconds = firstTime + secondTime + thirdTime;
            int minutes = 0;
            int seconds = 00;

            if (wholeTimeSeconds >= 60)
            {
                minutes = wholeTimeSeconds / 60;
                seconds = wholeTimeSeconds % 60;
            }
            else
            {
                seconds = wholeTimeSeconds;
            }

            Console.WriteLine($"{minutes}:{seconds.ToString("D2")}");
               
           
        }
    }
}
