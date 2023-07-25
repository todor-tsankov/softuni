using System;

namespace Debug
{
    class DebugMe
    {
        static void Main(string[] args)
        {
            int moneyForToys = 0;
            int kidsCount = 0;
            int moneyForSweaters = 0;
            int adultsCount = 0;
            string command = "k";

            while (command != "Christmas")
            {
                command = Console.ReadLine();
                if (command == "Christmas")
                {
                    break;

                }
                int years = int.Parse(command);
                if (years <= 16)
                {
                    moneyForToys += 5;
                    kidsCount++;
                }
                else
                {
                    moneyForSweaters += 15;
                    adultsCount++;
                }
            }

            Console.WriteLine($"Number of adults: {adultsCount}");
            Console.WriteLine($"Number of kids: {kidsCount}");
            Console.WriteLine($"Money for toys: {moneyForToys}");
            Console.WriteLine($"Money for sweaters: {moneyForSweaters}");
        }
    }
}
