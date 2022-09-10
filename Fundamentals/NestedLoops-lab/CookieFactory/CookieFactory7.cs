using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieFactory
{
    class CookieFactory7
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 0;
            int batchCouner = 0;

            for (int i = 0; i < n; i++)
            {
                string ingredient = string.Empty;
                
                while (ingredient != "Bake!")
                {

                    switch (ingredient)
                    {
                        case "flour":
                        case "eggs":
                        case "sugar":
                            counter++;
                            break;
                    }
                    ingredient = Console.ReadLine();

                }

                if (counter >= 3)
                {
                    batchCouner++;
                    Console.WriteLine($"Baking batch number {batchCouner}...");
                    counter = 0;
                }
                else
                {
                    Console.WriteLine("The batter should contain flour, eggs and sugar!");
                }
            }
        }
    }
}
