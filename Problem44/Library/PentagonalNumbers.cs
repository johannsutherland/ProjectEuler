using System;
using System.Collections.Generic;

namespace ProjectEuler
{
    public static class PentagonalNumbers
    {
        public static int GenerateN(int n)
        {
            // Pn=n(3n−1)/2
            return n * ((3 * n) - 1) / 2;
        }

        public static IEnumerable<int> GenerateN(int start, int end)
        {
            for (int n = start; n <= end; n++)
            {
                yield return GenerateN(n);
            }
        }

        public static bool IsPentagonalNumber(int number)
        {
            // Pn=n(3n-1)/2
            // 2Pn=n(3n-1)
            // 2Pn/n=3n-1
            // 2Pn/n + 1 = 3n
            // 2Pn + n = 3n^2
            // 3n^2 - n - 2Pn = 0
            // using quadratic formula:
            // n = (1 + sqrt(1 - 4.3.(-2Pn))) / 2.3
            // n = (1 + sqrt(1 + 24Pn)) / 6
            return (1 + Math.Sqrt(1 + (24 * (double)number))) % 6 == 0;
        }

        public static int FindPentagonalPairs()
        {
            for (int j = 2; j < 10000000; j++)
            {
                for (int i = 1; i < j; i++)
                {
                    var Pi = GenerateN(i);
                    var Pj = GenerateN(j);

                    if (IsPentagonalNumber(Pj - Pi) && IsPentagonalNumber(Pj + Pi))
                    {
                        Console.WriteLine($"Found at {i} and {j}: Pi: {Pi} and Pj: {Pj}");
                        return Pj - Pi;
                    }
                }
            }

            throw new Exception("Can't find pair.");
        }
    }
}
