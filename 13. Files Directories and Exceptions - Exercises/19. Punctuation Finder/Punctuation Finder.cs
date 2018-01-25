using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _19.Punctuation_Finder
{
    class Program
    {
        static void Main()
        {
            var inputLines = File.ReadAllLines("sample_text.txt").ToList();
            var listOfChars = ".,!?:".ToCharArray().ToList();
            var resultedList = new List<char>();

            for (var i = 0; i < inputLines.Count; i++)
            {
                var currentLine = inputLines[i].ToCharArray();

                foreach (var character in currentLine)
                {
                    if (listOfChars.Contains(character))
                    {
                        resultedList.Add(character);
                    }
                }
            }
            
            Console.WriteLine(String.Join(", ", resultedList));
        }
    }
}
