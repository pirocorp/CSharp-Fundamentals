namespace _20.Morse_Code_Upgraded
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            const string pattern = @"(?<cryptedLetter>\d+)";
            var inputLine = Console.ReadLine();
            var cryptedLetters = Regex.Matches(inputLine, pattern)
                .Cast<Match>()
                .Select(x => x.Groups["cryptedLetter"].Value)
                .ToArray();
            var result = new StringBuilder();

            for (var i = 0; i < cryptedLetters.Length; i++)
            {
                var regex = new Regex("(?<zeroGroup>0{2,})|(?<oneGroup>1{2,})");
                char currentChar = CharDecode(cryptedLetters[i], regex);
                result.Append(currentChar);
            }

            Console.WriteLine(result);
        }

        private static char CharDecode(string cryptedLetter, Regex regex)
        {
            var sum = 0;
            var zeros = cryptedLetter.Count(x => x == '0');
            var ones = cryptedLetter.Count(x => x == '1');
            var consecutiveEqualDigits = regex.Matches(cryptedLetter).Cast<Match>().Select(x => x.Length).ToArray().Sum();
            sum = zeros * 3 + ones * 5 + consecutiveEqualDigits;
            return (char)sum;
        }
    }
}
