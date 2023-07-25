using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatingEquality
{
    class FloatingEquality
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine()) * 1000000;
            double secondNumber = double.Parse(Console.ReadLine()) * 1000000;

            bool equal = (int)firstNumber == (int)secondNumber;
            Console.WriteLine(equal);

        }
    }
}
