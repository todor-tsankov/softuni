using SortingAlgorithms.Models.Contracts;

namespace SortingAlgorithms.Models
{
    public class MergeSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            var startIndex = 0;
            var endIndex = arr.Length - 1;

            var result = this.MergeSort(arr, startIndex, endIndex);

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = result[i];
            }
        }

        private int[] MergeSort(int[] arr, int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return new int[] { arr[startIndex]};
            }

            var middle = (startIndex + endIndex) / 2 + 1;

            var firstHalf = this.MergeSort(arr, startIndex, middle - 1);
            var secondHalf = this.MergeSort(arr, middle, endIndex);

            return this.DoMerge(firstHalf, secondHalf);
        }

        private int[] DoMerge(int[] firstHalf, int[] secondHalf)
        {
            var firstLength = firstHalf.Length;
            var secondLength = secondHalf.Length;

            var firstCounter = 0;
            var secondCounter = 0;

            var wholeLength = firstLength + secondLength;
            var mergedArr = new int[wholeLength];

            for (int i = 0; i < wholeLength; i++)
            {
                var firstArrElement = int.MaxValue;
                var secondArrElement = int.MaxValue;

                if (firstCounter < firstLength)
                {
                    firstArrElement = firstHalf[firstCounter];
                }

                if (secondCounter < secondLength)
                {
                    secondArrElement = secondHalf[secondCounter];
                }

                if (firstArrElement <= secondArrElement)
                {
                    mergedArr[i] = firstArrElement;

                    firstCounter++;
                }
                else
                {
                    mergedArr[i] = secondArrElement;

                    secondCounter++;
                }
            }

            return mergedArr;
        }
    }
}
