using System;
using System.Collections.Generic;
using System.Text;

namespace P04HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal GetTotalPrice(decimal pricePerDay, int days, Season season, Discount discount)
        {
            var totalPrice = days * pricePerDay * (int)season;
            totalPrice -= totalPrice * (int)discount / 100;

            return totalPrice;
        }
    }
}
