using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem34
{
    class Program
    {
        public const int UpperBound = 2540160;

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Factorial f = new Factorial();
            long sum = 0;

            for (int n = 3; n < UpperBound; n++)
            {
                long total = 0;
                long remainder = n;
                while (remainder > 0)
                {
                    long digit = remainder % 10;
                    total += f.CalculateFactorial(digit);
                    remainder /= 10;
                }

                if (total == n)
                {
                    sum += total;
                    Console.WriteLine("Found {0}", n);
                }
            }

            sw.Stop();

            Console.WriteLine("Sum {0} in {1}", sum, sw.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }

    public class DigitsManager
    {
        public static IEnumerable<int> GetDigits(int n)
        {
            int remainder = n;
            while (remainder > 0)
            {
                yield return remainder % 10;
                remainder /= 10;
            }
        }
    }

    public class Factorial
    {
        long[] cache;

        public Factorial()
        {
            cache = new long[Problem34.Program.UpperBound];
        }

        public long CalculateFactorial(long n)
        {
            if (n <= 1)
                return 1;

            if (cache[n] != 0) return cache[n];

            if (n < 1)
                throw new Exception("Expecting n > 0");

            long factorial = 1;

            for (long i = n; i > 1; i--)
            {
                factorial *= i;
            }

            cache[n] = factorial;
            return factorial;
        }
    }
}
