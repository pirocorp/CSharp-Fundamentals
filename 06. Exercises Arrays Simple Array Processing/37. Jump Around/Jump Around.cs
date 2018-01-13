using System;
using System.Linq;

namespace _37.Jump_Around
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            int[] numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int sumOfPositions = 0;
            int currentIndex = 0;

            while (true)
            {
                sumOfPositions += numbers[currentIndex];
                bool moveRight = currentIndex + numbers[currentIndex] < numbers.Length &&
                                 currentIndex + numbers[currentIndex] >= 0;

                bool moveLeft = currentIndex - numbers[currentIndex] < numbers.Length &&
                                currentIndex - numbers[currentIndex] >= 0;
                if (moveRight)
                {
                    currentIndex += numbers[currentIndex];
                }
                else if (moveLeft)
                {
                    currentIndex -= numbers[currentIndex];
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(sumOfPositions);
        }
    }
}
