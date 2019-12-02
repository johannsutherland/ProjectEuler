using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler
{
    public class GoldbachsOtherConjecture
    {
        // GoldbachsOtherConjecture: every odd composite number can be written 
        // as the sum of a prime and twice a square.

        Primes primes;

        public GoldbachsOtherConjecture()
        {
            primes = new Primes();
        }

        public bool HoldsFor(long composite)
        {
            var candidatePrimes = primes.GetPrimes(composite);
            foreach (long candidateFrame in candidatePrimes)
            {
                if (Math.Sqrt((composite - candidateFrame) / 2) % 1 == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public long FindFirstFalse()
        {
            long number = 1;
            while (true)
            {
                // conjecture is only for odd numbers
                number = number + 2;
                // and composite numbers
                if (!primes.IsPrime(number))
                {
                    if (!this.HoldsFor(number))
                    {
                        return number;
                    }
                }
            }
        }
    }
}
