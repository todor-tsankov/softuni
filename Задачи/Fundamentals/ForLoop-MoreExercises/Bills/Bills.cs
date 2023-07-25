using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bills
{
    class Bills
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());
            double total = 0;
            double electricityTotal = 0;
            double water = 20;
            double internet = 15;
            double other = 0;

            for (int i = 0; i < months; i++)
            {
                double electricity = double.Parse(Console.ReadLine());
                electricityTotal += electricity;
            }

            water *= months;
            internet *= months;
            other = (electricityTotal + water + internet) * 1.2;
            total += electricityTotal + water + internet + other;
            double average = total / months;

            Console.WriteLine($"Electricity: {electricityTotal:f2} lv");
            Console.WriteLine($"Water: {water:f2} lv");
            Console.WriteLine($"Internet: {internet:f2} lv");
            Console.WriteLine($"Other: {other:f2} lv");
            Console.WriteLine($"Average: {average:f2} lv");

        }
    }
}
