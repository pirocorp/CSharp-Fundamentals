using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Extremums
{
    class Extremums
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };

            var inputNumbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();
            string result;

            if (command == "Max")
            {
                result = GetMaxNumbers(inputNumbers);
            }
            else
            {
                result = GetMinNumbers(inputNumbers);
            }

            var resultedList = result
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Console.WriteLine(String.Join(", ", resultedList));
            Console.WriteLine(resultedList.Sum());
        }

        private static string GetMinNumbers(List<string> inputNumbers)
        {
            var choosenNumbers = string.Empty;

            for (int i = 0; i < inputNumbers.Count; i++)
            {
                choosenNumbers += GetMinVersionOfNumber(inputNumbers[i]) + " ";
            }

            return choosenNumbers;
        }

        private static long GetMinVersionOfNumber(string inputNumber)
        {
            var minNumber = long.MaxValue;
            var numberString = inputNumber;

            for (int i = 0; i < inputNumber.Length; i++)
            {
                var currentNumber = long.Parse(numberString);

                if (minNumber > currentNumber)
                {
                    minNumber = currentNumber;
                }

                var newNumberString = RotateString(numberString);
                numberString = newNumberString;
            }

            return minNumber;
        }

        private static string GetMaxNumbers(List<string> inputNumbers)
        {
            var choosenNumbers = string.Empty;

            for (int i = 0; i < inputNumbers.Count; i++)
            {
                choosenNumbers += GetMaxVersionOfNumber(inputNumbers[i]) + " ";
            }

            return choosenNumbers;
        }

        private static long GetMaxVersionOfNumber(string inputNumber)
        {
            var minNumber = long.MinValue;
            var numberString = inputNumber;

            for (int i = 0; i < inputNumber.Length; i++)
            {
                var currentNumber = long.Parse(numberString);

                if (minNumber < currentNumber)
                {
                    minNumber = currentNumber;
                }

                var newNumberString = RotateString(numberString);
                numberString = newNumberString;
            }

            return minNumber;
        }

        private static string RotateString(string numberString)
        {
            var newNumberString = string.Empty;
            var swap = string.Empty;
            swap += numberString[0];

            for (var i = 1; i < numberString.Length; i++)
            {
                newNumberString += numberString[i];
            }

            newNumberString += swap;

            return newNumberString;
        }
    }
}
