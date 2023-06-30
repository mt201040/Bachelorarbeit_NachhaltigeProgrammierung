using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Testfall3SortCSharpN
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int[] zahlen = new int[100000];
            Random rnd = new Random();

            for (int i = 0; i < zahlen.Length; i++)
            {
                zahlen[i] = rnd.Next(1, 100000);
            }

            Array.Sort(zahlen);

            for (int i = 0; i < zahlen.Length; i++)
            {
                Console.WriteLine(zahlen[i] + ", ");
            }

            stopwatch.Stop();
            Console.WriteLine("Laufzeit: " + stopwatch.Elapsed);

            Console.ReadKey();
        }
    }
}
