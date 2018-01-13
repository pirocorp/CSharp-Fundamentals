using System;

namespace _21.Sieve_of_Eratosthenes
{
    class Program
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            n++;
            bool[] primes = new bool[n];
            InitializeBoolArray(primes);
            primes[0] = false;
            primes[1] = false;
            FindAllPrimes(n, primes);
            PrintAllPrimes(primes);
            Console.WriteLine();
        }

        private static void PrintAllPrimes(bool[] primes)
        {
            for (long i = 2; i < primes.Length; i++)
            {
                if(primes[i])
                Console.Write(i + " ");
            }
        }

        private static void FindAllPrimes(long n, bool[] primes)
        {
            for (long i = 2; i < Math.Sqrt(n); i++)
            {
                if (primes[i])
                {
                    for (long j = i * i; j < n; j += i)
                    {
                        primes[j] = false;
                    }
                }
            }
        }

        private static void InitializeBoolArray(bool[] primes)
        {
            for (long i = 0; i < primes.Length; i++)
            {
                primes[i] = true;
            }
        }
    }
}
