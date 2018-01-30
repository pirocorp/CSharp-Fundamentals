namespace _14.Pyramidic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Pyramidic
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var characterOccurances = new Dictionary<char, int>();

            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();

                for (int j = 0; j < inputLine.Distinct().ToArray().Length; j++)
                {
                    var currentChar = inputLine.Distinct().ToArray()[j];
                    CountCurrentChar(currentChar, characterOccurances, inputLine);
                }
            }

            var maxPyramid = characterOccurances.OrderByDescending(x => x.Value).First();
            var count = maxPyramid.Value;
            var character = maxPyramid.Key;

            for (int i = 1; i <= count; i += 2)
            {
                Console.WriteLine(new string(character, i));
            }
        }

        private static void CountCurrentChar(char currentChar, Dictionary<char, int> characterOccurances, string inputLine)
        {
            var count = 0;

            for (int i = 0; i < inputLine.Length; i++)
            {
                if (inputLine[i] == currentChar)
                {
                    count++;
                }
            }

            if (!characterOccurances.ContainsKey(currentChar))
            {
                characterOccurances[currentChar] = 1;
                return;
            }

            if (characterOccurances.ContainsKey(currentChar) && characterOccurances[currentChar] + 2 <= count)
            {
                characterOccurances[currentChar] += 2;
            }

        }
    }
}