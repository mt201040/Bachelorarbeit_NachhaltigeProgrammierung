using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testfall1PrimzahlenCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] primes = new int[500000];
            int primeCount = 0;
            int isPrime = 0;

            for (int i = 2; i <= 500000; i++)
            {
                isPrime = 0;
                for (int j = 1; j <= 500000; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime++;
                    }
                }

                if (isPrime <= 2)
                {
                    primes[primeCount] = i;
                    primeCount++;
                }

            }

            for (int i = 0; i < primeCount; i++)
            {
                Console.WriteLine(primes[i] + ", ");
            }
            stopwatch.Stop();
            Console.WriteLine("Laufzeit: " + stopwatch.Elapsed);

            Console.ReadKey();
        }
    }
}
