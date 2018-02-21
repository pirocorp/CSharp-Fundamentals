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
            var input = Console.ReadLine().ToUpper();
            const string pattern = @"(\D+?)(\d+)";
            var matches = Regex.Matches(input, pattern).Cast<Match>().ToArray();
            var result = new StringBuilder();

            for (var i = 0; i < matches.Length; i++)
            {
                var currentMatch = matches[i];
                var currentString = currentMatch.Groups[1].Value;
                var currentDigit = int.Parse(currentMatch.Groups[2].Value);

                for (var j = 0; j < currentDigit; j++)
                {
                    result.Append(currentString);
                }

            }

            Console.WriteLine($"Unique symbols used: {result.ToString().Distinct().Count()}");
            Console.WriteLine(result);
        }
    }
}