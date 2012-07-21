using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem9
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 1000;
            PrimeFactorGenerator primeFactoryGenerator = new PrimeFactorGenerator(sum / 2);

            foreach (int primeFactor in primeFactoryGenerator.PrimeFactors)
            {
                bool done = false;
                int constant = 1;
                while (primeFactor * constant < sum / 2)
                {
                    int m = primeFactor * constant++;
                    int n = ((sum / 2) / m) - m;

                    if ((n > m) || (n < 0))
                        continue;

                    int a = (int)(Math.Pow(m, 2) - Math.Pow(n, 2));
                    int b = 2 * m * n;
                    int c = (int)(Math.Pow(m, 2) + Math.Pow(n, 2));

                    if ((Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2)) && (a + b + c == sum))
                    {
                        Console.WriteLine(a.ToString() + "," + b.ToString() + "," + c.ToString());
                        Console.WriteLine(m.ToString() + "," + n.ToString());
                        Console.WriteLine((a * b * c).ToString());

                        done = true;
                    }
                }
                if (done)
                    break;
            }
            Console.ReadKey();
        }
    }

    class PrimeFactorGenerator
    {
        public List<long> PrimeFactors = new List<long>();

        public PrimeFactorGenerator()
        {
        }

        public PrimeFactorGenerator(int product)
        {
            for (int i = 2; i < product; i++)
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
