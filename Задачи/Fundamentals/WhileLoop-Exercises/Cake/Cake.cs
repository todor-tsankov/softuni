using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake
{
    class Cake
    {
        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int numberPieces = x * y;  // = area
            int takenPieces = 0;
            string newTaken = "";
            bool enough = false;

            while (numberPieces >= takenPieces)
            {
                newTaken = Console.ReadLine();
                if (newTaken == "STOP")
                {
                    enough = true;
                    break;
                }
                
                takenPieces += int.Parse(newTaken);
            }

            if (!enough)
            {
                Console.WriteLine($"No more cake left! You need {takenPieces - numberPieces} pieces more.");
            }
            else if (enough)
            {
                Console.WriteLine($"{numberPieces - takenPieces} pieces are left.");
            }
        }
    }
}
