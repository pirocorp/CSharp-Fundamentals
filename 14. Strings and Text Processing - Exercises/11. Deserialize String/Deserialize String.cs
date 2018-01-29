namespace _11.Deserialize_String
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var charListOfOccurances = new Dictionary<char, List<int>>();

            while (inputLine != "end")
            {
                var tokens = inputLine.Split(':');
                var character = tokens[0].First();
                var listOfOccurances = tokens[1].Split('/').Select(int.Parse).ToList();
                charListOfOccurances[character] = listOfOccurances;
                inputLine = Console.ReadLine();
            }

            var numberOfAllCharactersInString = charListOfOccurances.Values.Sum(x => x.Count);
            var charArray = new char[numberOfAllCharactersInString];

            foreach (var characer in charListOfOccurances)
            {
                var currentChar = characer.Key;
                var currentCharOccurances = characer.Value;

                for (int i = 0; i < currentCharOccurances.Count; i++)
                {
                    var currentIndex = currentCharOccurances[i];
                    charArray[currentIndex] = currentChar;
                }
            }

            var result = new string(charArray);
            Console.WriteLine(result);
        }
    }
}