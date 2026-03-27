// ----- Selection Sort -----
// Traverses through the list of unsorted elements to identify the smallest value and then exchanging that element with the first element in the list, moving it straight to its final location (assuming an ascending sort).

namespace SIT221_Library
{
    class SelectionSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            // Throw exception error if array is null
            if (array == null) 
                throw new ArgumentNullException(nameof(array));

            // Throw error if index or num or both are negative
            if (index < 0 || num < 0) 
                throw new ArgumentOutOfRangeException();

            // Throw error if index & num values do not specify a valid range within array
            if (index + num > array.Length) 
                throw new ArgumentException();

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





