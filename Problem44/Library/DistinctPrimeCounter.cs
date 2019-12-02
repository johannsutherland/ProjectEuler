using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class DistinctPrimeCounter
    {
        Primes primes = new Primes();

        public long GetFirstNumbersWithNDistinctPrimes(int n)
        {
            long number = 1;
            while (true)
            {
                bool found = true;
                for (int i = 0; i < n; i++)
                {
                    found = found && (primes.GetPrimeFactors(number + i) == n);
                    if (!found)
                    {
                        number = number + i + 1;
                        break;
                    }
                }
                if (found)
                {
                    return number;
                }
            }
        }
    }
}
