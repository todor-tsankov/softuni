using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTime
{
    class OnTime
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMinutes = int.Parse(Console.ReadLine());
            int arrivalHour = int.Parse(Console.ReadLine());
            int arrivalMinutes = int.Parse(Console.ReadLine());
            int totalExamMinutes = examMinutes + examHour * 60;
            int totalArrivalMinutes = arrivalMinutes + arrivalHour * 60;

            int diff = totalExamMinutes - totalArrivalMinutes;

            if (totalExamMinutes < totalArrivalMinutes)
            {
                Console.WriteLine("Late");
                if (Math.Abs(diff) < 60)
                {
                    Console.WriteLine($"{Math.Abs(diff)} minutes after the start");
                }
                else
                {
                    int hh = Math.Abs(diff) / 60;
                    int mm = Math.Abs(diff) % 60;
                    Console.WriteLine($"{hh}:{mm:d2} hours after the start");
                }
                
            }
            else if (totalArrivalMinutes == totalExamMinutes)
            {
                Console.WriteLine("On Time"); 
            }
            else if (diff <= 30 && diff >= 0)
            {
                Console.WriteLine("On Time");
                Console.WriteLine($"{diff} minutes before the start");
            }
            else
            {
                Console.WriteLine("Early");
                if (diff < 60)
                {
                    Console.WriteLine($"{diff} minutes before the start");
                }
                else
                {
                    int hh = diff / 60;
                    int mm = diff % 60;
                    Console.WriteLine($"{hh}:{mm:d2} hours before the start");
                }

            }

            
        }
    }
}
