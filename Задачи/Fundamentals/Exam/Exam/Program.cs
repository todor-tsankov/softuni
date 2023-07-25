using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPoints = int.Parse(Console.ReadLine());
            int moves = 0;
            string sector = string.Empty;
            bool bullsEye = false;

            while (totalPoints >= 0)
            {
                sector = Console.ReadLine();
                moves++;

                if (sector == "bullseye")
                {
                    bullsEye = true;
                    totalPoints = 0;
                    break;
                }
                int points = int.Parse(Console.ReadLine());

                switch (sector)
                {
                    case "number section":
                        totalPoints -= points;
                        break;
                    case "double ring":
                        totalPoints -= points * 2;
                        break;
                    case "triple ring":
                        totalPoints -= points * 3;
                        break;
                }
            }

            if (bullsEye == true)
            {
                Console.WriteLine($"Congratulations! You won the game with a bullseye in {moves} moves!");
            }
            else if (totalPoints == 0)
            {
                Console.WriteLine($"Congratulations! You won the game in {moves} moves!");
            }
            else
            {
                Console.WriteLine($"Sorry, you lost. Score difference: {totalPoints * -1}.");
            }
        }
    }
}
