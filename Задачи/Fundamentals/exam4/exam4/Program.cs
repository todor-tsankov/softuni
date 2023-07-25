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
            double limit = 60;


            for (int i = 0; i < n; i++)
            {
                double spentMOney = 0;
                bool dayOver = false;
                int productsCounter = 0;

                while (spentMOney < limit)
                {
                    string priceProduct = Console.ReadLine();

                    if (priceProduct == "Day over")
                    {
                        dayOver = true;
                        break;
                    }
                    if (spentMOney + double.Parse(priceProduct) > limit)
                    {
                        continue;
                    }
                    productsCounter++;
                    spentMOney += double.Parse(priceProduct);
                }

                if (dayOver)
                {
                    
                    Console.WriteLine($"Money left from today: {limit - spentMOney:f2}. You've bought {productsCounter} products.");
                    limit = limit - spentMOney + 60;
                }
                else
                {
                    limit = 60;
                    Console.WriteLine($"Daily limit exceeded! You've bought {productsCounter} products.");
                }
            }
        }
    }
}
