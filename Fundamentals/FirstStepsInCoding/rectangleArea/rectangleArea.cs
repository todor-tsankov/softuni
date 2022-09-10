using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rectangleArea
{
    class rectangleArea
    {
        static void Main(string[] args)
        {
            double h;
            double w;
            
            h = Double.Parse(Console.ReadLine());
            w = Double.Parse(Console.ReadLine());
            Console.WriteLine(h*w);
        }
    }
}
