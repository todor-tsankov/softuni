using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoom
{
    class HotelRoom
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double apartmentPrice = nights;
            double studioPrice = nights;

            switch (month)
            {
                case "May":
                case "October":
                    apartmentPrice *= 65;
                    studioPrice *= 50;
                    if (nights > 7 && nights < 14)
                    {
                        studioPrice *= 0.95;
                    }
                    else if (nights >= 14)
                    {
                        studioPrice *= 0.70;
                    }
                    if (nights > 14)
                    {
                        apartmentPrice *= 0.90;
                    }
                    break;
                case "June":
                case "September":
                    apartmentPrice *= 68.7;
                    studioPrice *= 75.2;
                    if (nights > 14)
                    {
                        studioPrice *= 0.80;
                    }
                    if (nights > 14)
                    {
                        apartmentPrice *= 0.90;
                    }
                        break;
                case "July":
                case "August":
                    apartmentPrice *= 77;
                    studioPrice *= 76;
                    if (nights > 14)
                    {
                        apartmentPrice *= 0.90;
                    }
                        break;
            }

            Console.WriteLine($"Apartment: {apartmentPrice:f2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
