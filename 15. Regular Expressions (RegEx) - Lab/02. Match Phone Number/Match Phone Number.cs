namespace _02.Match_Phone_Number
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var pattern = @"( |^)\+359(-| )2\2\d{3}\2\d{4}\b";
            var phones = Console.ReadLine();
            var phoneMatches = Regex.Matches(phones, pattern);

            var result = phoneMatches
                .Cast<Match>()
                .Select(x => x.Value.Trim())
                .ToArray();

            Console.WriteLine(String.Join(", ", result));
        }
    }
}