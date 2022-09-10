using ParallelMergeSort.Core.Contracts;
using System.Threading;

namespace ParallelMergeSort.Core
{
    public class ThreadMergeSorter : ISorter
    {
        private const int MaxThreads = 4;

        private int threadsCount = 0;
        private object threadLock = new object();

        public void Sort(int[] array)
        {
            if (array.Length <= 1)
            {
                return;
            }

            var startIndex = 0;
            var endIndex = array.Length - 1;

            this.MergeSort(array, startIndex, endIndex);
        }

        private void MergeSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var middle = (start + end) / 2;

            if (this.threadsCount <= MaxThreads)
            {
                var firstThread = new Thread(() => this.MergeSort(array, start, middle));
                var secondThread = new Thread(() => this.MergeSort(array, middle + 1, end));

                firstThread.Start();
                secondThread.Start();

                lock (threadLock)
                {
                    this.threadsCount += 2;
                }

                firstThread.Join();
                secondThread.Join();
            }
            else
            {
                this.MergeSort(array, start, middle);
                this.MergeSort(array, middle + 1, end);
            }

            var length = end - start + 1;
            var sorted = new int[length];

            var leftIndex = start;
            var rightIndex = middle + 1;

            for (int i = 0; i < length; i++)
            {
                var firstValue = int.MaxValue;
                var secondValue = int.MaxValue;

                if (leftIndex <= middle)
                {
                    firstValue = array[leftIndex];
                }

                if (rightIndex <= end)
                {
                    secondValue = array[rightIndex];
                }

                if (firstValue < secondValue)
                {
                    sorted[i] = firstValue;
                    leftIndex++;
                }
                else
                {
                    sorted[i] = secondValue;
                    rightIndex++;
                }
            }

            var counter = 0;

            for (int i = start; i <= end; i++)
            {
                array[i] = sorted[counter++];
            }
        }
    }
}
