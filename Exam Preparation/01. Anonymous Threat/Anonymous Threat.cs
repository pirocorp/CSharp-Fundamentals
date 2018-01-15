using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Anonymous_Threat
{
    class Program
    {
        static void Main()
        {
            var inputStrings = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
            var commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result = inputStrings;
            string currentCommand = commands[0];

            while (commands[0] != "3:1")
            {
                if (currentCommand == "merge")
                {
                    var startIndex = int.Parse(commands[1]);
                    var endIndex = int.Parse(commands[2]);
                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (endIndex >= result.Count)
                    {
                        endIndex = result.Count - 1;
                    }
                    if(startIndex <= endIndex)
                    result = ConcatenateStrings(startIndex, endIndex, result);

                }
                else if (currentCommand == "divide")
                {
                    var index = int.Parse(commands[1]);
                    var partitions = int.Parse(commands[2]);
                    if (index < 0)
                    {
                        index = 0;
                    }

                    if (index >= result.Count)
                    {
                        index = result.Count - 1;
                    }
                    result = DivideString(index, partitions, result);
                }

                commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                currentCommand = commands[0];
            }

            Console.WriteLine(String.Join(" ", result));
        }

        private static List<string> DivideString(int index, int partitions, List<string> inputStrings)
        {
            var resultedList = new List<string>();

            for (int i = 0; i < index; i++)
            {
                resultedList.Add(inputStrings[i]);
            }

            List<string> parts = MakeStringIntoSubStrings(inputStrings[index], partitions);

            for (int i = 0; i < parts.Count; i++)
            {
                resultedList.Add(parts[i]);
            }

            for (int i = index + 1; i < inputStrings.Count; i++)
            {
                resultedList.Add(inputStrings[i]);

            }
            return resultedList;
        }

        private static List<string> MakeStringIntoSubStrings(string inputString, int partitions)
        {
            var resultedList = new List<string>();
            var elementLenght = inputString.Length / partitions;
            var lastPartitionLenght = elementLenght + inputString.Length % partitions;

            for (int i = 0; i < inputString.Length - lastPartitionLenght; i+= elementLenght)
            {
                var currentSubString = inputString.Substring(i, elementLenght);
                resultedList.Add(currentSubString);
            }

            var currentString = inputString.Substring(inputString.Length - lastPartitionLenght, lastPartitionLenght);
            resultedList.Add(currentString);

            return resultedList;
        }

        private static List<string> ConcatenateStrings(int startIndex, int endIndex, List<string> inputStrings)
        {
            var resultedList = new List<string>();

            for (int i = 0; i < startIndex; i++)
            {
                resultedList.Add(inputStrings[i]);
            }

            var resultString = string.Empty;

            for (int i = startIndex; i <= endIndex; i++)
            {
                resultString += inputStrings[i];
            }

            resultedList.Add(resultString);

            for (int i = endIndex + 1; i < inputStrings.Count; i++)
            {
                resultedList.Add(inputStrings[i]);
            }

            return resultedList;
        }
    }
}
