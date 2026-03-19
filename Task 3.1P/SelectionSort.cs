// Selection Sort - Traverses through the list of unsorted elements to identify the smallest value and then exchanging that element with the first element in the list, moving it straight to its final location (assuming an ascending sort).

namespace SIT221_Library
{
    class SelectionSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            int firstUnsorted = 0;

            while (firstUnsorted < num - 1)
            {
                int smallest = firstUnsorted;
                index = smallest + 1;
                while (index < num)
                {
                    if (comparer.Compare(array[index], array[smallest]) < 0)
                    {
                        smallest = index;
                    }
                    index++;
                }
                K temp = array[smallest];
                array[smallest] = array[firstUnsorted];
                array[firstUnsorted] = temp;
                firstUnsorted++;
            }
        }
    }
}


