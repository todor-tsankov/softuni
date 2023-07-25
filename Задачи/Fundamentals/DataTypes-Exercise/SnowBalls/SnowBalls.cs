using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SnowBalls
{
    class SnowBalls
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());
            int bestSnow = 0;
            int bestTime = 0;
            int bestQuality = 0;
            BigInteger bestValue = 0;

            for (int i = 0; i < numberOfSnowballs; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);

                if (snowballValue > bestValue)
                {
                    bestSnow = snowballSnow;
                    bestTime = snowballTime;
                    bestQuality = snowballQuality;
                    bestValue = snowballValue;
                }

            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {bestValue} ({bestQuality})");

        }
    }
}
