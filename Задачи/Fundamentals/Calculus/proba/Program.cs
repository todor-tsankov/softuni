using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
           string number = Console.ReadLine();
            int x1 = int.Parse( number[2] + "");
            int x2 = int.Parse(number[1] + "");
            int x3 = int.Parse(number[0] + "");


            for (int i = 1; i <= x1; i++)
            {
                for (int j = 1; j <= x2; j++)
                {
                    for (int k = 1; k <= x3; k++)
                    {
                        Console.WriteLine($"{i} * {j} * {k} = {i * j * k};");
                    }
                }
            }
        }
    }
}
