using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    public class Primes
    {
        private SortedSet<long> existingPrimes = new SortedSet<long>();
        private SortedDictionary<long, int> existingPrimeFactors = new SortedDictionary<long, int>();
        private long currentMaximum = 1;

        public Primes(int maximumNumber = 0)
        {
            IsPrime(maximumNumber);
        }

        public int GetPrimeFactors(long product)
        {
            if (existingPrimeFactors.ContainsKey(product))
                return existingPrimeFactors[product];

            List<long> primeFactors = new List<long>();

            int i = 2;
            long factorisedProduct = product;
            while (factorisedProduct > 1 || i < factorisedProduct / 2)
            {
                if (factorisedProduct % i == 0)
                {
                    factorisedProduct = factorisedProduct / i;
                    if (!primeFactors.Contains(i)) primeFactors.Add(i);
                }
                else
                {
                    i++;
                }
            }

            existingPrimeFactors.Add(product, primeFactors.Count);
            return primeFactors.Count;
        }

        public List<long> GetPrimes(long product)
        {
            List<long> primeFactors = new List<long>();

            for (long i = 2; i < product; i++)
            {
                if (this.IsPrime(i))
                    primeFactors.Add(i);
            }

            return primeFactors;
        }

        public bool IsPrime(long candidate)
        {
            if (candidate <= 1)
            {
                return false;
            }

            if (currentMaximum >= candidate)
            {
                return existingPrimes.Contains(candidate);
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

            foreach (long prime in existingPrimes)
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
                existingPrimes.Add(candidate);
            }

            return isPrime;
        }
    }
}
