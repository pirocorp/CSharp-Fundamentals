using System;
using System.Text.RegularExpressions;

namespace _06.Replace_a_Tag
{
    class Program
    {
        static void Main()
        {
            var pattern = @"<a.*?href.*?=(.*)>(.*?)<\/a>";
            var replacement = @"[URL href=$1]$2[/URL]";
            var inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                var replaced = Regex.Replace(inputLine, pattern, replacement);
                Console.WriteLine(replaced);
                inputLine = Console.ReadLine();
            }

        }
    }
}