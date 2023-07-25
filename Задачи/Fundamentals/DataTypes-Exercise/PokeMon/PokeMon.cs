using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeMon
{
    class PokeMon
    {
        static void Main(string[] args)
        {
            double N = double.Parse(Console.ReadLine());
            double M = double.Parse(Console.ReadLine());
            double Y = double.Parse(Console.ReadLine());
            double counter = 0;
            double origN = N;

            while (N >= M)
            {
                N -= M;
                counter++;

                if (N == origN * 0.500 && Y != 0)
                {
                    N = (int)N/ (int)Y;
                }

            }

            Console.WriteLine(N);
            Console.WriteLine(counter);
        }
    }
}
