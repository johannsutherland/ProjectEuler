using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem25
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci f = new Fibonacci();
            int i = 3;
            while (f.GetNextFibonacci().ToString().Length < 1000)
                i++;

            Console.WriteLine(i);
            Console.ReadKey();
        }
    }

    class Fibonacci
    {
        private BigInteger f1;
        private BigInteger f2;

        public Fibonacci()
        {
            f1 = 1;
            f2 = 1;
        }

        public BigInteger GetNextFibonacci()
        {
            BigInteger number = f1 + f2;
            f2 = f1;
            f1 = number;
            return number;
        }
    }
}
