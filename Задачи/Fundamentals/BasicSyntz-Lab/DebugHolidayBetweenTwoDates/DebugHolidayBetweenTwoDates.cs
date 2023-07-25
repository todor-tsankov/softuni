using System;
using System.Globalization;

class HolidaysBetweenTwoDates
{
    static void Main()
    {
        DateTime startDate = DateTime.ParseExact(Console.ReadLine() , ("dd.MM.yyyy"), CultureInfo.CurrentCulture);
        DateTime endDate = DateTime.ParseExact(Console.ReadLine(), ("dd.MM.yyyy"), CultureInfo.CurrentCulture);



        int holidaysCount = 0;

        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1.0))
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                holidaysCount++;
            }
        }

        Console.WriteLine(holidaysCount);
    }
}
