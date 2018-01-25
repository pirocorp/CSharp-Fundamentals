using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _09.Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main()
        {
            var inputLines = File.ReadAllLines("Input.txt");

            for (var i = 0; i < inputLines.Length; i++)
            {
                var numbers = inputLines[i]
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                var maxSequenceOfEqualElements = GetMaxSequenceOfEqualElements(numbers);
                var result = new[] { $"{String.Join(" ", maxSequenceOfEqualElements)}" };
                File.AppendAllLines("Output.txt", result);
            }

        }

        private static List<int> GetMaxSequenceOfEqualElements(List<int> arr)
        {
            var longestSequence = new List<int>();
            var currentSequence = new List<int>();
            currentSequence.Add(arr[0]);

            for (int i = 1; i < arr.Count; i++)
            {
                var currentNum = arr[i];
                var searchNum = currentSequence[0];
                if (currentNum == searchNum)
                {
                    currentSequence.Add(currentNum);
                }
                else
                {
                    if (currentSequence.Count > longestSequence.Count)
                    {
                        longestSequence = new List<int>(currentSequence);
                    }

                    currentSequence.Clear();
                    currentSequence.Add(currentNum);
                }

                if (currentSequence.Count > longestSequence.Count)
                {
                    longestSequence = new List<int>(currentSequence);
                }

            }

            return longestSequence;
        }
    }
}
