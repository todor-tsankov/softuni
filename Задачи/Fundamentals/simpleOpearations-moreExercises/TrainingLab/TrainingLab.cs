using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingLab
{
    class TrainingLab
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());

            double hLeft = h - 1;
            double numRows = Math.Floor(hLeft / 0.7);
            double numColumns = Math.Floor(w / 1.2);
            double numPlaces = numColumns * numRows - 3;

            Console.WriteLine(numPlaces);
        }
    }
}
