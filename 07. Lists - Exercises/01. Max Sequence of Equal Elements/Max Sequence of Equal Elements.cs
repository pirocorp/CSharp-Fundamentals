using System;
using System.Collections.Generic;
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

            var maxSequenceOfEqualElements = GetMaxSequenceOfEqualElements(numbers);
            Console.WriteLine($"{String.Join(" ", maxSequenceOfEqualElements)}");
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
