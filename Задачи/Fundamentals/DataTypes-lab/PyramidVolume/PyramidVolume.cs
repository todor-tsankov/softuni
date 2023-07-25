using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PyramidVolume
{
    class PyramidVolume
    {
        static void Main(string[] args)
        {
            double Length = 0;
            double Width = 0;
            double Height = 0;
            double Volume = 0;

            Console.Write("Length: ");
            Length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            Width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            Height = double.Parse(Console.ReadLine());
            Volume = (Length * Width * Height) / 3D;
            Console.WriteLine($"Pyramid Volume: {Volume:f2}");

        }
    }
}
