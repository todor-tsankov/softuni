using SortingAlgorithms.Models.Contracts;

namespace SortingAlgorithms.Models
{
    public class MergeSorter2 : ISorter
    {
        public void Sort(int[] arr)
        {
            var startIndex = 0;
            var endIndex = arr.Length - 1;

            this.MergeSort(arr, startIndex, endIndex);
        }

        private void MergeSort(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            var middle = (startIndex + endIndex) / 2 + 1;

            this.MergeSort(arr, startIndex, middle - 1);
            this.MergeSort(arr, middle, endIndex);

            this.DoMerge(arr, startIndex, endIndex, middle);
        }

        private void DoMerge(int[] arr, int startIndex, int endIndex, int middle)
        {
            var length = endIndex - startIndex + 1;
            var tempArr = new int[length];

            var tempStart = startIndex;
            var tempEnd = endIndex;

            for (int i = 0; i < length; i++)
            {
                var firstHalfItem = int.MaxValue;
                var secondHalfItem = int.MaxValue;

                if (tempStart < middle)
                {
                    firstHalfItem = arr[tempStart];
                }

                if (middle <= tempEnd)
                {
                    secondHalfItem = arr[middle];
                }

                var toBeSaved = secondHalfItem;

                if (firstHalfItem <= secondHalfItem)
                {
                    toBeSaved = firstHalfItem;

                    tempStart++;
                }
                else
                {
                    middle++;
                }

                tempArr[i] = toBeSaved;
            }

            var counter = 0;

            for (int i = startIndex; i <= endIndex; i++)
            {
                arr[i] = tempArr[counter++];
            }
        }
    }
}
