using System;
using System.Numerics;

namespace Factorial
{
    class Factorial
    {
        static void Main()
        {
            int factor = int.Parse(Console.ReadLine());

            BigInteger factorial = 1;
            for (int i = 1; i <= factor; i++)
            {
                factorial *= i;
            }

            Console.WriteLine(factorial);
        }
    }
}
