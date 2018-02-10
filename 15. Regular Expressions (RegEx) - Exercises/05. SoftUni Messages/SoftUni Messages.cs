namespace _05.SoftUni_Messages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var inputString = Console.ReadLine();

            while (inputString != "Decrypt!")
            {
                var lengthOfMessage = Console.ReadLine();
                var pattern = $@"^\d+(?<message>[a-zA-Z]{{{lengthOfMessage}}})[^a-zA-Z\s]*(\d+)$";
                var match = Regex.Match(inputString, pattern);
                var allInput = match.Groups[0].Value;
                var message = match.Groups["message"].Value;
                var indexes = new List<int>();
                var indexMatches = Regex.Matches(allInput, "\\d")
                    .Cast<Match>()
                    .Select(x => x.Value)
                    .Select(int.Parse)
                    .ToList();
                indexes.AddRange(indexMatches);

                var result = string.Empty;

                for (var i = 0; i < indexes.Count; i++)
                {
                    var currentIndex = indexes[i];

                    if (currentIndex < message.Length)
                    {
                        var currentChar = message[currentIndex];
                        result += currentChar.ToString();
                    }
                }

                if (result != string.Empty)
                {
                    Console.WriteLine($"{message} = {result}");
                }

                inputString = Console.ReadLine();
            }
        }
    }
}
