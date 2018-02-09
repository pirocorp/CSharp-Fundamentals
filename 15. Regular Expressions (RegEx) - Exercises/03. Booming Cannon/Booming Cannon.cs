namespace _03.Booming_Cannon
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var distance = numbers[0];
            var countOfElements = numbers[1];
            var inputString = Console.ReadLine();
            var cannonPatern = @"\\<<<";
            var isMatch = Regex.IsMatch(inputString, cannonPatern);
            var matches = new [] {-1};
            var resultedStrings = new List<string>();

            if (isMatch)
            {
                matches = Regex.Matches(inputString, cannonPatern)
                    .Cast<Match>()
                    .Select(x => x.Index)
                    .ToArray();
            }

            if (matches[0] >= 0)
            {
                for (int i = 0; i < matches.Length; i++)
                {
                    var currentMatchIndex = matches[i];
                    var currentStartIndex = currentMatchIndex + cannonPatern.Length;
                    var currentSubStringStartIndex = currentStartIndex + distance - 1;

                    if (currentSubStringStartIndex >= inputString.Length)
                    {
                        break;
                    }

                    var currentCountOfElements = countOfElements;

                    if ((i + 1) < matches.Length)
                    {
                        if (currentSubStringStartIndex + currentCountOfElements >= matches[i + 1])
                        {
                            currentCountOfElements = Math.Max(matches[i + 1] - currentSubStringStartIndex, 0);
                        }
                    }

                    if (currentSubStringStartIndex + currentCountOfElements >= inputString.Length)
                    {
                        currentCountOfElements = Math.Max(inputString.Length - currentSubStringStartIndex, 0);
                    }

                    var currentSubString = inputString.Substring(currentSubStringStartIndex, currentCountOfElements);
                    resultedStrings.Add(currentSubString);
                }
            }
            //else
            //{
            //    Console.WriteLine("Not found");
            //}

            resultedStrings = resultedStrings.Where(x => x.Length > 0).ToList();
            Console.WriteLine(String.Join("/\\", resultedStrings));
        }
    }
}