namespace _13.Key_Replacer
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var keyString = Console.ReadLine();
            var keysPattern = @"(?<startKey>^[A-Za-z]+?)[|<\\].*[|<\\](?<endKey>[A-Za-z]+$)";
            var keys = Regex.Match(keyString, keysPattern);
            var startKey = keys.Groups["startKey"].Value;
            var endKey = keys.Groups["endKey"].Value;
            var textPattern = $@"{startKey}(?<stringResult>.*?){endKey}";
            var textString = Console.ReadLine();
            var strings = Regex.Matches(textString, textPattern)
                .Cast<Match>()
                .Select(x => x.Groups["stringResult"].Value)
                .ToArray();

            var resultedStringBuilder = new StringBuilder();

            for (var i = 0; i < strings.Length; i++)
            {
                var currentString = strings[i];
                resultedStringBuilder.Append(currentString);
            }

            var result = resultedStringBuilder.ToString();
            if (result.Length == 0)
            {
                Console.WriteLine($"Empty result");
            }
            else
            {
                Console.WriteLine(resultedStringBuilder.ToString());
            }
        }
    }
}