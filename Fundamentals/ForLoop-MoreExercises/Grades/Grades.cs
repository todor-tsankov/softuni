using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Grades
    {
        static void Main(string[] args)
        {
            double n = int.Parse(Console.ReadLine());
            double sum = 0;
            double top = 0;
            double four = 0;
            double three = 0;
            double fail = 0;

            for (int i = 0; i < n; i++)
            {
                double currentGrade = double.Parse(Console.ReadLine());
                sum += currentGrade;

                if (currentGrade >= 5.00)
                {
                    top++;
                }
                else if (currentGrade >= 4.00)
                {
                    four++;
                }
                else if (currentGrade >= 3.00)
                {
                    three++;
                }
                else
                {
                    fail++;
                }
            }

            sum /= n;
            top *= 100 / n;
            four *= 100 / n;
            three *= 100 / n;
            fail *= 100 / n;

            Console.WriteLine($"Top students: {top:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {four:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {three:f2}%");
            Console.WriteLine($"Fail: {fail:f2}%");
            Console.WriteLine($"Average: {sum:f2}");
        }
    }
}
