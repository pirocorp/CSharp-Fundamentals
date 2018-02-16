using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _23.Hideout
{
    class Hideout
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            while (true)
            {
                var tokens = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                var character = tokens[0];
                var count = int.Parse(tokens[1]);
                var search = $"\\{character}{{{count},}}";
                var regex = new Regex(search);

                if (regex.IsMatch(inputLine))
                {
                    var indexAtFound = regex.Match(inputLine).Index;
                    var sizeOfFound = GetSize(inputLine.Substring(indexAtFound));
                    Console.WriteLine($"Hideout found at index {indexAtFound} and it is with size {sizeOfFound}!");
                    break;
                }
            }
        }

        private static int GetSize(string substring)
        {
            var result = 1;
            var character = substring[0];

            for (var i = 1; i < substring.Length; i++)
            {
                if (substring[i] == character)
                {
                    result++;
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
