using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem18
{
    class Program
    {
        static void Main(string[] args)
        {
            /*List<List<int>> values = new List<List<int>> { new List<int> { 3 }, 
                new List<int> { 7, 4 },
                new List<int> { 2, 4, 6 },
                new List<int> { 8, 5, 9, 3 } 
            };*/

            List<List<int>> values = ReadFile("data.txt");

            MaximumTriangleSum mts = new MaximumTriangleSum(values);
            Console.WriteLine(mts);
            Console.WriteLine(mts.FindMaximumPath());
            Console.ReadKey();
        }

        private static List<List<int>> ReadFile(string p)
        {
            List<List<int>> values = new List<List<int>>();

            string[] lines = File.ReadAllLines(p);

            foreach (string line in lines)
            {
                List<int> list = line.Split(' ').Select(n => int.Parse(n)).ToList();
                values.Add(list);
            }

            return values;
        }
    }

    class MaximumTriangleSum
    {
        private List<List<int>> triangle;

        public MaximumTriangleSum(List<List<int>> values)
        {
            triangle = values;
        }

        public int FindMaximumPath()
        {
            while (triangle.Count() > 1)
            {
                var lastRow = triangle.Last();
                triangle.Remove(lastRow);

                var currentRow = triangle.Last();

                for (int i = 0; i < currentRow.Count; i++)
                {
                    int value = currentRow[i];
                    currentRow[i] = Math.Max(value + lastRow[i], value + lastRow[i + 1]);
                }

                Console.WriteLine(this);
            }

            return triangle[0][0];
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in triangle)
            {
                foreach (int value in row)
                    sb.Append(value + " ");
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
