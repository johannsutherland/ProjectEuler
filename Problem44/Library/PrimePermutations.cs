using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public class PrimePermutations
    {
        Primes primes = new Primes();

        public List<int> GetPrimePermutation(int numberOfDigits)
        {
            int start = (int)Math.Pow(10, numberOfDigits - 1);
            int end = (int)Math.Pow(10, numberOfDigits) - 1;
            var result = new List<int>();

            for (int i = end; i >= start; i--)
            {
                if (primes.IsPrime(i))
                {
                    var permutations = GetPermutations(i)
                        .Where(x => x < i &&  x > start)
                        .ToList();

                    foreach(var permutation in permutations)
                    {
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
