using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReoprtSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            int expectedSum = int.Parse(Console.ReadLine());
            int counter = 0;
            int profit = 0;
            string command = "0";
            int transaction = 0;
            int cashSum = 0;
            int cardSum = 0;
            bool successful = false;
            int counterCash = 0;
            int counterCard = 0;

            while (expectedSum >= profit && command != "End")
            {
                counter++;
                command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }
                successful = false;
                transaction = int.Parse(command);
                if (counter % 2 == 0)
                {
                    if (transaction < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else 
                    {
                        Console.WriteLine("Product sold!");
                        cardSum += transaction;
                        successful = true;
                        counterCard++;
                    }
                }
                else
                {
                    if (transaction > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        cashSum += transaction;
                        successful = true;
                        counterCash++;
                    }
                }

                if (successful)
                {
                    profit += transaction;
                }

                if (expectedSum <= profit)
                {
                    break;
                }
               
            }

            if (command == "End")
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
            else if (expectedSum <= profit)
            {
                Console.WriteLine($"Average CS: {((double) cashSum / counterCash):f2}");
                Console.WriteLine($"Average CC: {((double)cardSum /counterCard):f2}");
            }
        }
    }
}
