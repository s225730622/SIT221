using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIT221_Library
{
    public interface ISorter
    {
        void Sort<K>(K[] array, int index, int num, IComparer<K> comparer) where K : IComparable<K>;
    }
}
