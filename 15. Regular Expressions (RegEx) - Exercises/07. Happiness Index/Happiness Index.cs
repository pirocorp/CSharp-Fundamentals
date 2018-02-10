namespace _07.Happiness_Index
{
    using System;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            const string happyEmojiPattern = @"(\:\)|\:D|\;\)|\:\*|\:\]|\;\]|\:\}|\;\}|\(\:|\*\:|c\:|\[\:|\[\;)";
            const string sadEmojiPattern = @"(\:\(|D\:|\;\(|\:\[|\;\[|\:\{|\;\{|\)\:|\:c|\]\:|\]\;)";
            var inputLine = Console.ReadLine();
            var happyCount = Regex.Matches(inputLine, happyEmojiPattern).Count;
            var sadCount = Regex.Matches(inputLine, sadEmojiPattern).Count;
            var happinessIndex = happyCount / (double) sadCount;
            string emoji;

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