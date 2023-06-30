using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Testfall1PrimCSharpN
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<int> primes = new List<int>();

            for (int i = 2; i <= 500000; i++)
            {
                bool isPrime = true;
                int sqrt = (int)Math.Sqrt(i);

                for (int j = 2; j <= sqrt; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primes.Add(i);
                }
            }

            foreach (int prime in primes)
            {
                Console.WriteLine(prime + ", ");
            }

            stopwatch.Stop();
            Console.WriteLine("Laufzeit: " + stopwatch.Elapsed);
            Console.ReadKey();
        }
    }
}

