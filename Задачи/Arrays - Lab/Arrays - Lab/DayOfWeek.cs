using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays___Lab
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            int dayNumber = int.Parse(Console.ReadLine());

            string[] daysOfWeek = new string[] { "Monday","Tuesday","Wednesday","Thursday","Friday","Saturday","Sunday" };

            if (dayNumber > 0 && dayNumber <= 7)
            {
                Console.WriteLine(daysOfWeek[dayNumber-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
