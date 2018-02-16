namespace _21.Only_Letters
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var pattern = @"(?<digit>\d+)(?<letter>[a-zA-Z])";
            var regex = new Regex(pattern);
            var matches = regex.Matches(inputLine);
            var digits = matches.Cast<Match>().Select(x => x.Groups["digit"].Value).ToArray();
            var letters = matches.Cast<Match>().Select(x => x.Groups["letter"].Value).ToArray();

            for (var i = 0; i < digits.Length; i++)
            {
                var currentDigit = digits[i];
                var currentLetter = letters[i];
                inputLine = Regex.Replace(inputLine, currentDigit, currentLetter);
            }

            Console.WriteLine(inputLine);
        }
    }
}