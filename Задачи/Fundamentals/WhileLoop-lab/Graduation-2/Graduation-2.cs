using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            double average = 0;
            int x = 1;
            int y = 1;
            double grade = 0;
            bool check = true;

            while (x <= 12)
            {
                if (y >= 3)
                {
                    Console.WriteLine($"{studentName} has been excluded at {x} grade");
                    check = false;
                        break;
                }
                grade = double.Parse(Console.ReadLine());
                
                if (grade < 4.00)
                {
                    y++;
                    continue;
                }
                average += grade;
                x++;
            }

            average /= 12;

            if (check)
            {
                Console.WriteLine($"{studentName} graduated. Average grade: {average:f2}");
            }
         
        }
    }
}
