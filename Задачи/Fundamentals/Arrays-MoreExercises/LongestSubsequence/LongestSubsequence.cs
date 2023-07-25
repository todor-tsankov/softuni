using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSubsequence
{
    class LongestSubsequence
    {
        static void Main(string[] args)
        {
            int[] list = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int length = list.Length;
            int bestLength = 0;
            int[] longestSequence = new int[length];

            for (int i = 0; i < length; i++)
            {
                int[] currenSequnce = new int[length];
                int lengthCounter = 0;
                int indexCounter = 1;
                int index = list[i];
                currenSequnce[0] = list[i];

                for (int j = i + 1; j < length; j++)
                {

                    if (index < list[j])
                    {
                        currenSequnce[indexCounter] = list[j];
                        index = list[j];
                        indexCounter++;
                        lengthCounter++;
                    }
                }

                if (lengthCounter > bestLength)
                {
                    longestSequence = currenSequnce;
                    bestLength = lengthCounter;
                }
            }

            if (length == 1)
            {
                longestSequence[0] = list[0];
            }

            foreach (var item in longestSequence)
            {
                if (item != 0)
                {
                    Console.Write(item + " ");
                }
            }

            Console.WriteLine();
        }
    }
}
