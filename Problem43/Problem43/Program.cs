using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Problem43
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("Find all pandigital numbers");

            long total = 0;

            foreach (string s in Pandigital.GeneratePandigital(Enumerable.Range(0, 10).Reverse().ToImmutableList()))
            {
                if (s[0] == 0)
                    continue;

                int[] divisors = { 2, 3, 5, 7, 11, 13, 17 };
                bool divisable = true;

                for (int i = 2; i <= 8; i++)
                {
                    divisable = divisable && CreatePartialNumber(s, i, 3) % divisors[i - 2] == 0;
                    if (!divisable) break;
                }

                if (divisable)
                {
                    Console.WriteLine(s);
                    total += long.Parse(s);
                }
            }

            Console.WriteLine($"Total: {total}");
        }

        static int CreatePartialNumber(string s, int firstDigit, int length)
        {
            return int.Parse(s.Substring(firstDigit - 1, length));
        }
    }

    class Pandigital
    {
        public static IEnumerable<string> GeneratePandigital(ImmutableList<int> available)
        {
            foreach (int digit in available)
            {
                if (available.Count > 1)
                {
                    foreach (string s in GeneratePandigital(available.Remove(digit)))
                    {
                        yield return digit.ToString() + s;
                    }
                }
                else
                {
                    yield return digit.ToString();
                }
            }
        }
    }
}
