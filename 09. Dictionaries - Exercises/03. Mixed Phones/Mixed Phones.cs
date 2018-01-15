using System;
using System.Collections.Generic;

namespace _03.Mixed_Phones
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var phoneBook = new SortedDictionary<string, long>();

            while (input != "Over")
            {
                var inputStrings = input.Split(new[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                var inputOne = inputStrings[0].Trim();
                var inputTwo = inputStrings[1].Trim();
                var name = string.Empty;
                long value = 0;

                if (long.TryParse(inputOne, out value))
                {
                    name = inputTwo;
                }
                else if (long.TryParse(inputTwo, out value))
                {
                    name = inputOne;
                }

                phoneBook[name] = value;
                input = Console.ReadLine();
            }

            foreach (var name in phoneBook)
            {
                Console.WriteLine($"{name.Key} -> {name.Value}");
            }
        }
    }
}
