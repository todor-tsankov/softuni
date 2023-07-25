using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterOfTwoValues
{
    class GreaterOfTwoValues
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string result = string.Empty;
            string firstInput = Console.ReadLine();
            string secondInput = Console.ReadLine();

            if (type == "int")
            {
                result = GetMax(int.Parse(firstInput), int.Parse(secondInput));
            }
            else if (type == "char")
            {
                result = GetMax(firstInput[0], secondInput[0]);
            }
            else
            {
                result = GetMax(firstInput, secondInput);
            }

            Console.WriteLine(result);
        }

        static string GetMax(string firstString, string secondString)
        {
            if (firstString.CompareTo(secondString) > 0)
            {
                return firstString;
            }

            return secondString;
        }

        static string GetMax(char firstChar, char secondChar)
        {
            if (firstChar > secondChar)
            {
                return firstChar.ToString();
            }

            return secondChar.ToString();

        }

        static string GetMax(int firstInt, int secondInt)
        {
            if (firstInt > secondInt)
            {
                return firstInt.ToString();
            }

            return secondInt.ToString();
        }
    }
}
