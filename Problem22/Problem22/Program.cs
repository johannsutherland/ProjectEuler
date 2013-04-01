using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem22
{
    class Program
    {
        static void Main(string[] args)
        {
            string allLines;
            using (TextReader tr = File.OpenText(@"names.txt"))
            {
                allLines = tr.ReadToEnd();
                tr.Close();
            }
            allLines = allLines.Replace("\"", "");

            List<string> names = allLines.Split(',').ToList();
            names.Sort();

            int grandTotal = 0;
            for (int i = 0; i < names.Count; i++)
            {
                int total = 0;
                ASCIIEncoding.ASCII.GetBytes(names[i].ToCharArray()).ToList().ForEach(x => total += (x - 64));
                grandTotal += total * (i + 1);
            }

            Console.WriteLine(grandTotal);
            Console.ReadKey();
        }
    }
}
