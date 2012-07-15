using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem3
{
    class Program
    {
        static void Main(string[] args)
        {
            Primes p = new Primes();
            long upperlimit = 600851475143;
            long testUpperLimit = (long)(Math.Round(Math.Sqrt(upperlimit)));
            long largestPrime = 0;

            for (long i = 0; i < testUpperLimit; i++)
            {
                if ((p.isPrime(i)) && (upperlimit % i == 0))
                    largestPrime = i;
            }
            Console.WriteLine(largestPrime);
            Console.ReadKey();
        }

        class Primes
        {
            List<long> primes;

            public Primes()
            {
                primes = new List<long>();
            }

            public bool isPrime(long candidate)
            {
                if (candidate <= 1)
                    return false;

                bool isPrime = true;
                long testingUpperLimit = (long)Math.Round(Math.Sqrt(candidate));

                foreach (long prime in primes)
                {
                    if (prime > testingUpperLimit)
                        break;

                    if (candidate % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) primes.Add(candidate);

                return isPrime;
            }
        }
    }
}
