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

        public static int BuiltInBinarySearch(List<int> arr, int x)
        {
            return arr.BinarySearch(x);
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
            List<int> list = sortedArr.ToList();

            var t1 = Common.MonitoringAsync(() =>
            {
                var index = LinearSearch(sortedArr, x);
                var res = "Tìm kiếm tuần tự (vị trí): " + index + "\n";
                res += "Tìm kiếm tuần tự (giá trị): " + sortedArr[index] + "\n";
                return res;
            });


            var t2 = Common.MonitoringAsync(() =>
            {
                var index = BuiltInBinarySearch(list, x);
                var res = "Tìm kiếm nhị phân xây sẵn (vị trí): " + index + "\n";
                res += "Tìm kiếm nhị phân xây sẵn (giá trị): " + sortedArr[index] + "\n";
                return res;
            });

            var t3 = Common.MonitoringAsync(() =>
            {
                var index = BinarySearch(sortedArr, x);
                var res = "Tìm kiếm nhị phân (vị trí): " + index + "\n";
                res += "Tìm kiếm nhị phân (giá trị): " + sortedArr[index] + "\n";
                return res;
            });

            var t4 = Common.MonitoringAsync(() =>
            {
                var index = BinarySearchRecursive(sortedArr,0,sortedArr.Length, x);
                var res = "Tìm kiếm nhị phân đệ quy (vị trí): " + index + "\n";
                res += "Tìm kiếm nhị phân đệ quy (giá trị): " + sortedArr[index] + "\n";
                return res;
            });
            Task.WaitAll(t1, t2, t3, t4);
        }

        public static int BinarySearchRecursive(int[] arr, int l, int r, int x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                // If the element is present at the middle
                // itself
                if (arr[mid] == x)
                    return mid;

                // If element is smaller than mid, then
                // it can only be present in left subarray
                if (arr[mid] > x)
                    return BinarySearchRecursive(arr, l, mid - 1, x);

                // Else the element can only be present
                // in right subarray
                return BinarySearchRecursive(arr, mid + 1, r, x);
            }

            // We reach here when element is not
            // present in array
            return -1;
        }

        public static int Min(this int[] a, int left, int right)
        {
            if (left == right) return a[left];
            int m = Min(a, left + 1, right);
            return (a[left] < m) ? a[left] : m;
        }

        public static int Max(this int[] a, int left, int right)
        {
            if (left == right) return a[left];
            int m = Max(a, left + 1, right);
            return (a[left] < m) ? m : a[left];
        }

        public static int[] MinMax(this int[] A)
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

        public static void MaxMinRecursive(this int[] a, int dau, int cuoi,out int min,out int max)
        {
            int min1, min2, max1, max2;
            if (dau == cuoi)
            {
                min = a[dau];
                max = a[dau];
            }
            else
            {

                a.MaxMinRecursive(dau, (dau + cuoi) / 2,out min1,out max1);
                a.MaxMinRecursive((dau + cuoi) / 2 + 1, cuoi,out min2,out max2);
                if (min1 < min2)
                    min = min1;
                else
                    min = min2;
                if (max1 > max2)
                    max = max1;
                else
                    max = max2;
            }
        }

        public static void TestMinMax(int n)
        {
            var arr = Common.RandomArray(n, -n, n);

            //Console.WriteLine("Kích thước mảng: " + n);
            //arr.Print();

            //Common.Monitoring(() =>
            //{
            //    Console.WriteLine("Chia để trị không tích hợp: ");
            //    try
            //    {
            //        Console.WriteLine("Số nhỏ nhất : " + Min(arr,0, arr.Length - 1));
            //        Console.WriteLine("Số lớn nhất : " + Max(arr,0, arr.Length - 1));
            //    }
            //    catch (StackOverflowException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //});
            Common.Monitoring(() =>
            {
                Console.WriteLine("Chia để trị tích hợp: ");
                try
                {
                    int Min, Max;
                    arr.MaxMinRecursive(0, arr.Length - 1, out Min, out Max);
                    Console.WriteLine("Số nhỏ nhất : " + Min);
                    Console.WriteLine("Số lớn nhất : " + Max);
                }
                catch (StackOverflowException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
            Common.Monitoring(() =>
            {
                Console.WriteLine("Tuyến tính: ");
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

        public static int BestArr(int[] arr, int best = int.MinValue, int sum = 0)
        {
            if (arr.Length == 0)
            {
                return best;
            }
            else
            {
                if (sum + arr[0] < arr[0])
                {
                    sum = arr[0];
                }
                else
                {
                    sum += arr[0];
                }
                if (best < sum)
                {
                    best = sum;
                }
                return BestArr(arr.Skip(1).ToArray(), best, sum);
            }
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

            Console.WriteLine("Số phần tử của mảng:" + arr.Length);

            Console.WriteLine($"ai thuộc [{-n},{n}]");

            Console.WriteLine("Tổng mảng: " + arr.Sum());

            Console.WriteLine();

            var t1 = Common.MonitoringAsync(() =>
            {
                var res = "Giải thuật 1 (N^3): ";
                int sum = 0;
                BestArrayN3(arr.Take(arr.Length/10).ToArray()).ToList().ForEach(a => sum += a);
                res += sum + "\n";
                res += "(Đã giảm 90% số lượng phần tử)\n";
                return res;
            });

            var t2 = Common.MonitoringAsync(() =>
            {
                var res = "Giải thuật 2 (N^2): ";
                int sum = 0;
                BestArrayN2(arr).ToList().ForEach(a => sum += a);
                return res += sum + "\n";
            });

            var t3 = Common.MonitoringAsync(() =>
            {
                var res = "Giải thuật 3 (N): ";
                int sum = 0;
                BestArrayN(arr).ToList().ForEach(a => sum += a);
                return res += sum + "\n";
            });

            var t4 = Common.MonitoringAsync(() =>
            {
                var res = "Giải thuật 4 (N): ";
                int sum = 0;
                sum = BestArr(arr);
                return res += sum + "\n";
            });

            Task.WaitAll(t1, t2, t3, t4);
        }

        private static void Quick_Sort1(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition1(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort1(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort1(arr, pivot + 1, right);
                }
            }
        }

        private static int Partition1(int[] arr, int left, int right)
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

        private static void Quick_Sort2(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition1(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort2(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort2(arr, pivot + 1, right);
                }
            }
        }

        static public int Partition2(int[] arr, int left, int right)
        {
            int pivot;

            int mid = (left + right) / 2;
            pivot = arr[mid];

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
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return mid;
                }
            }
        }

        private static void Quick_Sort3(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition1(arr, left, right);

                if (pivot > 1)
                {
                    Quick_Sort3(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    Quick_Sort3(arr, pivot + 1, right);
                }
            }
        }

        static public int Partition3(int[] arr, int left, int right)
        {
            int pivot;

            pivot = arr[right];

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
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                }
                else
                {
                    return left;
                }
            }
        }

        public static void TestSort(int n)
        {
            int[] arr = Common.RandomArray(n, -n, n);

            Common.Monitoring(() =>
            {
                var temp = arr.Clone() as int[];
                Quick_Sort1(temp, 0, n - 1);
                temp.ToList().ForEach(i => Console.Write(i + "; "));
                Console.WriteLine("Phương pháp 1");
            });

            Common.Monitoring(() =>
            {
                var temp = arr.Clone() as int[];
                Quick_Sort2(temp, 0, n - 1);
                temp.ToList().ForEach(i => Console.Write(i + "; "));
                Console.WriteLine("Phương pháp 2");
            });

            Common.Monitoring(() =>
            {
                var temp = arr.Clone() as int[];
                Quick_Sort3(temp, 0, n - 1);
                temp.ToList().ForEach(i => Console.Write(i + "; "));
                Console.WriteLine("Phương pháp 3");
            });
        }
    }
}
