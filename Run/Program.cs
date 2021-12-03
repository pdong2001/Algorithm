using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Run
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            #region 1.0
            //int[] arr = EX_I.RandomArray(100, 0, 200);
            //EX_I.Monitoring(() =>
            //{
            //    Console.WriteLine("Giải thuật 1: " + EX_I.Example_I.ForLoop(arr, 10));
            //});
            //EX_I.Monitoring(() =>
            //{
            //    Console.WriteLine("Giải thuật 2: " + EX_I.Example_I.UpgradeLoop(arr, 10));
            //});
            //EX_I.Monitoring(() =>
            //{
            //    Console.WriteLine("Giải thuật 3: " + EX_I.Example_I.Hoocne(arr, 10));
            //});
            #endregion

            #region 1.1
            //double x = double.Parse(Input("Nhập x: "));
            //int n = int.Parse(Input("Nhập n: "));
            //EX_I.Monitoring(() =>
            //{
            //    Console.WriteLine("Giải thuật 1: " + EX_I.I.AlgorithmI(n, x));
            //});
            //EX_I.Monitoring(() =>
            //{
            //    Console.WriteLine("Giải thuật 2: " + EX_I.I.AlgorithmII(n, x));
            //});
            //EX_I.Monitoring(() =>
            //{
            //    Console.WriteLine("Giải thuật 3: " + EX_I.I.AlgorithmIII(n, x));
            //});
            #endregion

            #region 1.2
            //int[] arr = Common.RandomArray(1000000, 0, 20);

            ////arr.ToList().ForEach(a =>
            ////{
            ////    Console.Write(a + " ; ");
            ////});

            //Console.WriteLine();

            //Common.Monitoring(() =>
            //{
            //    Console.WriteLine("Giải thuật 1: ");
            //    Practice_I.II.AlgorithmI(arr.Clone() as int[], 900000);
            //});


            //Common.Monitoring(() =>
            //{
            //    Console.WriteLine("Giải thuật 2: ");
            //    Practice_I.II.AlgorithmI(arr.Clone() as int[], 900000);
            //});

            //Common.Monitoring(() =>
            //{
            //    Console.WriteLine("Giải thuật 3: ");
            //    Practice_I.II.AlgorithmIII(arr.Clone() as int[], 900000);
            //});
            #endregion

            #region 2.1
            //Practice_II.TestSearch(10000000, 9001239);
            #endregion

            #region 2.2
            //Practice_II.TestMinMax(10000000);
            #endregion

            #region 2.3
            Practice_II.TestBestArray(15000);
            #endregion

            #region QuickSort
            //Practice_II.TestSort(10);
            #endregion

            //Common.HoanViMang();

            //TestFibonaci(40);

            //Practice_III.TestSort(10000000);

            //Practice_III.Strassen.TestStrassen(6);

            //Practice_IV.TestLCS(18);

            //Practice_III.TestDoubleFactorial(3);

        }
        public static string Input(object Text)
        {
            Console.Write(Text);
            return Console.ReadLine();
        }

        public static void TestFibonaci(int n)
        {
            var t1 = Common.MonitoringAsync(() =>
            {
                var res = "Đệ quy : ";
                var f = Dynamic.FibonaciRecursive(n);
                return res += f + "\n";
            });

            var t2 = Common.MonitoringAsync(() =>
            {
                var res = "Quy hoạch động : ";
                var f = Dynamic.FibonaciDynamic(n);
                return res += f + "\n";
            });

            Task.WaitAll(t1, t2);
        }
    }
}
