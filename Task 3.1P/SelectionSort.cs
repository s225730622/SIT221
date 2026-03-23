// ----- Selection Sort -----
// Traverses through the list of unsorted elements to identify the smallest value and then exchanging that element with the first element in the list, moving it straight to its final location (assuming an ascending sort).

namespace SIT221_Library
{
    class SelectionSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            for (int i = index; i < index + num - 1; i++)
            {
                int smallest = i;

                for (int j = i + 1; j < index + num; j++)
                {
                    if (comparer.Compare(array[j], array[smallest]) < 0)
                    {
                        smallest = j;
                    }
                }
                Swap(array, i, smallest);
            }
        }

        // Swap helper method
        private void Swap<K>(K[] array, int first, int second)
        {
            (array[first], array[second]) = (array[second], array[first]);
        }
    }
}


