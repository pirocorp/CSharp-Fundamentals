namespace _07.Capitalize_Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var words = new List<String>();
            var inputData = Console.ReadLine();

            while (inputData != "end")
            {
                var sentence = inputData.Split(new[] { ' ', '.', ',', ':', ';', '?', '!', '-', '_' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                sentence = WordsCapitalization(sentence);
                words.AddRange(sentence);
                Console.WriteLine(String.Join(", ", sentence));
                inputData = Console.ReadLine();
            }

            //Console.WriteLine(String.Join(", ", words));
        }

        private static List<string> WordsCapitalization(List<string> sentence)
        {
            var currentWords = new List<String>();
            var words = new List<string>();

            for (var i = 0; i < sentence.Count; i++)
            {
                currentWords = sentence[i].Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                for (int j = 0; j < currentWords.Count; j++)
                {
                    var currentWord = Capitalization(currentWords[j]);
                    words.Add(currentWord);
                }
            }
            
            return words;
        }

        private static string Capitalization(string s)
        {
            var result = s.ToLower();
            result = new String(result.ToUpper().Take(1).ToArray()) + new String(result.Skip(1).ToArray());
            return result.Trim();
        }
    }
}
