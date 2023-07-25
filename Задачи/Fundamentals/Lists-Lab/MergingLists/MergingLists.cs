using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergingLists
{
    class MergingLists
    {
        static void Main(string[] args)
        {
            List<string> firstList = Console.ReadLine().Split().ToList();
            List<string> secondList = Console.ReadLine().Split().ToList();
            List<string> mergeList = new List<string>();
            int firstCount = firstList.Count;
            int secondCount = secondList.Count;

            for (int i = 0; i < Math.Max(firstCount, secondCount); i++)
            {
                if (i < firstCount)
                {
                    mergeList.Add(firstList[i]);
                }

                if (i < secondCount)
                {
                    mergeList.Add(secondList[i]);
                }
            }

            foreach (var item in mergeList)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }
    }
}
