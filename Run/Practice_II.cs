using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    public static class Practice_II
    {
        public static int LinearSearch(int[] arr, int x)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == x)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int BuiltInBinarySearch(int[] arr, int x)
        {
            return arr.ToList().BinarySearch(x);
        }

        public static int BinarySearch(int[] arr, int x)
        {
            int minNum = 0;
            int maxNum = arr.Length - 1;

            while (minNum <= maxNum)
            {
                int mid = (minNum + maxNum) / 2;
                if (x == arr[mid])
                {
                    return mid;
                }
                else if (x < arr[mid])
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }
            return -1;
        }

        public static void TestSearch(int n, int x)
        {
            List<int> arr = Common.RandomArray(n, -n, n).ToList();
            arr.Sort();
            x = arr[x];
            var sortedArr = arr.ToArray();

            Common.Monitoring(() =>
            {
                Console.WriteLine("Tìm kiếm tuần tự : " + LinearSearch(sortedArr, x));
            });

            Common.Monitoring(() =>
            {
                Console.WriteLine("Tìm kiếm nhị phân xây sẵn : " + BuiltInBinarySearch(sortedArr, x));
            });

            Common.Monitoring(() =>
            {
                Console.WriteLine("Tìm kiếm nhị phân : " + BinarySearch(sortedArr, x));
            });
        }


        public static int Min(int[] a, int left, int right)
        {
            if (left == right) return a[left];
            int m = Min(a, left + 1, right);
            return (a[left] < m) ? a[left] : m;
        }
        public static int Max(int[] a, int left, int right)
        {
            if (left == right) return a[left];
            int m = Max(a, left + 1, right);
            return (a[left] < m) ? m : a[left];
        }

        public static int[] MinMax(int[] A)
        {
            int min = A[0];
            int max = A[0];
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > max)
                {
                    max = A[i];
                }
                else if (A[i] < min)
                {
                    min = A[i];
                }
            }
            return new int[] { min, max };
        }

        public static void TestMinMax(int n)
        {
            var arr = Common.RandomArray(n, -n, n);


            Common.Monitoring(() =>
            {
                Console.WriteLine("Chia để trị");
                try
                {
                    Console.WriteLine("Số nhỏ nhất : " + Min(arr,0, arr.Length - 1));
                    Console.WriteLine("Số lớn nhất : " + Max(arr,0, arr.Length - 1));
                }
                catch (StackOverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
            Common.Monitoring(() =>
            {
                Console.WriteLine("Tuyến tính");
                var rs = MinMax(arr);
                Console.WriteLine("Số nhỏ nhất : " + rs[0]);
                Console.WriteLine("Số lớn nhất : " + rs[1]);
            });
        }


        public static int[] BestArrayN3(int[] arr)
        {
            int best = int.MinValue;
            int startIndex = 0;
            int endIndex = 0;
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    int sum = 0;
                    for (int k = i; k <= j; k++)
                    {
                        sum += arr[k];
                    }
                    if (sum > best)
                    {
                        startIndex = i;
                        endIndex = j;
                        best = sum;
                    }
                }
            }
            return arr.Skip(startIndex).Take(endIndex - startIndex + 1).ToArray();
        }

        public static int[] BestArrayN2(int[] arr)
        {
            int best = int.MinValue;
            int n = arr.Length;
            int startIndex = 0;
            int endIndex = 0;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = i; j < n; j++)
                {
                    sum += arr[j];
                    if (sum > best)
                    {
                        startIndex = i;
                        endIndex = j;
                        best = sum;
                    }
                }
            }
            return arr.Skip(startIndex).Take(endIndex - startIndex + 1).ToArray();
        }

        public static int[] BestArrayN(int[] arr)
        {
            int best = int.MinValue, sum = 0;
            int best_start = 0, best_end = 0, current_start = 0;
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                if (sum + arr[i] < arr[i])
                {
                    current_start = i;
                    sum = arr[i];
                }
                else
                {
                    sum += arr[i];
                }

                if (best < sum)
                {
                    best = sum;
                    best_start = current_start;
                    best_end = i;
                }
            }
            return arr.Skip(best_start).Take(best_end - best_start + 1).ToArray();
        }

        public static void TestBestArray(int n)
        {
            var arr = Common.RandomArray(n, -n, n);

            Common.Monitoring(() =>
            {
                Console.WriteLine("Giải thuật 1 (N^3): ");
                int sum = 0;
                BestArrayN3(arr).ToList().ForEach(a => sum += a);
                Console.WriteLine(sum);
            });
            Common.Monitoring(() =>
            {
                Console.WriteLine("Giải thuật 2 (N^2): ");
                int sum = 0;
                BestArrayN2(arr).ToList().ForEach(a => sum += a);
                Console.WriteLine(sum);
            });
            Common.Monitoring(() =>
            {
                Console.WriteLine("Giải thuật 3 (N): ");
                int sum = 0;
                BestArrayN(arr).ToList().ForEach(a => sum += a);
                Console.WriteLine(sum);
            });
        }
    }
}
