// ----- Bubble Sort -----
// Repetitively compares two adjacent elements in the list and exchanging them if they are out of order.

namespace SIT221_Library
{
    class BubbleSort : ISorter
    {
        // Implement the Sort method from ISorter
        public void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>
        {
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


