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
        public static void Monitoring(Action action)
        {
            Stopwatch st = new Stopwatch();
            st.Start();
            action.Invoke();
            st.Stop();
            Console.WriteLine($"Time cost : {st.ElapsedMilliseconds}ms");
            Console.WriteLine($"Time cost : {st.ElapsedTicks}ticks");
        }

        public static async Task MonitoringAsync(Action action)
        {
            Stopwatch st = new Stopwatch();
            Task t = new Task(action);
            st.Start();
            t.Start();
            await t;
            st.Stop();
            Console.WriteLine($"Time cost : {st.ElapsedMilliseconds}ms");
            Console.WriteLine($"Time cost : {st.ElapsedTicks}ticks");
        }

        public static int[] RandomArray(int length, int Min = 0, int Max = 1000)
        {
            Random rd = new Random();
            List<int> arr = new List<int>();
            for (int i = 0; i < length; i++)
            {
                arr.Add(rd.Next(Min, Max));
            }
            return arr.ToArray();
        }

        public static long Factorial(int i)
        {
            int f = 1;
            for (int j = 2; j <= i; j++)
            {
                f *= j;
            }
            return f;
        }
    }
}
