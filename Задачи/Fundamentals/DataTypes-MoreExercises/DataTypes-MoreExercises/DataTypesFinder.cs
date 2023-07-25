using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace DataTypes_MoreExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string data = string.Empty;

            while (data != "END")
            {
                string result = string.Empty;

                if (BigInteger.TryParse(data, out BigInteger result2))    // Correct
                {
                    result = $"{data} is integer type";
                }
                else if (float.TryParse(data, out float result1))
                {
                    result = $"{data} is floating point type";
                }
                else if (char.TryParse(data, out char result3))
                {
                    result = $"{data} is character type";
                }
                else if (bool.TryParse(data, out bool reslut4))      
                {                                               
                    result = $"{data} is boolean type";           
                }
                else if (data != string.Empty)
                {
                    result = $"{data} is string type";
                }

                if (result != string.Empty)
                {
                    Console.WriteLine(result);
                }

                data = Console.ReadLine();
            }
        }
    }
}
