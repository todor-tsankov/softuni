using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForLoop_MoreExercises
{
    class BackToThePast
    {
        static void Main()
        {
            double money = double.Parse(Console.ReadLine());
            int yaerToLive = int.Parse(Console.ReadLine());
            double neededMoney = 0;

            for (int i = 1800; i <= yaerToLive; i++)
            {
                if (i % 2 == 0)
                {
                    neededMoney += 12000;
                }
                else
                {
                    neededMoney += 12000 + 50 * (i - 1782);
                }
            }

            if (money >= neededMoney)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {money - neededMoney:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {neededMoney - money:f2} dollars to survive.");
            }
        }
    }
}
