using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownInfo
{
    class TownInfo
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string population = Console.ReadLine();
            string area = Console.ReadLine();

            Console.WriteLine($"Town {name} has population of {population} and area {area} square km.");
        }
    }
}
