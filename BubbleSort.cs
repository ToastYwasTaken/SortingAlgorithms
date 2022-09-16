using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    /// <summary>
    /// BubbleSort sorts the Array by iterating through the elements and switches them when the next one is bigger than the one before
    /// </summary>
    class BubbleSort : SortingStrategy
    {
        int count = 0;
        public BubbleSort() { }

        public override void PerformSort<T>(T[] _array, Comparer<T> _comp)

        {
            Console.WriteLine("Performing BubbleSort...");
            T temp;
            for (int i = 1; i < _array.Length; i++)
            {
                for (int j = 0; j < _array.Length-1; j++)
                {
                    if (_comp.Compare(_array[j], _array[j + 1]) > 0)
                        //turns <0 when x < y
                        //turns 0 when x = y
                        //turns >0 when x > y
                    {
                        temp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = temp;
                    }
                }
            }
        }

        public override void PerformSortStepwise<T>(T[] _array, Comparer<T> _comp)
        {
            Console.WriteLine("\nPerforming BubbleSort stepwise...");
            T temp = default;
            for (int i = 1; i < _array.Length; i++)
            {
                for (int j = 0; j < _array.Length - 1; j++)
                {
                    Console.WriteLine("--------------------------ITERATION " + (count+1) + "--------------------------");
                    if (_comp.Compare(_array[j], _array[j + 1]) > 0)
                    //turns <0 when x < y
                    //turns 0 when x = y
                    //turns >0 when x > y
                    {
                        Console.WriteLine("Elements are NOT ordered correctly. Reordering...\n");
                        temp = _array[j];
                        Console.Write("ptr: --");
                        for (int k = 0; k < _array.Length; k++)
                        {
                            if (k == j)
                            {
                                Console.Write(" | ");
                            }else
                            Console.Write("---");
                        }
                        Console.WriteLine();
                        base.PrintArray(_array);
                        _array[j] = _array[j + 1];
                        base.PrintArray(_array);
                        _array[j + 1] = temp;
                        base.PrintArray(_array);
                        Console.WriteLine($"Exchanged values {_array[j]} and {_array[j+1]} at index and index+1\n");
                    }
                    else
                    {
                        Console.WriteLine("Order of elements is already correct.");
                    }
                    count++;
                }
            }
            Console.WriteLine("BubbleSort total steps: " +  count);
        }

    }
}
