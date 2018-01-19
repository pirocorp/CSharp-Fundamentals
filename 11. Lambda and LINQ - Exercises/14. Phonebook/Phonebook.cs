using System;
using System.Collections.Generic;

namespace _14.Phonebook
{
    class Phonebook
    {
        static void Main()
        {
            var phoneBook = new Dictionary<string, string>();
            var inputData = Console.ReadLine();

            while (inputData != "END")
            {
                var tokens = inputData.Split(' ');
                var command = tokens[0];
                var name = tokens[1];

                switch (command)
                {
                    case "A":
                        var phoneNumber = tokens[2];
                        phoneBook[name] = phoneNumber;
                        break;
                    case "S":
                        if (phoneBook.ContainsKey(name))
                        {
                            Console.WriteLine($"{name} -> {phoneBook[name]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {name} does not exist.");
                        }
                        break;
                }

                inputData = Console.ReadLine();
            }

        }
    }
}
