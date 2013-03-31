using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Project21
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperLimit = 100000;
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            FindAmicableNumbers fan = new FindAmicableNumbers(upperLimit);
            fan.FindDivisorsFrom(1);

            int sum = 0;
            for (int i = 1; i < upperLimit; i++)
            {
                int? amicableNumber = fan.FindAmicableNumber(i);

                if (amicableNumber.HasValue)
                {
                    if (amicableNumber.Value > upperLimit)
                        break;

                    sum += i + amicableNumber.Value;
                }
            }
            stopWatch.Stop();

            Console.WriteLine(sum);
            Console.WriteLine("Took " + stopWatch.ElapsedMilliseconds + "ms.");

            Console.ReadKey();
        }
    }

    class FindAmicableNumbers
    {
        private Dictionary<int, List<int>> previousDivisors = new Dictionary<int, List<int>>();
        private int upperLimit;
        public Dictionary<int, int> DivisorSums = new Dictionary<int, int>();

        public FindAmicableNumbers(int upperLimit)
        {
            this.upperLimit = upperLimit;
        }

        public void FindDivisorsFrom(int start = 1)
        {
            foreach (int i in Enumerable.Range(start, upperLimit))
                this.FindDivisors(i);
        }

        public List<int> FindDivisors(int number)
        {
            if (previousDivisors.ContainsKey(number))
                return previousDivisors[number];

            List<int> divisors = new List<int>();

            // Start from square root
            for (int i = (int)Math.Sqrt(number); i > 1; i--)
                if (number % i == 0)
                {
                    divisors.Add(i);
                    // As we start from the sqrt, we have to also include the "bigger" divisor
                    divisors.Add(number / i);
                }

            // 1 is always a divisor
            divisors.Add(1);

            // Just for presentation
            divisors.Sort();

            previousDivisors.Add(number, divisors);
            DivisorSums.Add(number, divisors.Sum());

            return divisors;
        }

        public int? FindAmicableNumber(int i)
        {
            if (this.DivisorSums.Count == 0)
                this.FindDivisorsFrom();

            int sumOfDivisors = this.DivisorSums[i];
            int? amicableNumber = null;

            if ((sumOfDivisors > 1) && (sumOfDivisors < upperLimit) // Within the boundaries
                && (i == this.DivisorSums[sumOfDivisors]) // Has an amicable number
                && (sumOfDivisors > this.DivisorSums[sumOfDivisors])) // Don't count duplicates

                amicableNumber = sumOfDivisors;

            return amicableNumber;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (int i in previousDivisors.Keys)
            {
                sb.Append(i.ToString() + ": ");
                previousDivisors[i].ForEach(x => sb.Append(x.ToString() + ", "));
            }
            return sb.ToString();
        }
    }
}
