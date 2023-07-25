using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaminoFactory20
{
    class Program
    {
        static void Main(string[] args)
        {
            int dnaLength = int.Parse(Console.ReadLine());

            int bestSequenceSum = -1;
            int bestSequenceIndex = dnaLength;
            int longestSequence = 0;
            int numberOfSequences = 0;
            int numberOfBestSequence = 0;
            string[] bestDNAsequence = new string[dnaLength];


            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    break;
                }

                numberOfSequences++;

                int currentSequenceSum = 0;
                int currentSequenceIndex = dnaLength;
                int currentSequence = 0;

                string[] currentDNA = input.Split('!');

                for (int i = 0 ; i < dnaLength ; i++)
                {
                    if (currentDNA[i] == "1")
                    {
                        currentSequence++;
                        currentSequenceSum++;
                        currentSequenceIndex = i;
                    }
                    else
                    {
                        currentSequence = 0;
                    }

                    if (currentSequence > longestSequence)
                    {
                        longestSequence = currentSequence;
                        bestSequenceSum = currentSequenceSum;
                        bestSequenceIndex = currentSequenceIndex;
                        bestDNAsequence = currentDNA;
                        numberOfBestSequence = numberOfSequences;
                    }
                    else if (currentSequence == longestSequence && currentSequenceIndex < bestSequenceIndex)
                    {
                        bestSequenceSum = currentSequenceSum;
                        bestSequenceIndex = currentSequenceIndex;
                        bestDNAsequence = currentDNA;
                        numberOfBestSequence = numberOfSequences;
                    }
                    else if (currentSequence == longestSequence && currentSequenceIndex == bestSequenceIndex && currentSequenceSum > bestSequenceSum)
                    {
                        bestSequenceSum = currentSequenceSum;
                        bestDNAsequence = currentDNA;
                        numberOfBestSequence = numberOfSequences;
                    }
                }
            }

            Console.WriteLine($"Best DNA sample {numberOfBestSequence} with sum: {bestSequenceSum}.");

            for (int i = 0; i < dnaLength; i++)
            {
                Console.Write(bestDNAsequence[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
