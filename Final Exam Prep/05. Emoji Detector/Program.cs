namespace _05._Emoji_Detector
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            const string digitsPattern = "(?<digits>\\d)";
            const string emojiPatterm = /*"([:]{2}|[*]{2})(?<emoji>[A-Z][a-z]{2,})\\1";*/
            "(?<emoji>([*]{2})[A-Z][a-z]{2,}([*]{2})|([:]{2})[A-Z][a-z]{2,}([:]{2}))";

            var input = Console.ReadLine();

            var emojiRegex = new Regex(emojiPatterm);

            var emojies = new List<string>();

            foreach (Match match in emojiRegex.Matches(input))
            {
                emojies.Add(match.Value);
            }

            var digitsRegex = new Regex(digitsPattern);
            var coolThreshold = 1L;

            foreach (Match match in digitsRegex.Matches(input))
            {
                coolThreshold *= int.Parse(match.Groups["digits"].Value);
            }

            var coolEmojies = emojies
                .Where(e => e.Skip(2).Take(e.Length - 4).Sum(e => e) > coolThreshold)
                .ToList();

            Console.WriteLine($"Cool threshold: {coolThreshold}");
            Console.WriteLine($"{emojies.Count} emojis found in the text. The cool ones are:");
            foreach (var coolEmojy in coolEmojies)
            {
                Console.WriteLine(coolEmojy);
            }
        }
    }
}
