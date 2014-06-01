using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem39
{
    class Program
    {
        static void Main(string[] args)
        {
            int pLimit = 1000;
            int[] solutions = new int[pLimit];
            int maxSolutions = 0;
            int maxP = 0;

            for (int a = 1; a < pLimit / 2; a++)
            {
                for (int b = a; a + b < pLimit; b++)
                {
                    double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
                    if ((Math.Floor(c) == c))
                    {
                        int p = a + b + (int)c;
                        if (p < pLimit)
                        {
                            solutions[p]++;
                            if (solutions[p] > maxSolutions)
                            {
                                maxSolutions = solutions[p];
                                maxP = p;
                            }
                        }
                    }
                }
            }
            Console.WriteLine("p = {0} with {1} solutions,", maxP, maxSolutions);
            Console.ReadKey();
        }
    }
}
