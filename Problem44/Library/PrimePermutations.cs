using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class PrimePermutations
    {
        Primes primes = new Primes();

        /// <summary>
        /// Find the three terms where:
        /// a) each of them are prime
        /// b) they are permutations of each
        /// c) they are equidistance from each other
        /// </summary>
        /// <param name="numberOfDigits"></param>
        /// <returns></returns>

        public List<int> GetPrimePermutation(int numberOfDigits)
        {
            int start = (int)Math.Pow(10, numberOfDigits - 1);
            int end = (int)Math.Pow(10, numberOfDigits) - 1;
            var result = new List<int>();
            var primesToCheck = primes.GetPrimes(end).OrderByDescending(x => x).Select(x => (int)x).ToList();

            // find the first term
            foreach (var i in primesToCheck)
            {
                // get its permutations
                var permutations = GetPermutations(i)
                    // We only need permutations smaller than the current term (as we are going backwards)
                    // AND permutations that have the same number of digits (i.e. none starting with 0)
                    .Where(x => x < i &&  x > start)
                    .ToList();

                foreach(var permutation in permutations)
                {
                    // if there is another term that is prime, lets see if there is another one with the same difference
                    if (primes.IsPrime(permutation))
                    {
                        var difference = i - permutation;
                        var candidate = permutation - difference;
                        if (primes.IsPrime(candidate) && permutations.Contains(candidate))
                        {
                            result.AddRange(new List<int>() { candidate, permutation, i }.OrderBy(x => x));
                        }
                    }
                }
            }

            return result;
        }

        public List<int> GetPermutations(int number)
        {
            return GetPermutations(number.ToString())
                .Select(x => int.Parse(x))
                .Distinct()
                .OrderBy(x => x)
                .ToList();
        }

        private List<string> GetPermutations(string number, string numberSoFar = "")
        {
            if (number.Length == 1)
            {
                return new List<string>() { numberSoFar + number };
            }

            var result = new List<string>();

            for (int i = 0; i < number.Length; i++)
            {
                result.AddRange(GetPermutations(number.Substring(0, i) + number.Substring(i+1), numberSoFar + number[i]));
            }

            return result;
        }
    }
}
