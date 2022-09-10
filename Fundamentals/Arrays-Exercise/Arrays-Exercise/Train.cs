using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] wagoonPeople = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                wagoonPeople[i] = int.Parse(Console.ReadLine());
                Console.Write(wagoonPeople[i] + " ");
                sum += wagoonPeople[i];
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
