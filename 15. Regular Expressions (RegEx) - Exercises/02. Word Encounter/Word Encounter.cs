namespace _02.Word_Encounter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var filter = Console.ReadLine();
            var letter = filter[0];
            var digit = int.Parse(new string(filter[1], 1));
            var inputSentence = Console.ReadLine();
            var validSentence = @"(?<!.)[A-Z].*[.!?](?!.)"; //negative lookbehind and negative lookahead (nothing before and after)
            var letters = new string(letter, digit).ToCharArray();
            var wordPattern = string.Empty;

            if (digit > 0)
            {
                wordPattern = $"\\w*{string.Join("\\w*", letters)}\\w*";
            }
            else
            {
                wordPattern = @"\w+";
            }

            var allMatchedWords = new List<string>();

            while (inputSentence != "end")
            {
                var isMatch = Regex.IsMatch(inputSentence, validSentence);

                if (isMatch)
                {
                    var words = Regex.Matches(inputSentence, wordPattern).Cast<Match>().Select(x => x.Value).ToList();
                    allMatchedWords.AddRange(words);
                }

                inputSentence = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", allMatchedWords));
        }
    }
}