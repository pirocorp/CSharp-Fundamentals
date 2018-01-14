using System;

namespace _02.Average_Character_Delimiter
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            var originalStrings = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            var allCharacters = String.Empty;

            allCharacters = AppendStrings(originalStrings, allCharacters);
            int sumOfAllCharacters = SumStringCharacters(allCharacters);
            char delimeter = (char)Math.Floor(sumOfAllCharacters / (double)allCharacters.Length);

            if (delimeter >= 'a' && delimeter <= 'z')
            {
                delimeter -= (char)32;
            }

            Console.WriteLine(String.Join($"{delimeter}", originalStrings));
        }

        private static int SumStringCharacters(string allCharacters)
        {
            int sum = 0;

            for (int i = 0; i < allCharacters.Length; i++)
            {
                sum += allCharacters[i];
            }

            return sum;
        }

        private static string AppendStrings(string[] originalStrings, string allCharacters)
        {
            for (int i = 0; i < originalStrings.Length; i++)
            {
                allCharacters += originalStrings[i];
            }

            return allCharacters;
        }
    }
}
