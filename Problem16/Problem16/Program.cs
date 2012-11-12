using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem16
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = 1;

            for (int i = 1; i <= 1000; i++)
            {
                number *= 2;
            }

            Console.WriteLine("Number: " + number);

            int sum = 0;

            while (number > 0)
            {
                sum += (int)(number % 10);
                number /= 10;
            }

            Console.WriteLine("Sum: " + sum);
            Console.ReadKey();
        }
    }
}
