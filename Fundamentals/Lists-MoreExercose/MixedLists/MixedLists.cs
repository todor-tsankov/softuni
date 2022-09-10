using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixedLists
{
    class MixedLists
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondList = Console.ReadLine().Split().Select(int.Parse).ToList();
            int firstCount = firstList.Count;
            int secondCount = secondList.Count;
            int startIndex = 0;
            int endIndex = 0;

            if (firstList.Count > secondList.Count)
            {
                startIndex = Math.Min(firstList[firstCount - 1], firstList[firstCount - 2]);
                endIndex = Math.Max(firstList[firstCount - 1], firstList[firstCount - 2]);
            }
            else
            {
                startIndex = Math.Min(secondList[0], secondList[1]);
                endIndex = Math.Max(secondList[0], secondList[1]);
            }

            List<int> result = new List<int>();

            foreach (var item in firstList.Concat(secondList).ToList())
            {
                if (item > startIndex && item < endIndex)
                {
                    result.Add(item);
                }
            }

            result.Sort();

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
