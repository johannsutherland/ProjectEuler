using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem27
{
    class Program
    {
        static void Main(string[] args)
        {
            Primes p = new Primes();
            int max = 0;

            for (int a = -1000; a <= 1000; a++)
            {
                for (int b = -1000; b <= 1000; b++)
                {
                    QuadricPolynominal qp = new QuadricPolynominal(a, b, p);
                    int length = qp.FindLength();
                    if (length > max)
                    {
                        max = length;
                        Console.WriteLine("n2 + {0}n + {1}, length = {2}, product of coefficients = {3}", a, b, length, a * b);
                    }
                }
            }

            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }

    public class QuadricPolynominal
    {
        private int a;
        private int b;
        private Primes primes;

        public QuadricPolynominal(int a, int b, Primes primes)
        {
            this.a = a;
            this.b = b;
            this.primes = primes;
        }

        public double Solve(int n)
        {
            return Math.Pow(n, 2) + this.a * n + this.b;
        }

        public int FindLength()
        {
            bool allPrime = true;
            int length = 0;

            while (allPrime)
            {
                double answer = this.Solve(length);
                allPrime = allPrime && primes.IsPrime(answer);
                if (!allPrime)
                {
                    break;
                }
                length++;

                if (length % 100 == 0)
                    Console.ReadKey();
            }
            return length;
        }
    }

    public class Primes
    {
        public List<double> ExistingPrimes;

        public Primes()
        {
            ExistingPrimes = new List<double>();
        }

        public bool IsPrime(double candidate)
        {
            if (candidate <= 1)
                return false;

            if (ExistingPrimes.Contains(candidate))
                return true;

            double testingUpperLimit = Math.Round(Math.Sqrt(candidate));

            bool isPrime = true;
            foreach (double prime in ExistingPrimes)
            {
                if (prime > testingUpperLimit)
                    break;

                if (candidate % prime == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                for (double i = 2; i <= testingUpperLimit; i++)
                {
                    if (candidate % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            if (isPrime) ExistingPrimes.Add(candidate);

            return isPrime;
        }
    }
}
