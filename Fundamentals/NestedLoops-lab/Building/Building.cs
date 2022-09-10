using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Building
{
    class Building
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int roomsPerFloor = int.Parse(Console.ReadLine());

            for (int n = floors; n > 0;n--)
            {
                for (int i = 0; i < roomsPerFloor; i++)
                {
                    if (n == floors)
                    {
                        Console.Write($"L{n}{i} ");
                    }
                    else if (n % 2 == 0)
                    {
                        Console.Write($"O{n}{i} ");
                    }
                    else 
                    {
                        Console.Write($"A{n}{i} ");
                    }
                }
                Console.Write("\n");
            }
           
        }
    }
}
