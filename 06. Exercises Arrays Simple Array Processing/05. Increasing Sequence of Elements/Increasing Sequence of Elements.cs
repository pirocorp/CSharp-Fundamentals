using System;
using System.Linq;

namespace _05.Increasing_Sequence_of_Elements
{
    class Program
    {
        static void Main()
        {
            char[] delimeter = {' '};
            int[] numbers = Console.ReadLine()
                .Split(delimeter, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            bool isIncreasingSsequence = true;
            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] >= numbers[i+1])
                {
                    isIncreasingSsequence = false;
                    break;
                }
            }

            if (isIncreasingSsequence)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
