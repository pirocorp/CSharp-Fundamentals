using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.Phonebook_Upgrade
{
    class Program
    {
        static void Main()
        {
            var phoneBook = new SortedDictionary<string, string>();
            var inputData = Console.ReadLine();

            while (inputData != "END")
            {
                var tokens = inputData.Split(' ');
                var command = tokens[0];

                switch (command)
                {
                    case "A":
                        var name = tokens[1];
                        var phoneNumber = tokens[2];
                        phoneBook[name] = phoneNumber;
                        break;
                    case "S":
                        name = tokens[1];

                        if (phoneBook.ContainsKey(name))
                        {
                            Console.WriteLine($"{name} -> {phoneBook[name]}");
                        }
                        else
                        {
                            Console.WriteLine($"Contact {name} does not exist.");
                        }
                        break;
                    case "ListAll":
                        phoneBook.ToList().ForEach(x => Console.WriteLine($"{x.Key} -> {x.Value}"));
                        break;
                }

                inputData = Console.ReadLine();
            }
        }
    }
}
