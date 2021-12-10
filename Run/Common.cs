using BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    public static class Common
    {
        /// <summary>
        /// Đo thời gian chạy của đoạn code
        /// 
        /// Ví dụ:
        /// Common.Monitoring(() =>
        /// {
        ///     Gọi hàm hoặc viết code cần đo vào đây.
        /// });
        /// 
        /// </summary>
        /// <param name="action">Lệnh cần thực hiện</param>
        public static void Monitoring(Action action)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            action.Invoke();
            st.Stop();
            Console.WriteLine($"Time cost :{st.Elapsed.Minutes}m:{st.Elapsed.Seconds}s:{st.Elapsed.Milliseconds}ms({st.Elapsed.Ticks}ticks)");
            Console.WriteLine();
        }

        public static async Task MonitoringAsync(Func<string> action)
        {
            Stopwatch st = new Stopwatch();
            Task<string> t = new Task<string>(action);
            st.Start();
            t.Start();
            await t;
            st.Stop();
            var res = t.Result;
            res += $"Time cost : {st.Elapsed.Minutes}m:{st.Elapsed.Seconds}s:{st.Elapsed.Milliseconds}ms({st.Elapsed.Ticks}ticks)\n";
            Console.WriteLine(res);
        }

        /// <summary>
        /// Tạo một mảng ngẫu nhiên
        /// </summary>
        /// <param name="length">Kích thước mảng</param>
        /// <param name="Min">Giá trị tối thiểu</param>
        /// <param name="Max">Giá trị tối đa</param>
        /// <returns></returns>
        public static int[] RandomArray(int length, int Min = 0, int Max = 1000)
        {
            Random rd = new Random();

            int[] arr = new int[length];

            for (int i = 0; i < length; i++)
            {

                arr[i] = rd.Next(Min, Max);

            }

            return arr;
        }

        /// <summary>
        /// Giai thừa
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static ulong Factorial(int i)
        {
            ulong f = 1;
            for (ulong j = 2; j.CompareTo(i) < 0; j++)
            {
                f *= j;
            }
            return f;
        }

        public static ulong FactorialRecursive(long i)
        {
            if (i <= 1)
            {
                return 1;
            }
            else
            {
                return (ulong)i * FactorialRecursive(i - 1);
            }
        }

        public static void HoanVi(this int[] A, int[] RS, bool[] Bool, int k = 0)
        {
            int n = A.Length;
            for (int i = 0; i < n; i++)
            {
                //Kiểm tra nếu phần tử chưa được chọn thì sẽ đánh dấu
                if (!Bool[i])
                {
                    RS[k] = A[i]; // Lưu một phần tử vào hoán vị
                    Bool[i] = true;//Đánh dấu đã dùng
                    if (k == n - 1)//Kiểm tra nếu đã chứa một hoán vị thì xuất
                    {
                        RS.SkipLast(1).ToList().ForEach(s => Console.Write(s + " ; "));
                        Console.Write(RS[RS.Length - 1]);
                        Console.WriteLine();
                    }
                    else
                        HoanVi(A, RS, Bool, k + 1);
                    Bool[i] = false;
                }
            }
        }

        public static void HoanViMang()
        {
            int[] A = RandomArray(3,0, 5);
            Console.WriteLine("Mảng ban đầu: ");
            A.SkipLast(1).ToList().ForEach(s => Console.Write(s + " ; "));
            Console.Write(A[A.Length - 1]);
            Console.WriteLine("\nCác hoán vị: ");
            HoanVi(A, new int[A.Length], new bool[A.Length]);
        }

        public static void Print(this IEnumerable arr, bool NewLine = true, long Max = long.MaxValue)
        {
            int Count = 0;
            foreach (var item in arr)
            {
                Count++;
                Console.Write(item + "; ");
                if (Count == Max)
                {
                    break;
                }
            }
            if (NewLine)
            {
                Console.WriteLine();
            }
        }

        public static BTree ToBTree(this int[] arr)
        {
            return new BTree(arr);
        }

        public static string LCS(string a, string b)
        {
            List<char> max = new List<char>(Math.Max(a.Length, b.Length));
            List<char> temp = new List<char>(Math.Max(a.Length, b.Length));
            for (int i = 0; i < a.Length - max.Count; i++)
            {
                temp.Clear();
                for (int j = 0; j < b.Length;j++)
                {
                    if (a[i] == b[j])
                    {
                        temp.Add(a[i]);
                        i++;
                        if (i >= a.Length)
                        {
                            break;
                        }
                    }
                    
                }
                if (temp.Count > max.Count)
                {
                    max.Clear();
                    max.AddRange(temp);
                }

            }
            return string.Concat(max.ToArray());
        }

        public static string RandomString(int n)
        {
            Random rd = new Random();
            char[] rs = new char[n];
            for (int i = 0; i < n; i++)
            {
                rs[i] = char.Parse(char.ConvertFromUtf32(rd.Next(97, 122)));
            }
            return string.Concat(rs);
        }

        #region Sort
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

        private static int PartitionForIntro(int[] data, int left, int right)
        {
            int pivot = data[right];
            int temp;
            int i = left;

            for (int j = left; j < right; ++j)
            {
                if (data[j] <= pivot)
                {
                    temp = data[j];
                    data[j] = data[i];
                    data[i] = temp;
                    i++;
                }
            }

            data[right] = data[i];
            data[i] = pivot;

            return i;
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

        public static void IntroSort(this int[] data)
        {
            int partitionSize = PartitionForIntro(data, 0, data.Length - 1);

            if (partitionSize < 16)
            {
                data.InsertionSort();
            }
            else if (partitionSize > (2 * Math.Log(data.Length)))
            {
                data.HeapSort();
            }
            else
            {
                data.QuickSortRecursive(0, data.Length - 1);
            }
        }

        private static void InsertionSort(this int[] data)
        {
            for (int i = 1; i < data.Length; ++i)
            {
                int j = i;

                while ((j > 0))
                {
                    if (data[j - 1] > data[j])
                    {
                        data[j - 1] ^= data[j];
                        data[j] ^= data[j - 1];
                        data[j - 1] ^= data[j];

                        --j;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        private static void HeapSort(this int[] data)
        {
            int heapSize = data.Length;

            for (int p = (heapSize - 1) / 2; p >= 0; --p)
                MaxHeapify(data, heapSize, p);

            for (int i = data.Length - 1; i > 0; --i)
            {
                int temp = data[i];
                data[i] = data[0];
                data[0] = temp;

                --heapSize;
                MaxHeapify(data, heapSize, 0);
            }
        }

        private static void MaxHeapify(int[] data, int heapSize, int index)
        {
            int left = (index + 1) * 2 - 1;
            int right = (index + 1) * 2;
            int largest;

            if (left < heapSize && data[left] > data[index])
                largest = left;
            else
                largest = index;

            if (right < heapSize && data[right] > data[largest])
                largest = right;

            if (largest != index)
            {
                int temp = data[index];
                data[index] = data[largest];
                data[largest] = temp;

                MaxHeapify(data, heapSize, largest);
            }
        }

        private static void QuickSortRecursive(this int[] data, int left, int right)
        {
            if (left < right)
            {
                int q = PartitionForIntro(data, left, right);
                QuickSortRecursive(data, left, q - 1);
                QuickSortRecursive(data, q + 1, right);
            }
        }
        #endregion


        public static void WriteToFile(object value)
        {
            StreamWriter writer = new StreamWriter("data.txt", false);
            writer.Write(value);
            writer.Close();
        }

        public static string ReadFormFile()
        {
            StreamReader reader = new StreamReader("data.txt");
            var rs = reader.ReadToEnd();
            reader.Close();
            return rs;
        }
    }
}
