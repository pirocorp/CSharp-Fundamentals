using System;
using System.Collections.Generic;

namespace _04.Split_by_Word_Casing
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' };
            var words = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            var lowerCaseWords = new List<string>();
            var mixedCaseWords = new List<string>();
            var upperCaseWords = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (AllUpperCase(words[i]))
                {
                    upperCaseWords.Add(words[i]);
                }
                else if (AllLowerCase(words[i]))
                {
                    lowerCaseWords.Add(words[i]);
                }
                else
                {
                    mixedCaseWords.Add(words[i]);
                }
            }

            Console.WriteLine($"Lower-case: {String.Join(", ", lowerCaseWords)}");
            Console.WriteLine($"Mixed-case: {String.Join(", ", mixedCaseWords)}");
            Console.WriteLine($"Upper-case: {String.Join(", ", upperCaseWords)}");
        }

        private static bool AllLowerCase(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] < 'a' || word[i] > 'z')
                {
                    return false;
                }
            }

            return true;
        }

        private static bool AllUpperCase(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] < 'A' || word[i] > 'Z')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
