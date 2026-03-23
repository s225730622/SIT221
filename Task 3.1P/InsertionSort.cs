// ----- Insertion Sort -----
// The insertion sort removes the need for traversing the entire list by conceptually dividing the list into two: sorted and unsorted. 

namespace SIT221_Library
{
    class InsertionSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
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
