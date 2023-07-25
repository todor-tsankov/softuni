using System;

namespace Technology_Fundamentals_Mid_Exam___10_March_2019_Group_2
{
    class TheHuntingGames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countPlayers = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayOnePerson = double.Parse(Console.ReadLine());
            double foodPerDayOnePerson = double.Parse(Console.ReadLine());

            double allWater = countPlayers * n * waterPerDayOnePerson;
            double allFood = countPlayers * n * foodPerDayOnePerson;
            bool enoughEnergy = true;

            for (int i = 1; i <= n; i++)
            {
                double currentenergyLoss = double.Parse(Console.ReadLine());
                groupEnergy -= currentenergyLoss;

                if (groupEnergy <= 0)
                {
                    enoughEnergy = false;
                    break;
                }

                if (i % 2 == 0)
                {
                    groupEnergy *= 1.05;
                    allWater *= 0.70;
                }

                if (i % 3 == 0)
                {
                    allFood -= allFood / countPlayers;
                    groupEnergy *= 1.10;
                }
            }

            if (enoughEnergy)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {allFood:f2} food and {allWater:f2} water.");
            }
        }
    }
}
