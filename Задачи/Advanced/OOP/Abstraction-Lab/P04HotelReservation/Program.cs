using System;

namespace P04HotelReservation
{
    public class Program
    {
        static void Main()
        {
            var reservationInfo = Console.ReadLine()
                                         .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var pricePerDay = decimal.Parse(reservationInfo[0]);
            var days = int.Parse(reservationInfo[1]);

            var season = Season.Autumn;
            var discount = Discount.None;

            var seasonString = reservationInfo[2];
            var discountString = "";

            if (reservationInfo.Length == 4)
            {
                discountString = reservationInfo[3];
            }

            if (seasonString == "Autumn")
            {
                season = Season.Autumn;
            }
            else if (seasonString == "Spring")
            {
                season = Season.Spring;
            }
            else if (seasonString == "Summer")
            {
                season = Season.Summer;
            }
            else if (seasonString == "Winter")
            {
                season = Season.Winter;
            }

            if (discountString == "SecondVisit")
            {
                discount = Discount.SecondTime;
            }
            else if (discountString == "VIP")
            {
                discount = Discount.VIP;
            }

            var totalPrice = PriceCalculator.GetTotalPrice(pricePerDay, days, season, discount);
            Console.WriteLine(totalPrice.ToString("f2"));
        }
    }
}
