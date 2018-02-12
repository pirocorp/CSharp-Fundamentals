using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _16.Use_Your_Chains__Buddy
{
    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine();
            var inputRegex = new Regex(@"<p>(?<inputString>.+?)</p>", RegexOptions.CultureInvariant);
            var matches = inputRegex.Matches(inputData);
            var inputStrings = matches.Cast<Match>().Select(x => x.Groups["inputString"].Value).ToArray();
            var inputString = string.Join("", inputStrings);
            var replaceWithSpace = @"[^a-z0-9]";
            inputString = Regex.Replace(inputString, replaceWithSpace, " ");
            inputString = Regex.Replace(inputString, @"\s+", " ").Trim();

            var result = new StringBuilder();

            for (var i = 0; i < inputString.Length; i++)
            {
                var currentChar = inputString[i];

                if (currentChar >= 'a' && currentChar <= 'm')
                {
                    currentChar += (char)13;
                }
                else if (currentChar >= 'n' && currentChar <= 'z')
                {
                    currentChar -= (char)13;
                }

                result.Append(currentChar);
            }

            Console.WriteLine(result);
        }
    }
}
