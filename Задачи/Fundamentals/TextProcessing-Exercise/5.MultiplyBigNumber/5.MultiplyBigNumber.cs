using System;
using System.Text;
using System.Linq;
using System.Numerics;

namespace _5.MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger firstNumber = BigInteger.Parse(Console.ReadLine());
            int smallNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(firstNumber * smallNumber);
        }
    }
}
