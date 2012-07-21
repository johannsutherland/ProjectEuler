using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem10
{
    class Program
    {
        static void Main(string[] args)
        {
            long upperLimit = 2000000;
            PrimeFactorGenerator primeFactorGenerator = new PrimeFactorGenerator();
            primeFactorGenerator.GetPrimesBelow(upperLimit);
            Console.WriteLine(primeFactorGenerator.PrimeFactors.Sum());
            Console.ReadKey();
        }

        class PrimeFactorGenerator
        {
            public List<long> PrimeFactors = new List<long>();

            public PrimeFactorGenerator()
            {
            }

            public void GetPrimeFactors(int product)
            {
                for (int i = 2; i < product; i++)
                {
                    this.isPrime(i);
                }
            }

            public void GetPrimesBelow(long upperLimit)
            {
                for (int i = 0; i <= upperLimit; i++)
                {
                    this.isPrime(i);
                }
            }

            public bool isPrime(long candidate)
            {
                if (candidate <= 1)
                    return false;

                bool isPrime = true;
                long testingUpperLimit = (long)Math.Round(Math.Sqrt(candidate));

                foreach (long prime in PrimeFactors)
                {
                    if (prime > testingUpperLimit)
                        break;

                    if (candidate % prime == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) PrimeFactors.Add(candidate);

                return isPrime;
            }
        }
    }
}
