using System;
using System.Linq;

namespace _25.Most_Frequent_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeterList = { ' ' };
            int[] numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int bestNumber = numbers[0];
            int bestCount = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        count++;
                    }
                }

                if (count > bestCount)
                {
                    bestCount = count;
                    bestNumber = numbers[i];
                }
            }

            Console.WriteLine(bestNumber);
        }
    }
}
