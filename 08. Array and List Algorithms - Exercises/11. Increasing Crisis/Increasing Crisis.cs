using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Increasing_Crisis
{
    class Program
    {

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

                var appendIndex = FindAppendIndex(sequencesOfIntegers[0], resultedList);

                if (appendIndex == resultedList.Count)
                {
                    AppendList(resultedList, sequencesOfIntegers);
                    continue;
                }

                if (appendIndex <= 0)
                {
                    resultedList.Clear();
                    continue;
                }

                for (int j = 1; j < sequencesOfIntegers.Count; j++)
                {
                    resultedList.Insert(appendIndex, sequencesOfIntegers[j - 1]);
                    appendIndex++;

                    if (sequencesOfIntegers[j - 1] <= sequencesOfIntegers[j])
                    {
                        resultedList.Insert(appendIndex, sequencesOfIntegers[j]);
                        appendIndex++;
                    }
                    else
                    {
                        resultedList.RemoveRange(appendIndex, resultedList.Count - appendIndex);
                        break;
                    }
                }
            }

            Console.WriteLine(String.Join(" ", resultedList));
        }

        private static void AppendList(List<int> resultedList, List<int> sequencesOfIntegers)
        {
            resultedList.Add(sequencesOfIntegers[0]);
            for (int j = 1; j < sequencesOfIntegers.Count; j++)
            {
                if (sequencesOfIntegers[j - 1] <= sequencesOfIntegers[j])
                {
                    resultedList.Add(sequencesOfIntegers[j]);
                }
                else
                {
                    break;
                }
            }
        }

        private static int FindAppendIndex(int sequencesOfInteger, List<int> resultedList)
        {
            int result = -1;

            for (int i = 0; i < resultedList.Count; i++)
            {
                if (resultedList[i] < sequencesOfInteger)
                {
                     result = i;
                }
            }

            return result + 1;
        }
    }
}
