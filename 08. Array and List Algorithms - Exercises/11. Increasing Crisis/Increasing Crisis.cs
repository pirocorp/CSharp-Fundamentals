using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Increasing_Crisis
{
    class Program
    {
        private static int mostRightToNumberIndex;
        static void Main()
        {
            char[] delimeterList = {' '};
            var n = int.Parse(Console.ReadLine());

            var resultedList = new List<int>();
            for (int i = 0; i < n; i++)
            {
                var sequencesOfIntegers = Console.ReadLine()
                    .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (resultedList.Count != 0)
                {
                    mostRightToNumberIndex = MostRightToNumber(sequencesOfIntegers[0], resultedList);
                    bool allInserted = InsertList(resultedList, sequencesOfIntegers);
                    if (!allInserted)
                    {
                        RemoveAfterIndexFromList(resultedList);
                    }
                }
                else
                {
                    AppendElementsToList(resultedList, sequencesOfIntegers);
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
            if (mostRightToNumberIndex >= resultedList.Count)
            {
                var result = AppendElementsToList(resultedList, sequencesOfIntegers);
                return result;
            }

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

        private static bool AppendElementsToList(List<int> resultedList, List<int> sequencesOfIntegers)
        {
            resultedList.Add(sequencesOfIntegers[0]);

            for (var j = 1; j < sequencesOfIntegers.Count; j++)
            {
                var nextElement = sequencesOfIntegers[j];
                var currentElement = sequencesOfIntegers[j - 1];

                if (currentElement <= nextElement)
                {
                    resultedList.Add(nextElement);
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
