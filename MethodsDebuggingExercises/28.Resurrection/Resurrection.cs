using System;

namespace _28.Resurrection
{
    class Resurrection
    {
        static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            for (long i = 0; i < n; i++)
            {
                long totalLength = long.Parse(Console.ReadLine());
                decimal totalWidth = decimal.Parse(Console.ReadLine());
                long wingLength = long.Parse(Console.ReadLine());

                decimal totalYears = GetTotalYears(totalLength, totalWidth, wingLength);
                Console.WriteLine(totalYears);
            }
        }

        private static decimal GetTotalYears(long totalLength, decimal totalWidth, long wingLength)
        {
            decimal totalYears = totalLength * totalLength * (totalWidth + 2 * wingLength);

            return totalYears;
        }
    }
}
