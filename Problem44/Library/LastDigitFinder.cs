using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    public static class LastDigitFinder
    {
        public static long GetLastDigits(int start, int end, int numberOfDigits)
        {
            long result = 0;
            long modulus = (long)Math.Pow(10, numberOfDigits);

            for (int i = start; i <= end; i++)
            {
                long power = i;
                // Calculate the last digits of the power
                // (a * b) % c = ((a % c) * (b % c)) % c
                for (int j = 1; j < i; j++)
                {
                    power = ((power % modulus) * (i % modulus)) % modulus;
                }
                // Calculate the last digits of the sum
                // (a + b) % c = ((a % c) + (b % c)) % c
                result = ((result % modulus) + (power % modulus)) % modulus;
            }

            return result;
        }
    }
}
