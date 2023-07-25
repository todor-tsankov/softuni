using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Largest3Numbers
{
    class Largest3Numbers
    {
        static void Main(string[] args)
        {
            List<int> numbersList = Console.ReadLine().Split().Select(int.Parse).ToList();
            numbersList = numbersList.OrderByDescending(i => i).ToList();
            int count = numbersList.Count;

            if (count > 3)
            {
                count = 3;
            }

            var largestThree = numbersList.Take(count);
            Console.WriteLine(string.Join(" ", largestThree));
        }
    }
}
