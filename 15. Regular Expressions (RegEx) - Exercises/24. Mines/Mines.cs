namespace _24.Mines
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Mines
    {
        static void Main()
        {
            var minePattern = @"<(?<mine>.{2})>";
            var inputLine = Console.ReadLine();
            var mines = Regex.Matches(inputLine, minePattern).Cast<Match>().ToArray();

            for (var i = mines.Length -1; i >= 0; i--)
            {
                var currentMine = mines[i];
                var minePower = Math.Abs(currentMine.Groups["mine"].Value[0] - currentMine.Groups["mine"].Value[1]);
                var startIndex = Math.Max(0, currentMine.Index - minePower);
                var endIndex = Math.Min(inputLine.Length, (currentMine.Index + currentMine.Length + minePower));
                var lenght = endIndex - startIndex;
                inputLine = inputLine.Remove(startIndex, lenght);
                inputLine = inputLine.Insert(startIndex, new string('_', lenght));
            }

            Console.WriteLine(inputLine);
        }
    }
}