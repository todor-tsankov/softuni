using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaminoFactory2
{
    class KaminoFactory2
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string input = null;
            int bestCount = 0;
            int bestSum = 0;
            int bestBeginIndex = size;
            string bestSequence = "";
            int counter = 0;
            int bestCounter = 0;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                string sequence = input.Replace("!", "");
                string[] dnaParts = sequence.Split('0');
                int count = 0;
                int sum = 0;
                string bestSubSequence = "";
                counter++;
                

                foreach (string dnaPart in dnaParts)
                {
                    if (dnaPart.Length > count )
                    {
                        count = dnaPart.Length;
                        bestSubSequence = sequence;
                    }
                    sum += dnaPart.Length;
                }

                int beginIndex = sequence.IndexOf(bestSubSequence);

                if ((count > bestCount) 
                    || (count == bestCount && beginIndex < bestBeginIndex) 
                    || (count == bestCount && beginIndex == bestBeginIndex) 
                    || (sum > bestSum || counter == 1))
                {
                    bestCount = count;
                    bestSubSequence = sequence;
                    bestBeginIndex = beginIndex;
                    bestSum = sum;
                    bestCounter = counter;
                }
            }
            char[] arrayResult = bestSequence.ToCharArray();
            Console.WriteLine($"Best DNA sample {bestCounter} with sum: {bestSum}.");

            for (int i = 0; i < arrayResult.Length; i++)
            {
                Console.WriteLine(arrayResult[i]);
            }
        }
    }
}
