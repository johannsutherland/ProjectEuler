using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;

namespace Problem15
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 20; i++)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                GridWalker gridWalker = new GridWalker(i);
                sw.Stop();
                Console.WriteLine(i + " has " + gridWalker.GetRoutes() + " routes (found in " + sw.ElapsedMilliseconds + "ms)");
            }
            Console.ReadKey();
        }
    }

    class GridWalker
    {
        private int size;
        private Dictionary<string, long> cache;

        public GridWalker(int size)
        {
            this.size = size;
            this.cache = new Dictionary<string, long>();
        }

        private long GetRoutes(int x, int y)
        {
            long paths = 0;

            if ((x == size) && (y == size))
                return 1;

            if (cache.ContainsKey(x + "_" + y))
                return cache[x + "_" + y];
            
            if (x < size)
                paths += GetRoutes(x + 1, y);

            if (y < size)
                paths += GetRoutes(x, y + 1);

            cache.Add(x + "_" + y, paths);

            return paths;
        }

        public long GetRoutes()
        {
            return this.GetRoutes(0, 0);
        }
    }
}
