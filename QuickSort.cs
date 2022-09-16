using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    //TODO: print total count only on last iteration not for every recursive call
    class QuickSort : SortingStrategy
    {
        private int partitionIndex;
        private static int count = 0;
        private bool isFirst = true;
        public int Partition<T>(T[] _array, Comparer<T> _comp, int _low, int _high)
        {
            T temp = default(T);
            T pivot = _array[_high];
            int i = _low - 1; 

            for (int j = _low; j < _high; j++)
            {
                if(_comp.Compare(_array[j], pivot) < 0)
                {
                    i++;
                    temp = _array[i];
                    _array[i] = _array[j];
                    _array[j] = temp;
                }
                count++;
            }
            temp = _array[i + 1];
            _array[i + 1] = _array[_high];
            _array[_high] = temp;
            Console.WriteLine("QuickSort total steps: " + count);
            return (i + 1);
        }

        public override void PerformSort<T>(T[] _array, int _low, int _high)
        {
            Comparer<T> tempComp = Comparer<T>.Default;
            if(_low < _high)
            {
                partitionIndex = Partition<T>(_array, tempComp, _low, _high);
                PerformSort<T>(_array, _low, partitionIndex - 1); //before partition
                PerformSort<T>(_array, partitionIndex + 1, _high);   //after partition

            }
        }

        public int PartitionStepwise<T>(T[] _array, Comparer<T> _comp, int _low, int _high)
        {
            T temp = default(T);
            T pivot = _array[_high];
            int i = _low - 1;
            Console.WriteLine("pivot: " + pivot);
            Console.WriteLine("indexer: " + i + "\n");
            Thread.Sleep(1200);
            for (int j = _low; j < _high; j++)
            {
                Console.WriteLine("--------------------------ITERATION " + (count+1) + "--------------------------");
                if (_comp.Compare(_array[j], pivot) < 0)
                {
                    Thread.Sleep(200);
                    Console.WriteLine("Performing switch...\n");
                    i++;
                    temp = _array[i];
                    Thread.Sleep(100);
                    Console.Write("ptr: --");
                    for (int k = 0; k < _array.Length; k++)
                    {
                        
                        if (k == j)
                        {
                            Console.Write(" | ");
                        }
                        else
                            Console.Write("---");
                    }
                    Thread.Sleep(100);
                    Console.WriteLine();
                    base.PrintArray<T>(_array);
                    _array[i] = _array[j];
                    _array[j] = temp;
                }
                else
                {
                    Thread.Sleep(200);
                    Console.WriteLine("Elements already in correct order...");
                }
                count++;
                Thread.Sleep(1200);
            }
            temp = _array[i + 1];
            _array[i + 1] = _array[_high];
            _array[_high] = temp;
            return (i + 1);
        }

        public override void PerformSortStepwise<T>(T[] _array, int _low, int _high)
        {
            if (isFirst)
            {
                Console.WriteLine("\nPerforming QuickSort stepwise...\n");
                isFirst = false;
            }
            Comparer<T> tempComp = Comparer<T>.Default;
            if (_low < _high)
            {
                partitionIndex = PartitionStepwise<T>(_array, tempComp, _low, _high);

                PerformSortStepwise<T>(_array, _low, partitionIndex - 1);   //before partition
                PerformSortStepwise<T>(_array, partitionIndex + 1, _high);   //after partition
            }
            //check if last step here
            Thread.Sleep(100);
            Console.WriteLine("QuickSort total steps: " + count);
            Console.WriteLine();
        }



    }
}
