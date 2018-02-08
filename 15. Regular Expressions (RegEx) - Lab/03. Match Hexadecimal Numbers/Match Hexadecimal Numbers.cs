namespace _03.Match_Hexadecimal_Numbers
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var pattern = @"\b(?:0x)?[0-9A-F]+\b";
            var numbersString = Console.ReadLine();
            var numbers = Regex.Matches(numbersString, pattern)
                .Cast<Match>()
                .Select(x => x.Value)
                .ToArray();

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}