using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey
{
    class Journey
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            double moneySpent = budget;
            string destination = "";
            string typeHoliday = "";


            if (budget <= 100)
            {
               destination = "Bulgaria";
               switch (season)
                {
                    case "summer":
                        typeHoliday = "Camp";
                        moneySpent *= 0.30;
                        break;
                    case "winter":
                        typeHoliday = "Hotel";
                        moneySpent *= 0.70;
                        break;
                }
            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
                switch (season)
                {
                    case "summer":
                        typeHoliday = "Camp";
                            moneySpent *= 0.40;
                        break;
                    case "winter":
                        typeHoliday = "Hotel";
                        moneySpent *= 0.80;
                        break;
                }
            }
            else
            {
                destination = "Europe";
                typeHoliday = "Hotel";
                moneySpent *= 0.90;
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{ typeHoliday} - {moneySpent:f2}");
        }
    }
}
