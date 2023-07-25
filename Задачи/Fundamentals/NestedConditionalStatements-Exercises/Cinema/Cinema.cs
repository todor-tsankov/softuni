using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema
{
    class Cinema
    {
        static void Main(string[] args)
        {
            string typeProjection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            int numberTickets = rows * columns;
            double profit = numberTickets;

            switch (typeProjection)
            {
                case "Premiere":
                    profit *= 12.00;
                    break;
                case "Normal":
                    profit *= 7.50;
                    break;
                case "Discount":
                    profit *= 5.00; 
                    break;
            }

            Console.WriteLine($"{profit:f2} leva");
        }
    }
}
