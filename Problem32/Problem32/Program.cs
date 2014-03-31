using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem32
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> products = new List<int>();

            for (int a = 1; a < 100; a++)
            {
                for (int b = 100; b < 10000; b++)
                {
                    int product = a * b;
                    if (Pandigital.IsPandigital(a, b, product))
                    {
                        Console.WriteLine("{0} x {1} = {2}", a, b, product);
                        if (!products.Contains(a * b)) products.Add(product);
                    }
                }
            }

            Console.WriteLine(products.Sum());
            Console.WriteLine("Done.");
            Console.ReadKey();
        }
    }

    public class Pandigital
    {
        public static bool IsPandigital(long number)
        {
            string num = number.ToString();
            if (num.Contains('0'))
                return false;

            int[] usedDigits = new int[10];

            while (num.Length > 0)
            {
                int digit = int.Parse(num[0].ToString());
                if (usedDigits[digit] > 0)
                {
                    return false;
                }
                else
                {
                    num = num.Substring(1);
                    usedDigits[digit]++;
                }
            }
            return true;
        }

        public static bool IsPandigital(int number1, int number2, int number3)
        {
            string bigNumber = number1.ToString() + number2.ToString() + number3.ToString();

            if (bigNumber.Length != 9)
                return false;

            if (bigNumber.Contains('0'))
                return false;

            long concatenatedNumber = long.Parse(bigNumber.ToString());

            return IsPandigital(concatenatedNumber);
        }
    }
}
