namespace _10.Serialize_String
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var inputString = Console.ReadLine();
            var charOccurances = new Dictionary<char, List<int>>();

            for (int i = 0; i < inputString.Length; i++)
            {
                if (!charOccurances.ContainsKey(inputString[i]))
                {
                    charOccurances[inputString[i]] = new List<int>();
                }

                charOccurances[inputString[i]].Add(i);
            }

            foreach (var character in charOccurances)
            {
                var listOfOccurances = character.Value;
                Console.WriteLine($"{character.Key}:{String.Join("/", listOfOccurances)}");
            }
        }
    }
}
