using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverLily
{
    class CleverLily
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            int oneToyPrice = int.Parse(Console.ReadLine());
            double money = 0;
            int moneyIncrease = 10;
            int toys = 0;
            double totalSavedMoney = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    money--;
                    money += moneyIncrease;
                    moneyIncrease += 10;
                }
                else
                {
                    toys++;
                }
            }

            totalSavedMoney = money + toys * oneToyPrice;
            double diff = Math.Abs(totalSavedMoney - washingMachinePrice);

            if (totalSavedMoney >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {diff:f2}" );
            }
            else
            {
                Console.WriteLine($"No! {diff:f2}");
            }

        }
    }
}
