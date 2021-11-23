using BinaryTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    public static class Practice_III
    {
        public static int[] MergeSort(this int[] array)
        {
            int[] left;
            int[] right;
            int[] result = new int[array.Length];
            //As this is a recursive algorithm, we need to have a base case to 
            //avoid an infinite recursion and therfore a stackoverflow
            if (array.Length <= 1)
                return array;
            // The exact midpoint of our array  
            int midPoint = array.Length / 2;
            //Will represent our 'left' array
            left = new int[midPoint];

            //if array has an even number of elements, the left and right array will have the same number of 
            //elements
            if (array.Length % 2 == 0)
                right = new int[midPoint];
            //if array has an odd number of elements, the right array will have one more element than left
            else
                right = new int[midPoint + 1];
            //populate left array
            for (int i = 0; i < midPoint; i++)
                left[i] = array[i];
            //populate right array   
            int x = 0;
            //We start our index from the midpoint, as we have already populated the left array from 0 to midpont
            for (int i = midPoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
            }
            //Recursively sort the left array
            left = MergeSort(left);
            //Recursively sort the right array
            right = MergeSort(right);
            //Merge our two sorted arrays
            result = merge(left, right);
            return result;
        }

        //This method will be responsible for combining our two sorted arrays into one giant array
        private static int[] merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] result = new int[resultLength];
            //
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            //while either array still has an element
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //If item on left array is less than item on right array, add that item to the result array 
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //if only the right array still has elements, add all its items to the results array
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

        private static void Quick_Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }

        public static void QuickSort(this int[] arr)
        {
            Quick_Sort(arr, 0, arr.Length - 1);
        }

        public static void BubbleSort(this int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i]
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
        }

        public static BTree ToBTree(this int[] arr)
        {
            return new BTree(arr);
        }

        public static void TestSort(int n)
        {
            int[] arr = Common.RandomArray(n, -n, n);
            int[] temp = arr.Clone() as int[];
            //temp.Print();
            Common.Monitoring(() =>
            {
                temp.QuickSort();
                Console.WriteLine("Quick sort: ");
            });
            //temp.Print();

            temp = arr.Clone() as int[];

            Common.Monitoring(() =>
            {
                temp = temp.MergeSort();
                Console.WriteLine("Merge sort: ");
            });
            //temp.Print();
            var list = arr.ToList();
            Common.Monitoring(() =>
            {
                list.Sort();
                Console.WriteLine("Bult in: ");
            });
            //list.ToArray().Print();
            temp = arr.Clone() as int[];
            //Common.Monitoring(() =>
            //{
            //    temp.BubbleSort();
            //    Console.WriteLine("Bubble sort: ");
            //    //temp.Print();
            //});

        }
        public static void Print(this int[] arr, bool NewLine = true)
        {
            arr.SkipLast(1).ToList().ForEach(i => Console.Write(i + "; "));
            Console.Write(arr[arr.Length - 1]);
            if (NewLine)
            {
                Console.WriteLine();
            }
        }

        public static ulong DoubleFactorialRecursive(int n)
        {
            return Common.FactorialRecursive((long)Common.FactorialRecursive(n));
        }

        public static ulong DoubleFactorialDynamic(int n)
        {
            ulong rs = 1;
            var temp = (ulong)n;
            for (ulong i = 2; i <= temp; i++)
            {
                rs *= i;
            }
            ulong tempRs = rs;
            for (ulong i = temp + 1; i <= tempRs; i++)
            {
                rs *= i;
            }
            return rs;
        }

        public static void TestDoubleFactorial(int n)
        {
            Common.Monitoring(() =>
            {
                Console.WriteLine("Đệ quy: " + DoubleFactorialRecursive(n));
            });
            Common.Monitoring(() =>
            {
                Console.WriteLine("Quy hoạch động: " + DoubleFactorialDynamic(n));
            });
        }
    }
}
