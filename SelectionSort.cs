using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class SelectionSort : SortingStrategy
    {
        public override void PerformSort<T>(T[] _array, Comparer<T> _comp)
        {
            base.PerformSort(_array, _comp);
        }
        public override void PerformSortStepwise<T>(T[] _array, Comparer<T> _comp)
        {
            base.PerformSortStepwise(_array, _comp);
        }
    }
}
