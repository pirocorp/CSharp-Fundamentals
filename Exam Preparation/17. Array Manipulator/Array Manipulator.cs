namespace _17.Array_Manipulator
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var inputLine = Console.ReadLine().ToLower();

            while (inputLine != "end")
            {
                ProcessNumbers(inputLine, numbers);
                inputLine = Console.ReadLine().ToLower();
            }

            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static void ProcessNumbers(string inputLine, int[] numbers)
        {
            var tokens = inputLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var command = tokens[0];

            switch (command)
            {
                case "exchange":
                    var index = int.Parse(tokens[1]);

                    if (index < 0 || index >= numbers.Length)
                    {
                        Console.WriteLine($"Invalid index");
                        return;
                    }

                    ProcessExchangeCommand(index, numbers);
                    break;
                case "max":
                    var evenOrOdd = tokens[1];
                    index = GetIndexOfMaxEvenOrOddElement(numbers, evenOrOdd);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine($"{index}");
                    }
                    break;
                case "min":
                    evenOrOdd = tokens[1];
                    index = GetIndexOfMinEvenOrOddElement(numbers, evenOrOdd);

                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                    }
                    else
                    {
                        Console.WriteLine($"{index}");
                    }
                    break;
                case "first":
                    var count = int.Parse(tokens[1]);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        return;
                    }
                    evenOrOdd = tokens[2];
                    PrintFirstNElements(numbers, count, evenOrOdd);
                    break;
                case "last":
                    count = int.Parse(tokens[1]);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        return;
                    }
                    evenOrOdd = tokens[2];
                    PrintLastNElements(numbers, count, evenOrOdd);
                    break;
            }
        }

        private static void PrintLastNElements(int[] numbers, int count, string evenOrOddElement)
        {
            var evenOrOdd = evenOrOddElement == "even" ? 0 : 1;
            var result = numbers.Where(x => x % 2 == evenOrOdd).Reverse().Take(count).ToArray();
            result = result.Reverse().ToArray();
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        private static void PrintFirstNElements(int[] numbers, int count, string evenOrOddElement)
        {
            var evenOrOdd = evenOrOddElement == "even" ? 0 : 1;
            var result = numbers.Where(x => x % 2 == evenOrOdd).Take(count).ToArray();
            Console.WriteLine($"[{string.Join(", ", result)}]");
        }

        private static int GetIndexOfMinEvenOrOddElement(int[] numbers, string evenOrOddElement)
        {
            var evenOrOdd = evenOrOddElement == "even" ? 0 : 1;

            var minIndex = -1;
            var currentMin = int.MaxValue;

            for (var i = 0; i < numbers.Length; i++)
            {
                var currentElement = numbers[i];

                if (currentMin >= currentElement && currentElement % 2 == evenOrOdd)
                {
                    minIndex = i;
                    currentMin = currentElement;
                }
            }

            return minIndex;
        }

        private static int GetIndexOfMaxEvenOrOddElement(int[] numbers, string evenOrOddElement)
        {
            var evenOrOdd = evenOrOddElement == "even" ? 0 : 1;

            var maxIndex = -1;
            var currentMax = int.MinValue;

            for (var i = 0; i < numbers.Length; i++)
            {
                var currentElement = numbers[i];

                if (currentMax <= currentElement && currentElement % 2 == evenOrOdd)
                {
                    maxIndex = i;
                    currentMax = currentElement;
                }
            }
            
            return maxIndex;
        }

        private static void ProcessExchangeCommand(int index, int[] numbers)
        {
            var firstPart = new int[index + 1];
            var secondPart = new int[numbers.Length - (index + 1)];

            for (var i = 0; i < firstPart.Length; i++)
            {
                firstPart[i] = numbers[i];
            }

            for (var i = firstPart.Length; i < numbers.Length; i++)
            {
                secondPart[i - firstPart.Length] = numbers[i];
            }

            for (var i = 0; i < secondPart.Length; i++)
            {
                numbers[i] = secondPart[i];
            }

            for (var i = 0; i < firstPart.Length; i++)
            {
                numbers[i + secondPart.Length] = firstPart[i];
            }
        }
    }
}
