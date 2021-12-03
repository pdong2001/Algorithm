using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    public static class Practice_IV
    {
        static void LCS1(string X, string Y, out int[,] c, out int[,] b)
        {
            int m = X.Length, n = Y.Length, i, j;
            c = new int[m + 1, n + 1];
            b = new int[m + 1, n + 1];
            for (i = 0; i <= m; i++) c[i, 0] = 0;
            for (j = 0; i <= n; i++) c[0, j] = 0;
            for (i = 1; i <= m; i++)
            {
                for (j = 1; j <= n; j++)
                {
                    if (X[i - 1] == Y[j - 1])
                    {
                        c[i, j] = c[i - 1, j - 1] + 1;
                        b[i, j] = 0;
                    }
                    else
                    {
                        c[i, j] = Math.Max(c[i, j - 1], c[i - 1, j]);
                        if (c[i, j] == c[i, j - 1])
                            b[i, j] = 1;
                        else
                            b[i, j] = -1;
                    }
                    //Console.Write(c[i, j] + "," + b[i, j] + "\t");
                }
                //Console.WriteLine();
            }
            Console.WriteLine($"{c[m,n]}");
        }

        static void Show_LCS(string X, string Y, int[,] b)
        {
            int i, j; i = X.Length; j = Y.Length;
            while (!(i == 0 || j == 0))
            {
                if (b[i, j] == 0)
                {
                    Console.Write(X[i - 1]);
                    i--; j--;
                }
                else if (b[i, j] == 1)
                {
                    j--;
                }
                else i--;
            }
        }

        static int LCS_Chiatri(string X, string Y, int i, int j)
        {
            if (i == 0 || j == 0) return 0;
            else
            if (X[i - 1] == Y[j - 1])
            {
                //b[i, j] = 0; 
                return LCS_Chiatri(X, Y, i - 1, j - 1) + 1;
            }
            else
            {
                int a = Math.Max(LCS_Chiatri(X, Y, i, j - 1), LCS_Chiatri(X, Y, i - 1, j));
                //if (a == LCS(X, Y, i, j - 1))
                // b[i,j]=1;
                //else
                // b[i, j] = -1;
                return a;
            }
        }

        public static void TestLCS(int n)
        {
            string A = Common.RandomString(n).ToUpper();
            string B = Common.RandomString(n).ToUpper();
            //string B = string.Concat(A.Reverse());
            Console.WriteLine(A);
            Console.WriteLine(B);
            Common.Monitoring(() =>
            {
                Console.WriteLine("Quy hoạch động : ");
                int m = A.Length, n = B.Length;
                int[,] c;
                int[,] b;
                LCS1(A, B, out c, out b);
                Show_LCS(A, B, b);
                Console.WriteLine();
            });
            Common.Monitoring(() =>
            {
                Console.WriteLine("Đệ quy : ");
                var rs = LCS_Chiatri(A, B, A.Length, B.Length);
                Console.WriteLine(rs);
            });
        }
    }
}

