using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Odd_Occurrences
{
    class Program
    {
        static void Main()
        {
            var words = Console.ReadLine()
                .ToLower()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var wordCounts = new Dictionary<String, int>();

            foreach (var word in words)
            {
                if (!wordCounts.ContainsKey(word))
                {
                    wordCounts.Add(word, 0);
                }

                wordCounts[word]++;
            }

            var result = new List<string>();

            foreach (var wordCount in wordCounts)
            {
                if (wordCount.Value % 2 == 1)
                {
                    result.Add(wordCount.Key);
                }
            }

            Console.WriteLine(String.Join(", ", result));
        }
    }
}
