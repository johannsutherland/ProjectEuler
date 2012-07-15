using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            int[] multiples = { 3, 5 };
            int upperlimit = 1000;

            NumberValidator numberValidator = new NumberValidator(multiples);

            for (int i = 1; i < upperlimit; i++)
            {
                if (numberValidator.CheckNumber(i))
                {
                    total += i;
                }
            }

            Console.WriteLine(total);
            Console.ReadKey();
        }
    }

    class NumberValidator
    {
        private int[] multiples;

        public NumberValidator(int[] multiples)
        {
            this.multiples = multiples;
        }

        public bool CheckNumber(int candidate)
        {
            foreach (int multiple in multiples)
            {
                if (candidate % multiple == 0)
                    return true;
            }

            return false;
        }
    }
}
