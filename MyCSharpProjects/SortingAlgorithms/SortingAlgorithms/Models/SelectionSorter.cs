using SortingAlgorithms.Models.Contracts;

namespace SortingAlgorithms.Models
{
    public class SelectionSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            var length = arr.Length;

            for (int i = 0; i < length - 1; i++)
            {
                var min = i;

                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    var temp = arr[i];

                    arr[i] = arr[min];
                    arr[min] = temp;
                }
            }
        }
    }
}
