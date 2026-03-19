// Bubble Sort - Repetitively compares two adjacent elements in the list and exchanging them if they are out of order.

namespace SIT221_Library
{
    class BubbleSort : ISorter
    {
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
            int firstSorted = -1; // Need to change this to 'index'
            
            while (firstSorted < num - 1)
            {
                index = num - 2;
                while (index > firstSorted)
                {
                    if (comparer.Compare(array[index], array[index + 1]) > 0)
                    {
                        K temp = array[index + 1];
                        array[index + 1] = array[index];
                        array[index] = temp;
                    }
                    index--;
                }
                firstSorted++;
            }
        }
    }
}


