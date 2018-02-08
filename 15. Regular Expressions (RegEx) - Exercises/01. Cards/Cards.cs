namespace _01.Cards
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Cards
    {
        static void Main()
        {
            var pattern = @"(^|(?<=[A-Z]))(?<power>[AKQJ]|10|[2-9])(?<suit>[SHDC])"; //positive lookbehind

            var inputString = Console.ReadLine();
            var matches = Regex.Matches(inputString, pattern);
            var cards = matches.Cast<Match>().Select(x => x.Value).ToArray();
            Console.WriteLine(String.Join(", ", cards));
        }
    }
}