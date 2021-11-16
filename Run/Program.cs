using System;
using System.Collections.Generic;
using System.Linq;

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
            //Practice_II.TestSearch(1000000, 901239);
            #endregion

            #region 2.2
            //Practice_II.TestMinMax(10000);
            #endregion

            #region 2.3
            Practice_II.TestBestArray(1000);
            #endregion
        }
        public static string Input(object Text)
        {
            Console.Write(Text);
            return Console.ReadLine();
        }
    }
}
