using System;
using System.Linq;

namespace _20.Fold_and_Sum
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

            int partsLength = numbers.Length / 4;

            int[] partOne = new int[partsLength];

            for (int i = 1; i <= partsLength; i++)
            {
                partOne[i -1] = numbers[partsLength - i];
            }

            int[] partTwo = new int[partsLength];
            int numbersLastElement = numbers.Length - 1;
            for (int i = 0; i < partsLength; i++)
            {
                partTwo[i] = numbers[numbersLastElement - i];
            }

            int[] secondRow = new int[partsLength * 2];

            for (int i = 0; i < partsLength; i++)
            {
                secondRow[i] = partOne[i];
                secondRow[(secondRow.Length / 2) + i] = partTwo[i];
            }

            int[] firsRow = new int[secondRow.Length];

            int j = 0;
            for (int i = partsLength; i < numbers.Length - partsLength; i++)
            {
                firsRow[j] = numbers[i];
                j++;
            }

            int[] result = new int[secondRow.Length];

            string stringResult = string.Empty;
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = firsRow[i] + secondRow[i];
                stringResult += result[i] + " ";
            }

            stringResult = stringResult.Trim();
            Console.WriteLine(stringResult);
        }
    }
}
