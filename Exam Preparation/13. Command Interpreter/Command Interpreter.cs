namespace _13.Command_Interpreter
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var strings = Regex.Split(Console.ReadLine(), @"\s+").Where(s => s.Length > 0).ToList();
            var command = Console.ReadLine();

            while (command != "end")
            {
                var tokens = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var currentCommand = tokens[0];

                switch (currentCommand)
                {
                    case "reverse":
                        var start = int.Parse(tokens[2]);
                        var count = int.Parse(tokens[4]);
                        var startIsInside = start >= 0 && start < strings.Count;
                        var countIsInside = start + count <= strings.Count && count >= 0;

                        if (startIsInside && countIsInside)
                        {
                            strings.Reverse(start, count);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;
                    case "sort":
                        start = int.Parse(tokens[2]);
                        count = int.Parse(tokens[4]);
                        startIsInside = start >= 0 && start < strings.Count;
                        countIsInside = start + count <= strings.Count && count >= 0;

                        if (startIsInside && countIsInside)
                        {
                            strings.Sort(start, count, StringComparer.InvariantCulture);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;
                    case "rollLeft":
                        count = int.Parse(tokens[1]) % strings.Count;

                        if (count >= 0)
                        {
                            RollLeft(strings, count);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }

                        break;
                    case "rollRight":
                        count = int.Parse(tokens[1]) % strings.Count;

                        if (count >= 0)
                        {
                            RollRight(strings, count);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input parameters.");
                        }
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"[{string.Join(", ", strings)}]");
        }

        private static void RollRight(List<string> strings, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var lastElement = strings[strings.Count - 1];

                for (var j = strings.Count - 1; j > 0; j--)
                {
                    strings[j] = strings[j - 1];
                }

                strings[0] = lastElement;
            }
        }

        private static void RollLeft(List<string> strings, int count)
        {
            for (var i = 0; i < count; i++)
            {
                var firstElement = strings[0];

                for (var j = 0; j < strings.Count - 1; j++)
                {
                    strings[j] = strings[j + 1];
                }

                strings[strings.Count - 1] = firstElement;
            }
        }
    }
}