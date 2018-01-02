using System;

namespace FastPrimeCheckerRefactor
{
    class FastPrimeCheckerRefactor
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int currentNum = 2; currentNum <= n; currentNum++)
            {
                bool prime = true;

                for (int divisor = 2; divisor <= Math.Sqrt(currentNum); divisor++)
                {
                    if (currentNum % divisor == 0)
                    {
                        prime = false;
                        break;
                    }
                }

                Console.WriteLine($"{currentNum} -> {prime}");
            }
        }
    }
}
