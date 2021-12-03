using BinaryTree;
using PhuongPhapTinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    public static class Practice_III
    {
        public static void TestSort(int n)
        {
            int[] arr = Common.RandomArray(n, -n, n);
            int[] temp = arr.Clone() as int[];
            Console.WriteLine("Kích thước mảng: " + string.Format("{0:n0}", arr.Length));
            Console.WriteLine("50 phần tử đầu mảng: ");
            temp.Print(Max: 50);

            //Common.Monitoring(() =>
            //{
            //    temp.QuickSort();
            //    Console.WriteLine("Quick sort: ");
            //});
            //temp.Print(Max: 50);

            temp = arr.Clone() as int[];
            Common.Monitoring(() =>
            {
                temp = temp.MergeSort();
                Console.WriteLine("Merge sort: ");
                temp.Print(Max : 50);
            });
            //temp.Print(Max: 50);
            //temp = arr.Clone() as int[];
            //Common.Monitoring(() =>
            //{
            //    temp.IntroSort();
            //    Console.WriteLine("Intro sort: ");
            //});
            //temp.Print(Max : 50);
            //list.Print(Max:50);
            Common.Monitoring(() =>
            {
                var list = new List<int>(arr);
                list.Sort();
                Console.WriteLine("C# Intro sort with sort helper: ");
                list.Print(Max: 50);
            });
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

        public static class Strassen
        {
            public static void In(int[,] a, int n)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine();
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(a[i,j]);
                    }
                }
            }
            public static void ChiaNho(int n, int[,] x, int[,] a, int[,] b, int[,] c, int[,] d)
            {
                int m = n / 2;

                for (int i = 0; i < m; i++)
                    for (int j = 0; j < m; j++)
                        a[i , j] = x[i , j];

                for (int i = 0; i < m; i++)
                    for (int j = m; j < n; j++)
                        b[i , j - m] = x[i , j];

                for (int i = m; i < n; i++)
                    for (int j = 0; j < m; j++)
                        c[(i - m) , j] = x[i , j];

                for (int i = m; i < n; i++)
                    for (int j = m; j < n; j++)
                        d[(i - m) , j - m] = x[i , j];
            }
            public static void CongMaTran(int n, int[,] a, int[,] b, int[,] c)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        c[i , j] = a[i , j] + b[i , j];
            }
            public static void TruMaTran(int n, int[,] a, int[,] b, int[,] c)
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        c[i , j] = a[i , j] - b[i , j];
            }
            public static void NhanMaTran(int[,] a, int[,] b, int[,] c)
            {
                int m1, m2, m3, m4, m5, m6, m7;
                m1 = (a[0 , 1] - a[1 , 1]) * (b[1 , 0] + b[1 , 1]);
                m2 = (a[0 , 0] + a[1 , 1]) * (b[0 , 0] + b[1 , 1]);
                m3 = (a[0 , 0] - a[1 , 0]) * (b[0 , 0] + b[0 , 1]);
                m4 = (a[0 , 0] + a[0 , 1]) * b[1 , 1];
                m5 = a[0 , 0] * (b[0 , 1] - b[1 , 1]);
                m6 = a[1 , 1] * (b[1 , 0] - b[0 , 0]);
                m7 = (a[1 , 0] + a[1 , 1]) * b[0 , 0];

                c[0 , 0] = m1 + m2 - m4 + m6;
                c[0 , 1] = m4 + m5;
                c[1 , 0] = m6 + m7;
                c[1 , 1] = m2 - m3 + m5 - m7;
            }
            public static void ToHop(int n, int[,] x, int[,] a, int[,] b, int[,] c, int[,] d)
            {
                int m = n / 2;

                for (int i = 0; i < m; i++)
                    for (int j = 0; j < m; j++)
                        x[i , j] = a[i , j];

                for (int i = 0; i < m; i++)
                    for (int j = m; j < n; j++)
                        x[i , j] = b[i , j - m];

                for (int i = m; i < n; i++)
                    for (int j = 0; j < m; j++)
                        x[i , j] = c[(i - m) , j];

                for (int i = m; i < n; i++)
                    for (int j = m; j < n; j++)
                        x[i , j] = d[(i - m) , j - m];
            }
            public static void Multi(int[,] a, int[,] b, int[,] c, int n)
            {
                if (n == 2)
                    NhanMaTran(a, b, c);
                else
                {
                    int[,] d1 = new int[n, n];
                    int[,] d2 = new int[n ,n];
                    int[,] a00 = new int[n, n];
                    int[,] a01 = new int[n, n];
                    int[,] a10 = new int[n, n];
                    int[,] a11 = new int[n, n];
                    int[,] b00 = new int[n, n];
                    int[,] b01 = new int[n, n];
                    int[,] b10 = new int[n, n];
                    int[,] b11 = new int[n, n];
                    int[,] c00 = new int[n, n];
                    int[,] c01 = new int[n, n];
                    int[,] c10 = new int[n, n];
                    int[,]c11 = new int[n , n];

                    ChiaNho(n, a, a00, a01, a10, a11);
                    ChiaNho(n, b, b00, b01, b10, b11);
                    ChiaNho(n, c, c00, c01, c10, c11);

                    Multi(a00, b00, d1, n / 2);
                    Multi(a01, b10, d2, n / 2);
                    CongMaTran(n / 2, d1, d2, c00);

                    Multi(a00, b01, d1, n / 2);
                    Multi(a01, b11, d2, n / 2);
                    CongMaTran(n / 2, d1, d2, c01);

                    Multi(a10, b00, d1, n / 2);
                    Multi(a11, b10, d2, n / 2);
                    CongMaTran(n / 2, d1, d2, c10);

                    Multi(a10, b01, d1, n / 2);
                    Multi(a11, b11, d2, n / 2);
                    CongMaTran(n / 2, d1, d2, c11);

                    ToHop(n, a, c00, c01, c10, c11);
                }
            }
        }
    }
}
