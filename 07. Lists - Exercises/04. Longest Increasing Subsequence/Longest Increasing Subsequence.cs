using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Longest_Increasing_Subsequence
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            var numbersSequence = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var length = Enumerable.Repeat(0, numbersSequence.Count).ToList();
            var prev = Enumerable.Repeat(-1, numbersSequence.Count).ToList();


            for (int index = 0; index < numbersSequence.Count; index++)
            {
                length[index] = 1;
                prev[index] = -1;

                for (int i = 0; i < index; i++)
                {
                    if (numbersSequence[i] < numbersSequence[index] && length[i] + 1 > length[index])
                    {
                        length[index] = length[i] + 1;
                        prev[index] = i;
                    }
                }
            }

            int indexResult = length.IndexOf(length.Max());
            var listResult = new List<int>();

            while (indexResult >= 0)
            {
                listResult.Add(numbersSequence[indexResult]);
                indexResult = prev[indexResult];
            }

            listResult.Reverse();
            Console.WriteLine(String.Join(" ", listResult));
        }
    }
}
