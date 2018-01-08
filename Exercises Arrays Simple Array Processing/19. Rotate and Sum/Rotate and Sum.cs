using System;
using System.Linq;

namespace _19.Rotate_and_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimeterList = {' '};
            int[] numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rotateToTheRight = int.Parse(Console.ReadLine());
            int[] result = new int[numbers.Length];
            for (int i = 0; i < rotateToTheRight; i++)
            {
                int[] rotated = RotateArrayToTheRight(numbers);
                result = SumOfArrays(rotated, result);
                numbers = rotated;
            }

            PrintArray(result);
        }

        private static void PrintArray(int[] numbers)
        {
            string result = string.Empty;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i] + " ";
            }

            result = result.Trim();
            Console.WriteLine(result);
        }

        private static int[] SumOfArrays(int[] numbers, int[] rotated)
        {
            int[] result = new int[numbers.Length];
            for (int resultIndex = 0; resultIndex < numbers.Length; resultIndex++)
            {
                result[resultIndex] = numbers[resultIndex] + rotated[resultIndex];
            }

            return result;
        }

        private static int[] RotateArrayToTheRight(int[] numbers)
        {
            int[] rotatedArray = new int[numbers.Length];
            int numbersLastElement = numbers.Length - 1;
            rotatedArray[0] = numbers[numbersLastElement];

            for (int i = 1; i < numbers.Length; i++)
            {
                rotatedArray[i] = numbers[i-1];
            }

            return rotatedArray;
        }
    }
}
