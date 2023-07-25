using SortingAlgorithms.Models.Contracts;

namespace SortingAlgorithms.Models
{
    public class BubbleSorter : ISorter
    {
        public void Sort(int[] arr)
        {
            var sorted = true;
            var lastIndex = arr.Length - 1;

            while (sorted)
            {
                sorted = false;

                for (int i = 0; i < lastIndex; i++)
                {
                    var current = arr[i];
                    var next = arr[i + 1];

                    if (current > next)
                    {
                        arr[i] = next;
                        arr[i + 1] = current;

                        sorted = true;
                    }
                }

                lastIndex--;
            }
        }
    }
}
