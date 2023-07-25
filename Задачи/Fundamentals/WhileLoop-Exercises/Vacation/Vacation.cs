using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vacation
{
    class Vacation
    {
        static void Main(string[] args)
        {
            double moneyNeededVacation = double.Parse(Console.ReadLine());
            double moneyAvaible = double.Parse(Console.ReadLine());
            string spendOrSave = string.Empty;
            double sum = 0;
            int counterDays = 0;
            int counterSpendDays = 0;
            bool savedTheMoney = false;
            bool notSavedTheMoney = false;

            while (true)
            {
                spendOrSave = Console.ReadLine();
                sum = double.Parse(Console.ReadLine());
                counterDays++;

                if (spendOrSave == "save")
                {
                    moneyAvaible += sum;
                    counterSpendDays = 0;
                }
                else if (spendOrSave == "spend" && moneyAvaible >= sum)
                {
                    moneyAvaible -= sum;
                    counterSpendDays++;
                }
                else
                {
                    moneyAvaible = 0;
                    counterSpendDays++;
                }

                if (moneyAvaible >= moneyNeededVacation)
                {
                    savedTheMoney = true;
                    break;
                }

                if (counterSpendDays == 5)
                {
                    notSavedTheMoney = true;
                    break;
                }

            }

            if (savedTheMoney)
            {
                Console.WriteLine($"You saved the money for {counterDays} days.");
            }
            else if (notSavedTheMoney)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(counterDays);
            }
        }
    }
}
