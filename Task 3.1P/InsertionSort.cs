// ----- Insertion Sort -----
// The insertion sort removes the need for traversing the entire list by conceptually dividing the list into two: sorted and unsorted. 

namespace SIT221_Library
{
    class InsertionSort : ISorter
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

            for (int i = index + 1; i < index + num; i++)
            {
                K temp = array[i];
                int j = i - 1;
                {
                    while (j >= index && (comparer.Compare(array[j], temp) > 0))
                    {
                        array[j + 1] = array[j];
                        j--;
                    }
                }
                array[j + 1] = temp;
            }
        }
    }
}
