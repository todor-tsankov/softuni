using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods_MoreExercises
{
    class DataTypes
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            string input = Console.ReadLine();
            string result = string.Empty;

            switch (dataType)
            {
                case "int":
                    typeIntRealString(int.Parse(input));
                    break;
                case "real":
                    typeIntRealString(double.Parse(input));
                    break;
                case "string":
                    typeIntRealString(input);
                    break;
            }
        }

        static void typeIntRealString(int number)
        {
            number *= 2;
            Console.WriteLine(number);
        }

        static void typeIntRealString(double number)
        {
            number *= 1.5;
            Console.WriteLine(number.ToString("f2"));
        }

        static void typeIntRealString(string text)
        {
            Console.WriteLine($"${text}$");
        }
    }
}
