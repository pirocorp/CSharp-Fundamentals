using System;

namespace _17.Resizable_Array
{
    class Program
    {
        static void Main()
        {
            double[] numbers = new double[4];
            Initialise(numbers);
            string[] command = Console.ReadLine().Split();
            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "push":
                        numbers = Push(numbers, command[1]);
                        break;
                    case "pop":
                        Pop(numbers);
                        break;
                    case "removeAt":
                        RemoveAt(numbers, command[1]);
                        break;
                    case "clear":
                        Clear(numbers);
                        break;
                        default: break;
                }

                command = Console.ReadLine().Split();
            }

            PrintArray(numbers);
        }

        private static double[] Push(double[] numbers, string elementString)
        {
            bool arrayIsFull = IsArrayFull(numbers);

            double element = double.Parse(elementString);
            if (arrayIsFull)
            {
                int currentElementIndex = numbers.Length;
                int sizeOfArray = numbers.Length * 2;
                numbers = CreateNewArray(numbers, sizeOfArray);
                numbers[currentElementIndex] = element;
            }
            else
            {
                int freeIndex = GetIndexOfFreeSpaceInArray(numbers);
                numbers[freeIndex] = element;
            }

            return numbers;
        }

        private static bool IsArrayFull(double[] numbers)
        {
            bool arrayIsFull = true;
            for (int index = 0; index < numbers.Length; index++)
            {
                if (Double.IsNaN(numbers[index]))
                {
                    arrayIsFull = false;
                    return arrayIsFull;
                }
            }

            return arrayIsFull;
        }

        private static double[] CreateNewArray(double[] numbers, int sizeOfArray)
        {
            double[] newArray = new double[sizeOfArray];
            Initialise(newArray);

            for (int numbersIndex = 0; numbersIndex < numbers.Length; numbersIndex++)
            {
                newArray[numbersIndex] = numbers[numbersIndex];
            }

            return newArray;
        }

        private static void Initialise(double[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = double.NaN;
            }
        }

        private static int GetIndexOfFreeSpaceInArray(double[] numbers)
        {
            for (int index = 0; index < numbers.Length; index++)
            {
                if (Double.IsNaN(numbers[index])) return index;
            }

            return -1;
        }

        private static void Pop(double[] numbers)
        {
            int indexOfLastValidNumberInArray = LastValidNumberInArray(numbers);
            numbers[indexOfLastValidNumberInArray] = double.NaN;
        }

        private static int LastValidNumberInArray(double[] numbers)
        {
            int lastValidIndex = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!Double.IsNaN(numbers[i]))
                {
                    lastValidIndex = i;
                }
            }

            return lastValidIndex;
        }

        private static void RemoveAt(double[] numbers, string stringIndex)
        {
            int index = int.Parse(stringIndex);
            numbers[index] = double.NaN;
        }

        private static void Clear(double[] numbers)
        {
            Initialise(numbers);
        }

        private static void PrintArray(double[] numbers)
        {
            if (ArrayIsEmpty(numbers))
            {
                Console.WriteLine("empty array");
                return;
            }
            else
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (!Double.IsNaN(numbers[i]))
                    {
                        Console.Write($"{numbers[i]} ");
                    }
                }

                Console.WriteLine();
            }
        }

        private static bool ArrayIsEmpty(double[] numbers)
        {
            bool arrayIsEmpty = true;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!Double.IsNaN(numbers[i]))
                {
                    arrayIsEmpty = false;
                    return arrayIsEmpty;
                }
            }

            return arrayIsEmpty;
        }
    }
}
