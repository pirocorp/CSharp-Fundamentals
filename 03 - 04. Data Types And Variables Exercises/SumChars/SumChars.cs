using System;

namespace SumChars
{
    class SumChars
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            int totalSum = 0;

            for (int i = 0; i < n; i++)
            {
                int letter = char.Parse(Console.ReadLine());
                totalSum += letter;
            }

            Console.WriteLine($"The sum equals: {totalSum}");
        }
    }
}
