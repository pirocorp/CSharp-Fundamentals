using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Binary_Search
{
    class Program
    {
        private static bool found = false;
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var uniqueIntegers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var searchedInt = int.Parse(Console.ReadLine());

            var linearCount = LinearSearch(searchedInt, uniqueIntegers);
            var binaryCount = BinarySearch(searchedInt, uniqueIntegers);

            if (!found)
            {
                Console.WriteLine("No");
            }
            else
            {
                Console.WriteLine("Yes");
            }
            Console.WriteLine($"Linear search made {linearCount} iterations");
            Console.WriteLine($"Binary search made {binaryCount} iterations");
        }

        private static int BinarySearch(int searchedInt, List<int> uniqueIntegers)
        {
            SortList(uniqueIntegers);

            var lowerBound = 0;
            var upperBound = uniqueIntegers.Count -1;
            var count = 0;

            while (true)
            {
                if (upperBound < lowerBound)
                {
                    found = false;
                    return count;
                }

                count++;

                var midPoint = lowerBound + (upperBound - lowerBound) / 2;

                if (uniqueIntegers[midPoint] < searchedInt)
                {
                    lowerBound = midPoint + 1;
                }
                else if (uniqueIntegers[midPoint] > searchedInt)
                {
                    upperBound = midPoint - 1;
                }
                else if (uniqueIntegers[midPoint] == searchedInt)
                {
                    found = true;
                    return count;
                }
            }
        }

        private static void SortList(List<int> uniqueIntegers)
        {
            for (int firstUnsorted = 0; firstUnsorted < uniqueIntegers.Count - 1; firstUnsorted++)
            {
                var i = firstUnsorted + 1;
                while (i > 0)
                {
                    if (uniqueIntegers[i - 1] > uniqueIntegers[i])
                    {
                        var swap = uniqueIntegers[i - 1];
                        uniqueIntegers[i - 1] = uniqueIntegers[i];
                        uniqueIntegers[i] = swap;
                    }
                    i--;
                }
            }
        }

        private static int LinearSearch(int searchedInt, List<int> uniqueIntegers)
        {
            var count = 0;
            for (int i = 0; i < uniqueIntegers.Count; i++)
            {
                count++;
                if (searchedInt == uniqueIntegers[i])
                {
                    found = true;
                    return count;
                }
            }

            return count;
        }
    }
}
