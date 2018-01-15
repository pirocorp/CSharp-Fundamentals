using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Letter_Repetition
{
    class Program
    {
        static void Main()
        {
            var inputString = Console.ReadLine();

            var charDict = new Dictionary<char, int>();

            foreach (var character in inputString)
            {
                if (!charDict.ContainsKey(character))
                {
                    charDict.Add(character, 0);
                }

                charDict[character]++;
            }

            foreach (var character in charDict)
            {
                Console.WriteLine($"{character.Key} -> {character.Value}");
            }
        }
    }
}
