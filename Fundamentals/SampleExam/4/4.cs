using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumSinger = int.Parse(Console.ReadLine());
            int numberGuests = 0;
            string command = string.Empty;
            double profit = 0;

            while (command != "The restaurant is full")
            {
                numberGuests += int.Parse(command);
                command = Console.ReadLine();
            }

            if (numberGuests < 5)
            {
                profit = numberGuests * 100;
            }
            else
            {
                profit = numberGuests * 70;
            }

            if (profit >= sumSinger)
            {
                Console.WriteLine($"You have {numberGuests} guests and {profit - sumSinger} leva left.");
            }
            else
            {
                Console.WriteLine($"You have {numberGuests} guests and {profit} leva income, but no singer.");
            }
        }
    }
}
