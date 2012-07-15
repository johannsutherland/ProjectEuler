using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem2
{
    class Program
    {
        static void Main(string[] args)
        {
            FibbonacciGenerator fg = new FibbonacciGenerator();
            long upperLimit = 4000000;
            long total = 0;

            while (true)
            {
                long term = fg.GetNextTerm();
                if (term > upperLimit)
                    break;

                if (term % 2 == 0)
                    total += term;
            }

            Console.WriteLine(total);
            Console.ReadKey();
        }
    }

    class FibbonacciGenerator
    {
        long t1;
        long t2;

        public FibbonacciGenerator()
        {
            t1 = 1;
            t2 = 0;
        }

        public long GetNextTerm()
        {
            long nextTerm = t1 + t2;
            t2 = t1;
            t1 = nextTerm;
            return nextTerm;
        }
    }
}
