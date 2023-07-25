using System.Linq;
using System.Collections.Generic;

using SortingAlgorithms.Models.Contracts;

namespace SortingAlgorithms.Models
{
    public class RadixSorter : ISorter
    {
        private const int MinDigit = 0;
        private const int MaxDigit = 9;

        private const int QueuesCount = MaxDigit - MinDigit + 1;

        private int maxLength;

        public void Sort(int[] arr)
        {
            var queues = this.CreateQueues();
            var numbersAsString = this.ParseNumbers(arr);

            this.RadixSort(numbersAsString, queues);

            this.ParseStrings(numbersAsString, arr);
        }

        private Queue<string>[] CreateQueues()
        {
            var queues = new Queue<string>[QueuesCount];

            for (int currentDigit = MinDigit; currentDigit <= MaxDigit; currentDigit++)
            {
                queues[currentDigit] = new Queue<string>();
            }

            return queues;
        }

        private string[] ParseNumbers(int[] arr)
        {
            this.maxLength = arr.Max(n => n.ToString().Length);

            var length = arr.Length;
            var numbersAsString = new string[length];

            for (int i = 0; i < length; i++)
            {
                numbersAsString[i] = arr[i].ToString($"D{this.maxLength}");
            }

            return numbersAsString;
        }

        private void RadixSort(string[] arr, Queue<string>[] queues)
        {
            for (int i = this.maxLength - 1; i >= 0; i--)
            {
                this.FillQueues(arr, queues, i);
                this.EmptyQueues(arr, queues);
            }
        }

        private void EmptyQueues(string[] arr, Queue<string>[] queues)
        {
            var arrayIndex = 0;

            for (int i = 0; i < queues.Length; i++)
            {
                var currenQueue = queues[i];

                while (currenQueue.Any())
                {
                    arr[arrayIndex] = currenQueue.Dequeue();

                    arrayIndex++;
                }
            }
        }

        private void FillQueues(string[] arr, Queue<string>[] queues, int i)
        {
            for (int j = 0; j < arr.Length; j++)
            {
                var number = arr[j];
                var digit = number[i] - 48;

                queues[digit].Enqueue(number);
            }
        }

        private void ParseStrings(string[] numbersAsString, int[] arr)
        {
            var length = arr.Length;

            for (int i = 0; i < length; i++)
            {
                arr[i] = int.Parse(numbersAsString[i]);
            }
        }
    }
}
