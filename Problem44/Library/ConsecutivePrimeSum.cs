using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class ConsecutivePrimeSum
    {
        Primes primes = new Primes();

        public long FindConsecutivePrimeSumPrime(int maximum)
        {
            // Get all the primes below the maximum
            var primes = this.primes.GetPrimes(maximum).OrderBy(x => x).ToArray();

            // Build an array which holds the cummulative sum of the primes
            // e.g. primeSum[4] is the cummulative sum of the first 4 primes (2+3+5+7 = 17) 
            var primeSum = new long[primes.Length + 1];
            primeSum[0] = 0;
            for (int i = 1; i < primeSum.Length; i++)
            {
                primeSum[i] = primeSum[i - 1] + primes[i - 1]; 
            }

            // Keep track of the longest sequence found so far
            int longestSequence = 0;
            long longestSequnceValue = 0;

            // Finding a sequence when it starts from 2 is now easy, 
            // just find a prime in the primesum array
            // But we need to find it when it start somewhere else
            // This can be done by substracting the two arrays from each other, because:
            // p[4] - p[3] = 17 - 5 = 12
            // which is also the cummulative sum of p[3] + p[4] = 5 + 7 = 12
            // To do that, we have two loops:
            // i = run across the complete primeSum array
            for (int i = 0; i < primeSum.Length; i++)
            {
                // j = run from i backwards to 0, this is what will be subtracted from the i loop
                // remember that we set primesum[0] to 0, so we have sequences starting from 2 as well
                for (int j = i; j >= 0; j--)
                {
                    // break if the difference is more than the maximum as there is no point checking it
                    // further
                    if (primeSum[i] - primeSum[j] >= maximum) break;

                    // is there a prime that is equal to the difference between the two primesums?
                    var index = Array.BinarySearch(primes, primeSum[i] - primeSum[j]);
                    if (index > -1)
                    {
                        if (i - j > longestSequence)
                        {
                            longestSequence = i - j;
                            longestSequnceValue = primeSum[i] - primeSum[j];
                        }
                    }
                }
            }

            return longestSequnceValue;
        }
    }
}
