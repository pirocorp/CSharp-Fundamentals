using System;

namespace TestNumbers
{
    class TestNumbers
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var maxSumBoundary = int.Parse(Console.ReadLine());

            var totalSum = 0;
            var count = 0;
            bool br = false;

            for (int i = n; i >= 1; i--)
            {
                if (br) break;

                for (int j = 1; j <= m; j++)
                {
                    totalSum += i * j * 3;
                    count++;

                    if (totalSum >= maxSumBoundary)
                    {
                        br = true;
                        break;
                    }
                }
            }

            if (br)
            {
                Console.WriteLine($"{count} combinations");
                Console.WriteLine($"Sum: {totalSum} >= {maxSumBoundary}");
            }
            else
            {
                Console.WriteLine($"{count} combinations");
                Console.WriteLine($"Sum: {totalSum}");
            }
        }
    }
}
