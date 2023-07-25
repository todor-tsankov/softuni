using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalance
{
    class AccountBalance
    {
        static void Main(string[] args)
        {
            int times = int.Parse(Console.ReadLine());
            int counter = 1;
            double balance = 0;
            double increase = 0;

            while (counter <= times)
            {
                increase = double.Parse(Console.ReadLine());
               
                if (increase < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {increase:f2}");
                balance += increase;
                counter++;
            }

            Console.WriteLine($"Total: {balance:f2}");
        }
    }
}
