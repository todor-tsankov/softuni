using ParallelMergeSort.Core.Contracts;

namespace ParallelMergeSort.Core
{
    public class MergeSorter : ISorter
    {
        public void Sort(int[] array)
        {
            if (array.Length <= 1)
            {
                return;
            }

            var startIndex = 0;
            var endIndex = array.Length - 1;

            var sortedArr = this.MergeSort(array, startIndex, endIndex);

            for (int i = startIndex; i <= endIndex; i++)
            {
                array[i] = sortedArr[i];
            }
        }

        private int[] MergeSort(int[] array, int start, int end)
        {
            if (start >= end)
            {
                return new int[] { array[start]};
            }

            var middle = (start + end) / 2;

            var left = this.MergeSort(array, start, middle);
            var right = this.MergeSort(array, middle + 1, end);

            var length = left.Length + right.Length;
            var sorted = new int[length];

            var leftIndex = 0;
            var rightIndex = 0;

            for (int i = 0; i < length; i++)
            {
                var firstValue = int.MaxValue;
                var secondValue = int.MaxValue;

                if (leftIndex < left.Length)
                {
                    firstValue = left[leftIndex];
                }

                if (rightIndex < right.Length)
                {
                    secondValue = right[rightIndex];
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

            return sorted;
        }
    }
}
