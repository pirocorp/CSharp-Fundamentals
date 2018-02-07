using System;
using System.Collections.Generic;
using System.Linq;

namespace _20.Magic_exchangeable_words
{
    class Program
    {
        static void Main()
        {
            var tokens = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var string1 = tokens[0];
            var string2 = tokens[1];

            var result = IsExchangeable(string1, string2);
            Console.WriteLine(result.ToString().ToLower());
        }

        private static bool IsExchangeable(string string1, string string2)
        {
            var chars = new Dictionary<char, char>();
            var minLength = Math.Min(string1.Length, string2.Length);

            for (var i = 0; i < minLength; i++)
            {
                var currentCharacter = string1[i];

                if (!chars.ContainsKey(currentCharacter))
                {
                    chars[currentCharacter] = string2[i];
                }
                else
                {
                    if (chars[currentCharacter] != string2[i])
                    {
                        return false;
                    }
                }
            }

            var distinctElementsInFIrstString = string1.ToCharArray().Distinct().ToArray().Length;
            var distinctElementsInSecondString = string2.ToCharArray().Distinct().ToArray().Length;

            if (distinctElementsInFIrstString != distinctElementsInSecondString)
            {
                return false;
            }

            return true;
        }
    }
}