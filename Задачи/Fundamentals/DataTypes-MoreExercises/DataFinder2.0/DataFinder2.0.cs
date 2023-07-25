using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DataTypes_MoreExercises
{
    class DataTypesFinder
    {
        static void Main(string[] args)
        {
            string data = string.Empty;
            int counter = 0;

            while (data != "END")
            {
                if (BigInteger.TryParse(data, out BigInteger result2))
                {
                    Console.WriteLine($"{data} is integer type");
                }
                else if (decimal.TryParse(data, out decimal result1))
                {
                    Console.WriteLine($"{data} is floating point type");
                }
                else if (data.Length == 1)
                {
                    Console.WriteLine($"{data} is character type");
                }
                else if (data == "true" || data == "false")
                {
                    Console.WriteLine($"{data} is boolean type");
                }
                else if (data != string.Empty)
                {
                    Console.WriteLine($"{data} is string type");
                }
                else if (data == string.Empty && counter != 0)
                {
                    Console.WriteLine($" is a string type");
                }
                counter++;
                data = Console.ReadLine();
            }
        }
    }
}
