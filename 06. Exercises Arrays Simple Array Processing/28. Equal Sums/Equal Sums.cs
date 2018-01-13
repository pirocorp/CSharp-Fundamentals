using System;
using System.Linq;

namespace _28.Equal_Sums
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

            for (int i = 0; i < numbers.Length; i++)
            {
                int leftSum = LeftSum(i, numbers);
                int rightSum = RightSum(i, numbers);
                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }

        private static int RightSum(int position, int[] numbers)
        {
            int sum = 0;
            for (int i = numbers.Length - 1; i > position; i--)
            {
                sum += numbers[i];
            }

            return sum;
        }

        private static int LeftSum(int position, int[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < position; i++)
            {
                sum += numbers[i];
            }

            return sum;
        }
    }
}
