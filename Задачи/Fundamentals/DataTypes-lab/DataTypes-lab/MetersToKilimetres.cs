using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes_lab
{
    class MetersToKilimetres
    {
        static void Main(string[] args)
        {
            int meters = int.Parse(Console.ReadLine());
            double kilometres = meters / 1000D;

            Console.WriteLine(kilometres.ToString("F2"));
        }
    }
}
