using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Run
{
    public static class Dynamic
    {
        public static ulong FibonaciRecursive(int n)
        {
            if (n < 2)
            {
                return (ulong)n;
            }
            else
            {
                return FibonaciRecursive(n - 1) + FibonaciRecursive(n - 2);
            }
        }

        public static ulong FibonaciDynamic(int n)
        {
            ulong[] f = new ulong[n < 2 ? 2 : n + 1];
            f[0] = 0;
            f[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                f[i] = f[i - 1] + f[i - 2];
            }
            return f[n];
        }
    }
}
