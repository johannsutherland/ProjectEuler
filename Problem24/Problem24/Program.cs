using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem24
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            foreach (string digit in CalculatePermutations(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }))
            {
                i++;
                if (i % 1000 == 0)
                    Console.WriteLine(i);

                if (i == 1000000)
                {
                    Console.WriteLine(digit);
                    break;
                }
            }
            Console.WriteLine("Done.");
            Console.ReadKey();
        }

        static IEnumerable<string> CalculatePermutations(List<int> digits)
        {
            digits.Sort();
            if (digits.Count() == 0)
                yield return "";

            foreach (int digit in digits)
            {
                List<int> remainingDigits = digits.Where(x => x != digit).ToList();
                string result = digit.ToString();
                foreach (string otherDigits in CalculatePermutations(remainingDigits))
                {
                    yield return result + otherDigits;
                }
            }
        }
    }
}
