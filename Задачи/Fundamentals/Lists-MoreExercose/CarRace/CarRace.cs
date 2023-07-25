using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRace
{
    class CarRace
    {
        static void Main(string[] args)
        {
            List<int> listOfTimeSteps = Console.ReadLine().Split().Select(int.Parse).ToList();
            double firstRacerTime = 0;
            double secondRacerTime = 0;
            int count = listOfTimeSteps.Count;

            for (int i = 0; i < count / 2; i++)
            {
                firstRacerTime += listOfTimeSteps[i];

                if (listOfTimeSteps[i] == 0)
                {
                    firstRacerTime *= 0.8;
                }
            }

            for (int i = count - 1; i > count / 2; i--)
            {
                secondRacerTime += listOfTimeSteps[i];

                if (listOfTimeSteps[i] == 0)
                {
                    secondRacerTime *= 0.8;
                }
            }

            
            if (firstRacerTime < secondRacerTime)
            {
                Console.WriteLine($"The winner is left with total time: {firstRacerTime}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {secondRacerTime}");
            }
        }
    }
}
