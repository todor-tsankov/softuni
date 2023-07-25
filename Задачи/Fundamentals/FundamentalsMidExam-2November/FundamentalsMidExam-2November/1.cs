using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundamentalsMidExam_2November
{
    class Program
    {
        static void Main(string[] args)
        {
            double neededExperience = double.Parse(Console.ReadLine());
            int countBattles = int.Parse(Console.ReadLine());
            double gainedExperience = 0;
            int counter = 0;

            for (int i = 1; i <= countBattles; i++)
            {
                double currentExprience = Double.Parse(Console.ReadLine());

                if (i % 3 == 0)
                {
                    currentExprience *= 1.15;
                }

                if (i % 5 == 0)
                {
                    currentExprience *= 0.90;
                }

                gainedExperience += currentExprience;
                counter++;

                if (gainedExperience >= neededExperience)
                {
                    break;
                }
            }

            if (gainedExperience >= neededExperience)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {counter} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {neededExperience - gainedExperience:f2} more needed.");
            }
        }
    }
}
