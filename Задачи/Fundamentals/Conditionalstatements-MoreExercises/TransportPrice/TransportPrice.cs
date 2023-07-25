using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportPrice
{
    class TransportPrice
    {
        static void Main(string[] args)
        {
            int kilometres = int.Parse(Console.ReadLine());
            string dayOrNight = Console.ReadLine();
            double price = 0.0;


            if (kilometres < 20)
            {
                switch (dayOrNight)
                {
                    case "day":
                        price = 0.70 + 0.79 * kilometres;
                        break;
                    case "night":
                        price = 0.70 + 0.90 * kilometres;
                        break;
                }
            }
            else if (kilometres < 100)
            {
                price = 0.09 * kilometres;
            }
            else
            {
                price = 0.06 * kilometres;
            }

            Console.WriteLine(price.ToString("F2"));
        }
    }
}
