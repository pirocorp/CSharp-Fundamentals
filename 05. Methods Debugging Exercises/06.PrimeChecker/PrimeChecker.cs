using System;

namespace PrimeChecker
{
    class PrimeChecker
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            //for (int i = 0; i <= n; i++)
            //{
            //    if (IsPrime(i))
            //    {
            //        Console.WriteLine($"{i} true");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"{i} false");
            //    }
            //}
            Console.WriteLine(IsPrime(n));
        }

        static bool IsPrime(long number)
        {
            bool IsPrime = true;
            if (number == 0) return false;
            if (number == 1) return false;
            for (long i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) IsPrime = false;
            }

            return IsPrime;
        }
    }
}
