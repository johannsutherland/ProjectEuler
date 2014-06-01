using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem37
{
    public class Program
    {
        static void Main(string[] args)
        {
            Primes p = new Primes();

            List<int> foundPrimes = new List<int>();
            List<int> digits = Enumerable.Range(1, 9).ToList();

            List<int> thisGeneration = new List<int> { 2, 3, 5, 7 };
            List<int> nextGeneration = new List<int>();

            while (foundPrimes.Count() < 11)
            {
                foreach (int number in thisGeneration)
                {
                    foreach (int numberWithDigit in AddDigit(number, digits, Side.Left))
                    {
                        if (p.isPrime(numberWithDigit))
                        {
                            nextGeneration.Add(numberWithDigit);

                            bool isPrime = true;
                            foreach (int numberWithoutDigit in RemoveDigit(numberWithDigit, Side.Right))
                            {
                                isPrime = isPrime && p.isPrime(numberWithoutDigit);

                                if (!isPrime)
                                {
                                    break;
                                }
                            }

                            if (isPrime)
                            {
                                foundPrimes.Add(numberWithDigit);
                            }
                        }
                    }
                }

                thisGeneration.Clear();
                thisGeneration.AddRange(nextGeneration);
                nextGeneration.Clear();
            }

            foundPrimes.Sort();
            foreach (long number in foundPrimes)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("Total: {0}", foundPrimes.Sum());
            
            Console.ReadKey();
        }

        public enum Side { Left, Right }

        public static IEnumerable<long> AddDigit(int number, List<int> digits, Side side)
        {
            foreach (int digit in digits)
            {
                if (side == Side.Right)
                    yield return number * 10 + digit;
                else
                    yield return digit * (int)Math.Pow(10, 1 + Math.Floor(Math.Log10(number))) + number;
            }
        }

        public static IEnumerable<int> RemoveDigit(int numberToRemove, Side side)
        {
            int number = numberToRemove;
            while (number > 10)
            {
                if (side == Side.Right)
                {
                    int digit = number % 10;
                    number /= 10;
                    yield return number;
                }
                else
                {
                    int divider = (int)Math.Pow(10, Math.Floor(Math.Log10(number)));
                    int digit = (int)Math.Floor((double)(number / divider));
                    number %= divider;
                    yield return number;
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
