using System;
using System.Numerics;

namespace FactorialTrailingZeroes
{
    class FactorialTrailingZeroes
    {
        static void Main()
        {
            int factor = int.Parse(Console.ReadLine());

            BigInteger factorial = GetFactorial(factor);
            int trailingZeros = GetTrailingZeros(factorial);
            string zeros = trailingZeros > 1 ? "zeros" : "zero";
            Console.WriteLine($"{factorial} -> {trailingZeros} trailing {zeros}");
            //Console.WriteLine(trailingZeros);
        }

        static int GetTrailingZeros(BigInteger factorial)
        {
            int trailingZeros = 0;
            while (factorial % 10 == 0)
            {
                trailingZeros++;
                factorial /= 10;
            }

            return trailingZeros;
        }

        static BigInteger GetFactorial(int factor)
        {
            BigInteger factorial = 1;
            for (int i = 1; i <= factor; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}
