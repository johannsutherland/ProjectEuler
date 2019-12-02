using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    public static class TriangleNumbers
    {
        public static int GenerateN(int n)
        {
            // Tn=n(n+1)/2
            return n * (n + 1) / 2;
        }

        public static IEnumerable<int> GenerateN(int start, int end)
        {
            for (int n = start; n <= end; n++)
            {
                yield return GenerateN(n);
            }
        }

        public static bool IsTriangleNumber(int number)
        {
            // Tn=n(n+1)/2
            // 2Tn=n(n+1)
            // 2Tn/n=n+1
            // 2Tn/n - 1 = n
            // 2Tn - n = n^2
            // n^2 + n - 2Tn = 0
            // using quadratic formula:
            // n = (-1 + sqrt(1 - 4.(-2Tn))) / 2
            // n = (-1 + sqrt(1 + 8Tn)) / 2
            return (-1 + Math.Sqrt(1 + (8 * (double)number))) % 2 == 0;
        }
    }
}
