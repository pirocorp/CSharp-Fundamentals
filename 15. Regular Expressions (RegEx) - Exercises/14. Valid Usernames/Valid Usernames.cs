namespace _14.Valid_Usernames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var delimeterList = @" /\()".ToCharArray();
            var possibleUsernames = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();
            var usernameRegex = new Regex(@"^[A-Za-z][A-Za-z0-9_]{2,25}$");
            var verifiedUsernames = new List<string>();

            for (var i = 0; i < possibleUsernames.Length; i++)
            {
                var currentUsername = possibleUsernames[i];

                if (usernameRegex.IsMatch(currentUsername))
                {
                    verifiedUsernames.Add(currentUsername);
                }
            }

            var indexOfBest = -1;
            var bestSum = 0;

            for (var i = 0; i < verifiedUsernames.Count - 1; i++)
            {
                var currentSum = verifiedUsernames[i].Length + verifiedUsernames[i + 1].Length;

                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    indexOfBest = i;
                }
            }

            Console.WriteLine(verifiedUsernames[indexOfBest]);
            Console.WriteLine(verifiedUsernames[indexOfBest + 1]);
        }
    }
}