using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graduation
{
    class Graduation
    {
        static void Main(string[] args)
        {
            string studentName = Console.ReadLine();
            double sum = 0;
            double grade = 0;
            int x = 1;

            while (x <= 12)
            {
                grade = double.Parse(Console.ReadLine());
               
                if (grade < 4)
                {
                    continue;
                }
                sum += grade;
                x++;

            }

            sum = sum / 12;
            Console.WriteLine($"{studentName} graduated. Average grade: {sum:f2}");
            

        }
    }
}
