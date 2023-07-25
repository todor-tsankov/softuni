using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firm
{
    class Firm
    {
        static void Main(string[] args)
        {
            int hoursNeeded = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int numWorkers = int.Parse(Console.ReadLine());

            double daysAvaible = days * 0.9;
            double hours = daysAvaible * 8;
            double extraHours = days * numWorkers * 2;
            double totalHours = hours + extraHours;
            double diff = Math.Abs(Math.Floor(totalHours) - hoursNeeded);
            
            if (totalHours >= hoursNeeded)
            {
                Console.WriteLine($"Yes!{diff} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{diff} hours needed.");
            }
            

    

        }
    }
}
