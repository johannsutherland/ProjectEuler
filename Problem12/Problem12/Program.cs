using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem12
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeFactorGenerator pfg = new PrimeFactorGenerator();
            int i = 1;
            int mostDivisorsSoFar = 0;
            while (true)
            {
                long triangleNumber = GetTriangleNumber(i++);
                pfg.CalculatePrimesLowerThan(triangleNumber);

                long divisionResult = triangleNumber;
                int divisors = 1;

                foreach (long primeFactor in pfg.PrimeNumbers)
                {
                    int exponent = 0;

                    while (divisionResult % primeFactor == 0)
                    {
                        exponent++;
                        divisionResult /= primeFactor;
                    }

                    divisors *= (exponent + 1);
                }

                if (divisors > mostDivisorsSoFar)
                    {
                        mostDivisorsSoFar = divisors;
                        Console.WriteLine(triangleNumber.ToString() + ":" + divisors.ToString());
                    }

                if (divisors > 500)
                    break;
            }
            Console.ReadKey();
        }

        static long GetTriangleNumber(int sequence)
        {
            return sequence * (sequence + 1) / 2;
        }
    }

    class PrimeFactorGenerator
    {
        public List<long> PrimeNumbers = new List<long>();
        private long lastHighestValue;

        public List<long> GetPrimeFactors(long product)
        {
            List<long> primeFactors = new List<long>();

            for (long i = 2; i < product; i++)
            {
                if (this.IsPrime(i)&&(product % i == 0))
                    primeFactors.Add(i);
            }

            return primeFactors;
        }

        public void CalculatePrimesLowerThan(long upperLimit)
        {
            if (lastHighestValue > upperLimit)
                return;

            for (long i = lastHighestValue; i < upperLimit; i++)
            {
                this.IsPrime(i);
            }
            lastHighestValue = upperLimit;
        }

        public bool IsPrime(long candidate)
        {
            if (candidate <= 1)
                return false;

            bool isPrime = true;
            long testingUpperLimit = (long)Math.Round(Math.Sqrt(candidate));

            foreach (long prime in PrimeNumbers)
            {
                if (prime > testingUpperLimit)
                    break;

                if (candidate % prime == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) PrimeNumbers.Add(candidate);

            return isPrime;
        }
    }

}
