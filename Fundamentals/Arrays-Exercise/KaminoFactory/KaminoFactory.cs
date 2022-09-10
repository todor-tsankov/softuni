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

            int bestSequenceSum = int.MinValue;
            int bestSequenceIndex = dnaLength;
            int longestSequence = int.MinValue;
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
                int currentBestSequence = 0;

                string[] currentDNA = input.Split('!',StringSplitOptions.RemoveEmptyEntries);

                for (int i = dnaLength - 1; i >= 0; i--)
                {
                    if (currentDNA[i] == "1" )
                    {
                        currentSequenceSum++;
                        currentSequence++;

                        if (currentSequence >= currentBestSequence)
                        {
                            currentBestSequence = currentSequence;
                            currentSequenceIndex = i;
                        }
                    }
                    else
                    {
                        currentSequence = 0;
                    }
                }

                if ((currentBestSequence > longestSequence) || (currentBestSequence == longestSequence && currentSequenceIndex < bestSequenceIndex) || (currentBestSequence == longestSequence && currentSequenceIndex == bestSequenceIndex && currentSequenceSum > bestSequenceSum))
                {
                    longestSequence = currentBestSequence;
                    bestSequenceSum = currentSequenceSum;
                    bestSequenceIndex = currentSequenceIndex;
                    bestDNAsequence = currentDNA;
                    numberOfBestSequence = numberOfSequences;
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
