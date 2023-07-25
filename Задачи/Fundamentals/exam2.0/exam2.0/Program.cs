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
            int n = int.Parse(Console.ReadLine());
            int productsCounter = 0;

            for (int i = 0; i < n; i++)
            {
                double spentMOney = 0;
                bool dayOver = false;
                while (spentMOney < 60)
                {
                    string priceProduct = Console.ReadLine();
                    if (priceProduct == "Day over")
                    {
                        dayOver = true;
                        break;
                    }
                    productsCounter++;
                    spentMOney += double.Parse(priceProduct);
                }

                if (dayOver)
                {
                    Console.WriteLine($"Money left from today: {60 - spentMOney:f2}. You've bought {productsCounter} products.");
                }
                else
                {
                    Console.WriteLine($"Daily limit exceeded! You've bought {productsCounter} products.");
                }
            }
        }
    }
}
