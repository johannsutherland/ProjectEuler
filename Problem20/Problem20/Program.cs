using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem20
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger a = 1;
            for (int i = 100; i > 1; i--)
            {
                a *= i;
            }

            int sumOfDigits = 0;
            while (a > 1)
            {
                sumOfDigits += (int)BigInteger.Remainder(a, 10);
                Console.WriteLine(sumOfDigits);
                a = a / 10;
            }
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
