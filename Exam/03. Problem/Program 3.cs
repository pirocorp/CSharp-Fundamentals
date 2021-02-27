namespace _03._Problem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            string input;

            var messages = new List<string>();

            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToList();
                var command = tokens[0];
                var message = tokens[1];

                switch (command)
                {
                    case "Chat":
                        messages.Add(message);
                        break;
                    case "Delete":
                        messages.Remove(message);
                        break;
                    case "Edit":
                        var index = messages.IndexOf(message);
                        var target = tokens[2];

                        if (index < 0) continue;

                        messages[index] = target;
                        break;
                    case "Pin":
                        index = messages.IndexOf(message);

                        if (index < 0) continue;

                        var swap = messages[index];
                        messages.RemoveAt(index);
                        messages.Add(swap);
                        break;
                    case "Spam":
                        messages.AddRange(tokens.Skip(1));
                        break;
                }
            }

            messages.ForEach(Console.WriteLine);
        }
    }
}
