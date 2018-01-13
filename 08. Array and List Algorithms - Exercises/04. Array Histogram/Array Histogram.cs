using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Array_Histogram
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var originalStrings = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries).ToList();
            
            var uniqueWords = originalStrings.Distinct().ToList();
            var uniqueWordOccurrences = new List<int>();
            GetUniqueOccurencesInList(uniqueWords, originalStrings, uniqueWordOccurrences);
            SortBothLists(uniqueWords, uniqueWordOccurrences);
            var totalOccurencesInOriginalList = originalStrings.Count;
            PrintTheResult(uniqueWords, uniqueWordOccurrences, totalOccurencesInOriginalList);
        }

        private static void PrintTheResult(List<string> uniqueWords, List<int> uniqueWordOccurrences, int totalOccurencesInOriginalList)
        {
            for (int i = 0; i < uniqueWords.Count; i++)
            {
                var word = uniqueWords[i];
                var count = uniqueWordOccurrences[i];
                var percentage = (uniqueWordOccurrences[i] / (double)totalOccurencesInOriginalList) * 100;
                Console.WriteLine($"{word} -> {count} times ({percentage:F2}%)");
            }
        }

        private static void SortBothLists(List<string> uniqueWords, List<int> uniqueWordOccurrences)
        {
            var swapped = true;
            var n = uniqueWordOccurrences.Count;
            while (swapped)
            {
                swapped = false;

                for (int i = 1; i < n; i++)
                {
                    var currentElementWordList = uniqueWords[i];
                    var previusElementWordList = uniqueWords[i - 1];
                    var currentElementOccurrenceList = uniqueWordOccurrences[i];
                    var previusElementOccurrenceList = uniqueWordOccurrences[i - 1];


                    if (currentElementOccurrenceList > previusElementOccurrenceList)
                    {
                        uniqueWordOccurrences[i - 1] = currentElementOccurrenceList;
                        uniqueWordOccurrences[i] = previusElementOccurrenceList;
                        uniqueWords[i - 1] = currentElementWordList;
                        uniqueWords[i] = previusElementWordList;
                        swapped = true;
                    }
                }

                n -= 1;
            }
        }

        private static void GetUniqueOccurencesInList(List<string> uniqueStrings, List<string> originalStrings, List<int> uniqueOccurrences)
        {
            for (int i = 0; i < uniqueStrings.Count; i++)
            {
                var currentElement = uniqueStrings[i];

                int occurrenceCount = 0;
                for (int j = 0; j < originalStrings.Count; j++)
                {
                    var currentOccurence = originalStrings[j];
                    if (currentElement == currentOccurence)
                    {
                        occurrenceCount++;
                    }
                }

                uniqueOccurrences.Add(occurrenceCount);
            }
        }
    }
}
