using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeIntegers
{
    class PalindromeIntegers
    {
        static void Main(string[] args)
        {
            string number = string.Empty;

            while (true)
            {
                number = Console.ReadLine();

                if (number == "END")
                {
                    break;
                }

                IsPalindrome(number);
            }
        }

        static void IsPalindrome(string number)
        {
            char[] charArr = number.ToCharArray();
            Array.Reverse(charArr);

            if (number == new string(charArr))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }

    }
}
