using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    public static class Practice_I
    {
        public static class Example_I
        {
            public static double ForLoop(int[] Arr, int x)
            {
                double p = 0;
                for (int i = 0; i < Arr.Length; i++)
                {
                    p += Arr[i] * Math.Pow(x, Arr.Length - i);
                }
                return p;
            }

            public static double UpgradeLoop(int[] Arr, int x)
            {
                double p = 0;
                double tg = 1;
                for (int i = 0; i < Arr.Length; i++)
                {
                    tg = tg * x;
                    p += Arr[i] * tg;
                }
                return p;
            }

            public static double Hoocne(int[] Arr, int x)
            {
                double p = Arr[Arr.Length - 1];
                for (int i = 0; i < Arr.Length; i++)
                {
                    p = p * x + Arr[i];
                }
                return p;
            }
        }

        public static class I
        {
            public static double AlgorithmI(int n, double x)
            {
                double s = 1;
                for (int i = 1; i <= n; i++)
                {
                    s += Math.Pow(x, i) / Common.Factorial(i);
                }
                return s;
            }

            public static double AlgorithmII(int n, double x)
            {
                double s = 1, p;
                for (int i = 1; i <= n; i++)
                {
                    p = 1;
                    for (int j = 1; j <= i; j++)
                    {
                        p = p * x / j;
                    }
                    s = s + p;
                }
                return s;
            }

            public static double AlgorithmIII(int n, double x)
            {
                double s = 1, p = 1;
                for (int i = 1; i <= n; i++)
                {
                    p = p * x / i;
                    s = s + p;
                }
                return s;
            }
        }

        public static class II
        {
            public static int[] AlgorithmI(int[] arr, int k)
            {
                int[] tg = new int[k];
                int[] tmp = new int[arr.Length - k];
                for (int i = 0; i < arr.Length; i++)
                {
                    if (i < k)
                    {
                        tg[i] = arr[i];
                    }
                    else
                    {
                        tmp[i - k] = arr[i];
                    }
                }

                tmp.CopyTo(arr, 0);
                tg.CopyTo(arr, arr.Length - k);

                return arr;
            }

            public static int[] AlgorithmII(int[] arr, int k)
            {
                LinkedList<int> temp = new LinkedList<int>(arr);

                for (int i = 0; i < k; i++)
                {
                    temp.AddLast(temp.First());
                    temp.RemoveFirst();
                }

                return temp.ToArray();
            }

            public static int[] AlgorithmIII(int[] arr, int k)
            {
                var tg = arr.Take(k);
                var tmp = arr.Skip(k);

                tmp.ToArray().CopyTo(arr, 0);
                tg.ToArray().CopyTo(arr, arr.Length - k);

                return arr;
            }
        }
    }
}
