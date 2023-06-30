using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testfall3SortierenCSharp
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

            for (int i = 0; i < zahlen.Length - 1; i++)
            {
                for (int j = 0; j < zahlen.Length - i - 1; j++)
                {
                    if (zahlen[j] > zahlen[j + 1])
                    {
                        var tempVar = zahlen[j];
                        zahlen[j] = zahlen[j + 1];
                        zahlen[j + 1] = tempVar;
                    }
                }                
            }

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
