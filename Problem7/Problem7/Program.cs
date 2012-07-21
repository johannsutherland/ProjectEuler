using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem7
{
    class Program
    {
        static void Main(string[] args)
        {
            Primes p = new Primes();
            long candidate = 0;
            while (true)
            {
                p.isPrime(candidate++);
                if (p.ExistingPrimes.Count == 10001)
                    break;
            }
            Console.WriteLine(p.ExistingPrimes.Max());
            Console.ReadKey();
        }
    }

    class Primes
    {
        public List<long> ExistingPrimes;

        public Primes()
        {
            ExistingPrimes = new List<long>();
        }

        public bool isPrime(long candidate)
        {
            if (candidate <= 1)
                return false;

            bool isPrime = true;
            long testingUpperLimit = (long)Math.Round(Math.Sqrt(candidate));

            foreach (long prime in ExistingPrimes)
            {
                if (prime > testingUpperLimit)
                    break;

                if (candidate % prime == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) ExistingPrimes.Add(candidate);

            return isPrime;
        }
    }
}
