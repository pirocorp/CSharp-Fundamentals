using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _09.Extract_Emails
{
    class Program
    {
        static void Main()
        {
            var pattern = @"\b(?<![\-,.])[a-z0-9]+[\-._]*[a-z0-9]+@([a-z]+-*[a-z]+)(\.[a-z]+-*[a-z]+)+";
            var inputData = Console.ReadLine();
            var matches = Regex.Matches(inputData, pattern);
            var result = matches.Cast<Match>().Select(x => x.Value).ToList();
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
