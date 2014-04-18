using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Problem35
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            Primes p = new Primes();
            int max = 1000000;
            int numberOfCircularPrimes = 0;

            for (int i = 0; i < max; i++)
            {
                p.isPrime(i);
            }

            foreach (long prime in p.ExistingPrimes)
            {
                bool allRotationArePrime = true;

                foreach (long rotation in GetRotations(prime))
                {
                    if (!p.isPrime(rotation))
                    {
                        allRotationArePrime = false;
                        break;
                    }
                }

                if (allRotationArePrime)
                {
                    numberOfCircularPrimes++;
                }
            }

            sw.Stop();

            Console.WriteLine("Done, there are {0} in {1}ms.", numberOfCircularPrimes, sw.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static IEnumerable<long> GetRotations(long num)
        {
            string number = num.ToString();
            for (int i = 0; i < number.Length; i++)
            {
                yield return long.Parse(number.Remove(0, i) + number.Substring(0, i));
            }
        }
    }

    class Primes
    {
        public SortedSet<long> ExistingPrimes;

        private long currentMaximum = 0;

        public Primes()
        {
            ExistingPrimes = new SortedSet<long>();
        }

        public bool isPrime(long candidate)
        {
            if (candidate <= 1)
            {
                return false;
            }

            if (currentMaximum >= candidate)
            {
                return ExistingPrimes.Contains(candidate);
            }

            bool isPrime = true;
            long testingUpperLimit = (long)Math.Round(Math.Sqrt(candidate));

            foreach (long prime in ExistingPrimes)
            {
                if (prime > testingUpperLimit)
                {
                    break;
                }

                if (candidate % prime == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (currentMaximum < candidate)
            {
                currentMaximum = candidate;
            }

            if (isPrime)
            {
                ExistingPrimes.Add(candidate);
            }

            return isPrime;
        }
    }
}
