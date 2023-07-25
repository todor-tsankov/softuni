using SortingAlgorithms.Models.Contracts;

namespace SortingAlgorithms.Models
{
    public class QuickSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            var left = 0;
            var right = arr.Length - 1;

            this.QuickSort(arr, left, right);
        }

        private void QuickSort(int[] arr, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int pivot = Partition(arr, left, right);

            this.QuickSort(arr, left, pivot - 1);
            this.QuickSort(arr, pivot + 1, right);
        }

        private int Partition(int[] arr, int left, int right)
        {
            var pivot = arr[right];
            var leftIndex = left - 1;

            for (int i = left; i < right; i++)
            {
                if (arr[i] <= pivot)
                {
                    leftIndex++;

                    if (i != leftIndex)
                    {
                        var temp = arr[leftIndex];

                        arr[leftIndex] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            leftIndex++;

            int temp1 = arr[leftIndex];

            arr[leftIndex] = arr[right];
            arr[right] = temp1;

            return leftIndex;
        }
    }
}
