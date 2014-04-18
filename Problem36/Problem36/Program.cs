using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem36
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 1000000;
            int sumOfPalindromes = 0;

            for (int number = 1; number < max; number++)
            {
                if (isPalindrome(number) && isPalindrome(Convert.ToString(number, 2)))
                {
                    Console.WriteLine(number);
                    sumOfPalindromes += number;
                }
            }
            Console.WriteLine("The sum is {0}", sumOfPalindromes);
            Console.ReadKey();
        }

        static bool isPalindrome(string number)
        {
            int boundary = (int)Math.Ceiling((double)number.Length / 2);
            for (int i = 0; i < boundary; i++)
            {
                if (number[i] != number[number.Length - 1 - i])
                    return false;
            }
            return true;
        }

        static bool isPalindrome(long number)
        {
            return isPalindrome(number.ToString());
        }
    }
}
