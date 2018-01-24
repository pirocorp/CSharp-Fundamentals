using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3.Word_Count
{
    class Program
    {
        static void Main()
        {
            var words = File.ReadAllText("words.txt").ToLower().Split();
            var text = File.ReadAllText("input.txt").ToLower()
                .Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var wordCount = new Dictionary<string, int>();

            foreach (var word in words)
            {
                wordCount[word] = 0;
            }

            foreach (var word in text)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
            }

            wordCount = wordCount.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            var currentLines = new string[wordCount.Count];
            var i = 0;

            foreach (var word in wordCount)
            {
                var currentLine = $"{word.Key} - {word.Value}";
                currentLines[i] = currentLine;
                i++;
            }

            File.AppendAllLines("Output.txt", currentLines);
        }
    }
}
