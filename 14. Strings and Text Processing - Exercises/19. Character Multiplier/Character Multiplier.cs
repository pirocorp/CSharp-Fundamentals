namespace _19.Character_Multiplier
{
    using System;

    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var firstString = inputData[0];
            var secondString = inputData[1];
            var totalSum = 0L;

            var count = Math.Min(firstString.Length, secondString.Length);

            for (int i = 0; i < count; i++)
            {
                totalSum += firstString[i] * secondString[i];
            }

            if (firstString.Length > secondString.Length)
            {
                for (int i = count; i < firstString.Length; i++)
                {
                    totalSum += firstString[i];
                }
            }
            else if (secondString.Length > firstString.Length)
            {
                for (int i = count; i < secondString.Length; i++)
                {
                    totalSum += secondString[i];
                }
            }

            Console.WriteLine(totalSum);
        }
    }
}
