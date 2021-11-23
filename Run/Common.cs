using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Console.WriteLine($"Time cost : {st.Elapsed.Seconds}s:{st.Elapsed.Milliseconds}ms({st.Elapsed.Ticks}ticks)");
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
            res += $"Time cost : {st.Elapsed.Seconds}s:{st.Elapsed.Milliseconds}ms({st.Elapsed.Ticks}ticks)\n";
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

        public static void HoanVi(int[] A, int[] RS, bool[] Bool, int k = 0)
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
    }
}
