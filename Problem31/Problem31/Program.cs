using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem31
{
    class Program
    {
        private static List<int> validUnits = new List<int> { 1, 2, 5, 10, 20, 50, 100, 200 };

        static void Main(string[] args)
        {
            Console.WriteLine("{0} has {1}", 1, GetNumberOfOptions(1));
            Console.WriteLine("{0} has {1}", 2, GetNumberOfOptions(2));
            Console.WriteLine("{0} has {1}", 5, GetNumberOfOptions(5));
            Console.WriteLine("{0} has {1}", 200, GetNumberOfOptions(200));
            Console.ReadKey();
        }

        private static int GetNumberOfOptions(int amount, int startingValue = 1)
        {
            if (amount == 0)
                return 1;

            int options = 0;
            foreach (int unit in validUnits.Where(x => x >= startingValue))
            {
                if (amount - unit >= 0)
                {
                    options += GetNumberOfOptions(amount - unit, unit);
                }
            }
            return options;
        }
    }
}
