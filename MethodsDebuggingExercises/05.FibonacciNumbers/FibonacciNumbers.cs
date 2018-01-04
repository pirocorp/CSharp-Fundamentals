using System;

namespace FibonacciNumbers
{
    class FibonacciNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int nthFiboNum = ReturnNthFibo(n);
            Console.WriteLine(nthFiboNum);
        }

        static int ReturnNthFibo(int n)
        {
            if (n == 0 || n == 1) return 1;

            int zeroFibo = 1;
            int firstFibo = 1;
            int nFibo = 0;

            for (int i = 2; i <= n; i++)
            {
                nFibo = zeroFibo + firstFibo;
                zeroFibo = firstFibo;
                firstFibo = nFibo;
            }

            return nFibo;
        }
    }
}
