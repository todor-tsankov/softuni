using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charityCampaign
{
    class CharityCampaign
    {
        static void Main()
        {
            int days = Int32.Parse(Console.ReadLine());
            int chefs = Int32.Parse(Console.ReadLine());
            int cakes = Int32.Parse(Console.ReadLine());
            int wafers = Int32.Parse(Console.ReadLine());
            int pancakes = Int32.Parse(Console.ReadLine());

            double money = days * chefs * (cakes * 45 + wafers * 5.8 + pancakes * 3.2);
            double moneyLeft = money - money / 8;
            Console.WriteLine(moneyLeft.ToString("0.00"));
        }
    }
}
