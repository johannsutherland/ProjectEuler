using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem30
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            double max = 6 * Math.Pow(9, 5);
            for (int i = 2; i < max; i++)
            {
                if (i == FactorChecker.RaiseDigitsToPower(i, 5))
                {
                    total += i;
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("Total: " + total);
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }

    public class FactorChecker
    {
        public static IEnumerable<int> GetDigits(int number)
        {
            int digit = number % 10;
            int remainder = number / 10;

            yield return digit;

            while (remainder != 0)
            {
                digit = remainder % 10;
                remainder = remainder / 10;

                yield return digit;
            }
        }

        public static double RaiseDigitsToPower(int number, int power)
        {
            double result = 0;
            foreach (int digit in GetDigits(number))
            {
                result += Math.Pow(digit, power);
            }
            return result;
        }
    }
}
