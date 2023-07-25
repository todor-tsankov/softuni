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
            double grade = double.Parse(Console.ReadLine());
            GradeInWords(grade);
        }

        static void GradeInWords(double grade)
        {
            string result = string.Empty;

            if (grade < 3)
            {
                result = "Fail";
            }
            else if (grade < 3.5)
            {
                result = "Poor";
            }
            else if (grade < 4.5)
            {
                result = "Good";
            }
            else if (grade < 5.5)
            {
                result = "Very good";
            }
            else
            {
                result = "Excellent";
            }

            Console.WriteLine(result);
        }
    }
}
