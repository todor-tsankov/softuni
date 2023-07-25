using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace birthdayAquarium
{
    class birthdayAquarium
    {
        static void Main(string[] args)
        {
            int x = Int32.Parse(Console.ReadLine());
            int y = Int32.Parse(Console.ReadLine());
            int z = Int32.Parse(Console.ReadLine());
            Double percent = Double.Parse(Console.ReadLine());
            percent = percent * 0.01;
            Double litres = x * y * z * 0.001;
            Double realLitres = litres * (1 - percent);
            Console.WriteLine(realLitres.ToString("0.000"));

        }
    }
}
