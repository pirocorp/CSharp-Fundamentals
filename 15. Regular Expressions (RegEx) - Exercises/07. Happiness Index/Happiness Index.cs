namespace _07.Happiness_Index
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var happyEmojiPattern = @"(\:\)|\:D|\;\)|\:\*|\:\]|\;\]|\:\}|\;\}|\(\:|\*\:|c\:|\[\:|\[\;)";
            var sadEmojiPattern = @"(\:\(|D\:|\;\(|\:\[|\;\[|\:\{|\;\{|\)\:|\:c|\]\:|\]\;)";
            var inputLine = Console.ReadLine();
            var happyCount = Regex.Matches(inputLine, happyEmojiPattern).Count;
            var sadCount = Regex.Matches(inputLine, sadEmojiPattern).Count;
            var happinessIndex = happyCount / (double) sadCount;
            var emoji = string.Empty;

            if (happinessIndex >= 2)
            {
                emoji = ":D";
            }
            else if (happinessIndex > 1)
            {
                emoji = ":)";
            }
            else if (happinessIndex == 1)
            {
                emoji = ":|";
            }
            else
            {
                emoji = ":(";
            }

            Console.WriteLine($"Happiness index: {happinessIndex:F2} {emoji}");
            Console.WriteLine($"[Happy count: {happyCount}, Sad count: {sadCount}]");
        }
    }
}