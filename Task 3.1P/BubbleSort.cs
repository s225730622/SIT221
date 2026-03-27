// ----- Bubble Sort -----
// Repetitively compares two adjacent elements in the list and exchanging them if they are out of order.

namespace SIT221_Library
{
    class BubbleSort : ISorter
    {
        // Implement the Sort method from ISorter
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
            
            for (int i = 0; i < num - 1; i++)
            {
                for (int j = index; j < index + num - 1 - i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                    {
                        // Swaps adjacent elements if required
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        // Swap helper method
        private void Swap<K>(K[] array, int first, int second)
        {
            (array[first], array[second]) = (array[second], array[first]);
        }
    }
}
