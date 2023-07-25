using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    class Salary
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());
            double fee = 0;
            bool salaryZeroCheck = false;

            for (int i = 0; i < n; i++)
            {
                string website = Console.ReadLine();

                switch (website)
                {
                    case "Facebook":
                        fee += 150;
                        break;
                    case "Instagram":
                        fee += 100;
                        break;
                    case "Reddit":
                        fee += 50;
                        break;
                }
                if (fee >= salary)
                {
                    salaryZeroCheck = true;
                    break;
                }
            }

            if (salaryZeroCheck)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary - fee);
            }
        }
    }
}
