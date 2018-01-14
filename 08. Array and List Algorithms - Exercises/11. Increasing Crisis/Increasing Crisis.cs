using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Increasing_Crisis
{
    class Program
    {
        private static int mostRightToNumberIndex;
        static void Main()
        {
            char[] delimeterList = {' '};
            var n = int.Parse(Console.ReadLine());

            var resultedList = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            for (int i = 1; i < n; i++)
            {
                var sequencesOfIntegers = Console.ReadLine()
                    .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                    mostRightToNumberIndex = MostRightToNumber(sequencesOfIntegers[0], resultedList);
                    bool allInserted = InsertList(resultedList, sequencesOfIntegers);

                    if (!allInserted)
                    {
                        RemoveAfterIndexFromList(resultedList);
                    }
            }

            Console.WriteLine(String.Join(" ", resultedList));
        }

        private static void RemoveAfterIndexFromList(List<int> resultedList)
        {
            int n = resultedList.Count;
            mostRightToNumberIndex++;
            for (int i = mostRightToNumberIndex; i < n; i++)
            {
                resultedList.RemoveAt(resultedList.Count-1);
            }
        }

        private static bool InsertList(List<int> resultedList, List<int> sequencesOfIntegers)
        {
            mostRightToNumberIndex++;
            resultedList.Insert(mostRightToNumberIndex, sequencesOfIntegers[0]);

            for (int i = 1; i < sequencesOfIntegers.Count; i++)
            {
                var nextElement = sequencesOfIntegers[i];
                var currentElement = sequencesOfIntegers[i - 1];

                if (currentElement <= nextElement)
                {
                    mostRightToNumberIndex++;
                    resultedList.Insert(mostRightToNumberIndex, nextElement);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private static int MostRightToNumber(int big, List<int> resultedList)
        {
            var index = -1;
            for (int i = 0; i < resultedList.Count; i++)
            {
                if (resultedList[i] <= big)
                {
                    index = i;
                }
            }

            return index;
        }
    }
}
