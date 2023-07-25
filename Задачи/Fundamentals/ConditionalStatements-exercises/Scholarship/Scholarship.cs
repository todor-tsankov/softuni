using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship
{
    class Scholarship
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double netGrade = double.Parse(Console.ReadLine());
            double minIncome = double.Parse(Console.ReadLine());

            bool firstTypeCheck = income < minIncome && netGrade > 4.5;
            bool secondTypeCheck = netGrade >= 5.5;
            double firstType = 0;
            double secondType = 0;
            if (firstTypeCheck)
            {
               firstType =Math.Floor( 0.35 * minIncome);
            }

            if (secondTypeCheck)
            {
                secondType = Math.Floor(netGrade * 25);
            }
           
            if (!firstTypeCheck && !secondTypeCheck)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (firstType > secondType)
            {
                Console.WriteLine($"You get a Social scholarship {firstType} BGN");
            }
            else if (secondType >= firstType)
            {
                Console.WriteLine($"You get a scholarship for excellent results {secondType} BGN");
            }
            
            

        }
    }
}
