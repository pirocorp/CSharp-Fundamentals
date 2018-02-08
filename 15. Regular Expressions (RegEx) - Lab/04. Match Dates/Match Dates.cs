namespace _04.Match_Dates
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var pattern = @"\b(?<day>\d{2})(.|-|\/)(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            var datesString = Console.ReadLine();
            var dates = Regex.Matches(datesString, pattern);

            foreach (Match date in dates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}