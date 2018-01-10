using System;
using System.Linq;

namespace _01.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            int lenth = 1;
            int position = 0;
            int bestLenth = 1;
            int bestPosition = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                if (numbers[i - 1] == numbers[i])
                {
                    lenth++;
                }
                else
                {
                    position = i;
                    lenth = 1;
                }

                if (lenth > bestLenth)
                {
                    bestLenth = lenth;
                    bestPosition = position;

                }
            }

            string result = String.Join(" ", numbers.Select(i => i.ToString()).ToArray(), bestPosition, bestLenth);
            Console.WriteLine($"{result}");
        }
    }
}
