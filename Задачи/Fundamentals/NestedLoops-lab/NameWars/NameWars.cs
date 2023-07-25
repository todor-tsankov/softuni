using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameWars
{
    class NameWars
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string winner = string.Empty;
            
            int maxPoints = int.MinValue;

            while (name != "STOP")
            {
                int points = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    points += name[i];
                }

                if (points > maxPoints)
                {
                    winner = name;
                    maxPoints = points;
                }
                name = Console.ReadLine();
            }

            Console.WriteLine($"Winner is {winner} - {maxPoints}!");
        }
    }
}
