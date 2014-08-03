using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem41
{
    class Program
    {
        static void Main(string[] args)
        {
            Primes p = new Primes();
            foreach (string s in Pandigital.GeneratePandigital(Enumerable.Range(1, 7).Reverse().ToImmutableList()))
            {
                if (p.isPrime(int.Parse(s)))
                {
                    Console.WriteLine(s);
                    break;
                }
            }
            Console.ReadKey();
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

    class Primes
    {
        public SortedSet<long> ExistingPrimes = new SortedSet<long>();

        private long currentMaximum = 1;

        public Primes(int maximumNumber = 0)
        {
            isPrime(maximumNumber);
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

            for (long tempCandidate = currentMaximum + 1; tempCandidate < candidate; tempCandidate++)
            {
                CheckPrime(tempCandidate);
            }

            return CheckPrime(candidate);
        }

        private bool CheckPrime(long candidate)
        {
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
