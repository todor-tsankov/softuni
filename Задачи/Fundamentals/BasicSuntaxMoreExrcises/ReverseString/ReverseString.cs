using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    class ReverseString
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = "";

            for (int i = input.Length -1; i >= 0; i--)
            {
                output += input[i];
            }

            Console.WriteLine(output);
        }
    }
}
