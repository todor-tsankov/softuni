using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatString
{
    class RepeatString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string result = RepeatstringTimes(input, n);
            Console.WriteLine(result);
        }

        static string RepeatstringTimes(string input, int times)
        {
            string result = string.Empty;

            for (int i = 0; i < times; i++)
            {
                result += input;
            }
            return result;
        }
    }
}
