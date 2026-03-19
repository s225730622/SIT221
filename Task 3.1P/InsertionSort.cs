// Insertion Sort - The insertion sort removes the need for traversing the entire list by conceptually dividing the list into two: sorted and unsorted. The first element in the unsorted list is then removed to a temporary location, then the elements in the sorted list are shuffled to make a soace available where the unsorted element should be placed. Finally, the previously removed unsorted element is placed in the sorted list. 

namespace SIT221_Library
{
    class InsertionSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            int firstUnsorted = 1;

            while (firstUnsorted < num)
            {
                K temp = array[firstUnsorted];
                index = firstUnsorted - 1;
                while (index >= 0 && (comparer.Compare(array[index], temp) > 0))
                {
                    array[index + 1] = array[index];
                    index--;
                }
                array[index + 1] = temp;
                firstUnsorted++;
            }
        }
    }
}
