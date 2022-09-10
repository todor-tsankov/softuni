using System;

namespace P02RecursiveFactorial
{
    class Program
    {
        static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var fact = FindFactorial(number);

            Console.WriteLine(fact);
        }

        static long FindFactorial(int number)
        {
            var factorial = 1L;

            if (number == 1)
            {
                return factorial;
            }

            factorial *= number;
            factorial *= FindFactorial(--number);

            return factorial;
        }
    }
}
