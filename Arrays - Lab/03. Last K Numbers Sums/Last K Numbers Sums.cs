using System;

namespace _03.Last_K_Numbers_Sums
{
    class Program
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            long k = long.Parse(Console.ReadLine());

            long[] sequence = new long[n];

            sequence[0] = 1;
            for (long i = 1; i < n; i++)
            {
                long sum = 0;
                long count = 0;
                if (i >= k) count = i - k;

                for (long j = count; j < i; j++)
                {
                    sum += sequence[j];
                }

                sequence[i] = sum;
            }

            for (long i = 0; i < n; i++)
            {
                Console.Write($"{sequence[i]} ");
            }
        }
    }
}
