namespace _14.Rage_Quit
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            const string pattern = @"((?<string>[^\d]+)(?<digit>\d+))";
            var resultedString = new StringBuilder();
            var matches = Regex.Matches(input, pattern).Cast<Match>().ToArray();

            for (var i = 0; i < matches.Length; i++)
            {
                var currentMatch = matches[i];
                var currentString = currentMatch.Groups["string"].Value.ToUpper();
                var currentDigit = int.Parse(currentMatch.Groups["digit"].Value);
                resultedString.Append(string.Join("", Enumerable.Repeat(currentString, currentDigit)));
            }

            Console.WriteLine($"Unique symbols used: {resultedString.ToString().Distinct().Count()}");
            Console.WriteLine(resultedString);
        }
    }
}