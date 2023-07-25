using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsBetweenNumbers
{
    class OperationsBetweenNumbers
    {
        static void Main(string[] args)
        {
            int N1 = int.Parse(Console.ReadLine());
            int N2 = int.Parse(Console.ReadLine());
            char OP = char.Parse(Console.ReadLine());
            double result = 0.00;

            switch (OP)
            {
                case '+':
                    result = N1 + N2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{N1} {OP} {N2} = {result} - even");                       
                    }
                    else
                    {
                        Console.WriteLine($"{N1} {OP} {N2} = {result} - odd");
                    }
                    break;
                case '-':
                    result = N1 - N2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{N1} {OP} {N2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} {OP} {N2} = {result} - odd");
                    }
                    break;
                case '*':
                    result = N1 * N2;
                    if (result % 2 == 0)
                    {
                        Console.WriteLine($"{N1} {OP} {N2} = {result} - even");
                    }
                    else
                    {
                        Console.WriteLine($"{N1} {OP} {N2} = {result} - odd");
                    }
                    break;
                case '/':
                    if (N2 != 0)
                    {
                        result = (double)N1 / N2;
                        Console.WriteLine($"{ N1} / { N2} = {result:f2}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                    }
                        break;
                    
                case '%':
                    if (N2 != 0)
                    {
                        result = N1 % N2;
                        Console.WriteLine($"{ N1} % { N2} = {result}");
                    }
                    else
                    {
                        Console.WriteLine($"Cannot divide {N1} by zero");
                    }
                    break;



            }


        }
    }
}
