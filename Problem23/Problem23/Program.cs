using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem23
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            int total = 0;

            FindAbundantNumbers fan = new FindAbundantNumbers();
            fan.FindAllAbundantNumbers();

            int[] abudantNumbers = fan.AbundantNumbers.ToArray<int>();
            bool[] canSumAbudantNumbers = new bool[FindAbundantNumbers.UpperLimit + 1];

            for (int pos = 0; pos < abudantNumbers.Length; pos++)
            {
                for (int pos2 = pos; pos2 < abudantNumbers.Length; pos2++)
                {
                    int s1 = abudantNumbers[pos];
                    int s2 = abudantNumbers[pos2];

                    if (s1 + s2 > FindAbundantNumbers.UpperLimit)
                        break;

                    canSumAbudantNumbers[s1 + s2] = true;
                }
            }

            for (int i = 0; i < canSumAbudantNumbers.Length; i++)
            {
                if (!canSumAbudantNumbers[i])
                    total += i;
            }
            
            sw.Stop();

            Console.WriteLine(total);
            Console.WriteLine(sw.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }
    }

    class FindAbundantNumbers
    {
        public const int UpperLimit = 28123;

        public List<int> AbundantNumbers = new List<int>();

        public Dictionary<int, List<int>> Divisors = new Dictionary<int, List<int>>();

        public List<int> FindDivisors(int number)
        {
            if (Divisors.ContainsKey(number))
                return Divisors[number];

            List<int> divisors = new List<int>();

            // Start from square root
            for (int i = (int)Math.Sqrt(number); i > 1; i--)
                if (number % i == 0)
                {
                    divisors.Add(i);
                    // As we start from the sqrt, we have to also include the "bigger" divisor
                    if (i != number / i)
                        divisors.Add(number / i);
                }

            // 1 is always a divisor
            divisors.Add(1);

            // Just for presentation
            divisors.Sort();

            Divisors.Add(number, divisors);

            return divisors;
        }

        public void FindAllAbundantNumbers()
        {
            foreach (int number in Enumerable.Range(1, UpperLimit))
            {
                int sum = this.FindDivisors(number).Sum();
                if (sum > number)
                    AbundantNumbers.Add(number);
            }
        }
    }
}
