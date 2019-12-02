using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    public static class HexagonalNumbers
    {
        public static int GenerateN(int n)
        {
            // Hn=n(2n-1)
            return n * (2 * n - 1);
        }

        public static IEnumerable<int> GenerateN(int start, int end)
        {
            for (int n = start; n <= end; n++)
            {
                yield return GenerateN(n);
            }
        }

        public static bool IsHexagonalNumber(int number)
        {
            // Hn=n(2n-1)
            // Hn=2n^2-n
            // 0=2n^2-n-Hn
            // using quadratic formula:
            // n = (1 + sqrt(1 - 4.2(-Hn))) / 2.2
            // n = (1 + sqrt(1 + 8Hn)) / 4
            return (1 + Math.Sqrt(1 + (8 * (double)number))) % 4 == 0;
        }

        public static int FindCorrespondingPentagonalNumber()
        {
            int startIndex = 145;

            while (true)
            {
                var number = HexagonalNumbers.GenerateN(startIndex);
                if (PentagonalNumbers.IsPentagonalNumber(number)) return number;
                // Ever odd hexagonal number is a triangle number, so only check those
                startIndex = startIndex + 2;
            }
        }

    }
}
