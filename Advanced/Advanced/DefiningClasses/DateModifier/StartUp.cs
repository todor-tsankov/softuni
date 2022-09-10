using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            var dateMod = new DateModifier();
            int daysDifference = dateMod.FindDifferenceDays(firstDate, secondDate);

            Console.WriteLine(daysDifference);
        }
    }
}
