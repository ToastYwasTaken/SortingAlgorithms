using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class SortingStrategy
    {
        private static bool showSteps = false;
        private static Dictionary<int, Type> typeChoices = new Dictionary<int, Type>();
        private static int[] range = {1, 2, 3, 4, 5, 6, 7};

        public SortingStrategy()
        {
        }

        public static void Start()
        {
            Console.WriteLine("Welcome to the sorting machine! \n ANY value-types are supported.");
            typeChoices.Add(1, typeof(sbyte));
            typeChoices.Add(2, typeof(byte));
            typeChoices.Add(3, typeof(short));
            typeChoices.Add(4, typeof(ushort));
            typeChoices.Add(5, typeof(int));
            typeChoices.Add(6, typeof(float));
            typeChoices.Add(7, typeof(double));
        Type datatype = typeof(int);    // default Single
        string input;
            do
            {
                Console.WriteLine("Choose the datatype you want to use for your array and the sorting algorithm:\n");
                Console.WriteLine("[1] |datatype: sbyte | Byte | range: [-128] - [127]");
                Console.WriteLine("[2] |datatype: byte | Int16 | range: [0] - [255]");
                Console.WriteLine("[3] |datatype: short | UInt16 range: [-32,768] - [32,767]");
                Console.WriteLine("[4] |datatype: ushort | range: [0] - [65,535]");
                Console.WriteLine("[5] |datatype: int | Single |  range: [-2,147,483,648] - [2,147,483,647]");
                Console.WriteLine("[6] |datatype: float | range: 3.4E +/- 38 (7 digits)");
                Console.WriteLine("[7] |datatype: double | range: 1.7E +/- 308 (15 digits)");
                input = Console.ReadLine();
                if (int.TryParse(input, out int result) == true) {
                    if (!range.Contains(result))
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong input, try again.");
                    }
                    datatype = typeChoices.ElementAt(result).Value;
                }

            } while (int.TryParse(input, out int alternateResult) == false);
            Console.Clear();
            Console.WriteLine("You choose " + typeChoices.ElementAt(int.Parse(input)).Value.Name + " as datatype");
            Console.WriteLine("Input your wanted array / list size [whole number]: ");
            do
            {
                if(int.TryParse(Console.ReadLine(), out int result) == true)
                {
                    var methodInfo = typeof(SortingStrategy).GetMethod(nameof(SortingStrategy.InitializeArray));
                    var genericMethodInfo = methodInfo.MakeGenericMethod(datatype);
                    var genericInvoe = genericMethodInfo.Invoke(null, new object[] { result });
                }
            } while (int.TryParse(Console.ReadLine(), out int alternateResult) == false);
        }

        public static void InitializeArray<T>(int _asize)
        {
            Console.WriteLine("Initializing array..."); //TODO
            T[] array = new T[_asize];
            for (int i = 0; i < _asize; i++)
            {
                T input = (T)Convert.ChangeType(Console.ReadLine(), typeof(T)); //Parsing User input to generic type T
                array[i] = input;
            }
            ChooseVisualization();
            ChooseSortingAlgorithm<T>(array);

        }

        public static void ChooseVisualization()
        {
            Console.WriteLine("Enable visualization of each step the algorithm performs? \n[y]: yes\n[n]: no");
            if (Console.ReadKey().Key.Equals(ConsoleKey.Y))
            {
                showSteps = true;
            }
            else if (Console.ReadKey().Key.Equals(ConsoleKey.N))
            {
                showSteps = false;
            }
            else ChooseVisualization(); //recursive
        }
        public static void ChooseSortingAlgorithm<T>(T[] _arrayToSort)
        {
            Console.WriteLine("What Sort do you want to perform?");
            Console.WriteLine("[0] : Quit\n[1]: BubbleSort\n[2]: Quick Sort\n[3]: Merge Sort\n" +
                "[4]: Insertion Sort\n[5]: Bucket Sort\n[6] : Selection Sort");
            int input = 0; int low = 0; int high = 0;
            Comparer<T> comp = Comparer<T>.Default;
            do
            {
                if (int.TryParse(Console.ReadLine(), out int result) == true)
                {
                    input = result;
                }
            } while (int.TryParse(Console.ReadLine(), out int alternateResult));
            if (showSteps == true)
            {
                switch (input)
                {
                    case 1:
                        BubbleSort bubbleS = new BubbleSort();
                        bubbleS.PerformSortStepwise<T>(_arrayToSort, comp);
                        break;
                    case 2:
                        QuickSort quickS = new QuickSort();
                        do
                        {
                            if (int.TryParse(Console.ReadLine(), out int result) == true)
                            {
                                low = result;
                            }
                        } while (int.TryParse(Console.ReadLine(), out int alternateResult));
                        do
                        {
                            if (int.TryParse(Console.ReadLine(), out int result) == true)
                            {
                                high = result;
                            }
                        } while (int.TryParse(Console.ReadLine(), out int alternateResult));
                        quickS.PerformSortStepwise<T>(_arrayToSort, low, high);
                        break;
                    case 3:
                        MergeSort mergeS = new MergeSort();
                        mergeS.PerformSortStepwise<T>(_arrayToSort, comp);
                        break;
                    case 4:
                        InsertionSort insertionS = new InsertionSort();
                        insertionS.PerformSortStepwise<T>(_arrayToSort, comp);
                        break;
                    case 5:
                        BucketSort bucketS = new BucketSort();
                        bucketS.PerformSortStepwise<T>(_arrayToSort, comp);
                        break;
                    case 6:
                        SelectionSort selectionS = new SelectionSort();
                        selectionS.PerformSortStepwise<T>(_arrayToSort, comp);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }else
            {
                switch (input)
                {
                    case 1:
                        BubbleSort bs = new BubbleSort();
                        bs.PerformSort<T>(_arrayToSort, comp);
                        break;
                    case 2:
                        QuickSort quickS = new QuickSort();
                        do
                        {
                            if (int.TryParse(Console.ReadLine(), out int result) == true)
                            {
                                low = result;
                            }
                        } while (int.TryParse(Console.ReadLine(), out int alternateResult));
                        do
                        {
                            if (int.TryParse(Console.ReadLine(), out int result) == true)
                            {
                                high = result;
                            }
                        } while (int.TryParse(Console.ReadLine(), out int alternateResult));
                        quickS.PerformSortStepwise<T>(_arrayToSort, low, high);
                        break;
                    case 3:
                        MergeSort mergeS = new MergeSort();
                        mergeS.PerformSort<T>(_arrayToSort, comp);
                        break;
                    case 4:
                        InsertionSort insertionS = new InsertionSort();
                        insertionS.PerformSort<T>(_arrayToSort, comp);
                        break;
                    case 5:
                        BucketSort bucketS = new BucketSort();
                        bucketS.PerformSort<T>(_arrayToSort, comp);
                        break;
                    case 6:
                        SelectionSort selectionS = new SelectionSort();
                        selectionS.PerformSort<T>(_arrayToSort, comp);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }
        public virtual void PerformSort<T>(T[] _array, int _low, int _high)
        {
            //Overwritten in QuickSort
        }
        public virtual void PerformSortStepwise<T>(T[] _array, int _low, int _high)
        {
            //Overwritten in QuickSort
        }


        public virtual void PrintArray<T>(T[] _array)
        {
            //Console.WriteLine("Printing array...");
            Console.Write("Index: ");
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write($"[{i}]");
            }
            Console.Write("\nValue: ");
            for (int i = 0; i < _array.Length; i++)
            {
                Console.Write($"[{_array[i].ToString()}]");
            }
            Console.WriteLine("\n");
        }

        public virtual void PerformSort<T>(T[] _array, Comparer<T> _comp) 
        {
            Console.WriteLine("Initialize objects of subclasses to perform according Sort");
        }

        public virtual void PerformSortStepwise<T>(T[] _array, Comparer<T> _comp)
        {
            Console.WriteLine("Initialize objects of subclasses to perform according Sort");
        }

        public static void Main(string[] args)
        {
            SortingStrategy strategy = new SortingStrategy();

            //Examplearray when not initializing one with start:
            float[] arr = { 3.4f, 4.5f, 6.22f, 1.33f, 2.44f, 8.99f };

            //Example comparer for the generic type T:
            Comparer<float> comp = Comparer<float>.Default;

            Start();

            #region BubbleSortTest
            //BubbleSort bubble = new BubbleSort();
            //bubble.PerformSortStepwise<float>(arr, comp);
            ////bubble.PerformSort<float>(arr, comp);
            #endregion

            #region QuickSortTest
            //QuickSort quick = new QuickSort();
            //int low = 0;
            //int high = 5;
            ////quick.PerformSort<float>(arr, low, high);
            //quick.PerformSortStepwise<float>(arr, low, high);
            #endregion

            Console.WriteLine("\nfinal array:\n");
            strategy.PrintArray<float>(arr);

            //strategy.Start();

            Console.Read();
        }
    }
}
