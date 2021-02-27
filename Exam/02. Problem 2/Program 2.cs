namespace _02._Problem_2
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var sequence = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string input;

            while ((input = Console.ReadLine()) != "Mort")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                var value = int.Parse(tokens[1]);

                switch (command)
                {
                    case "Add":
                        sequence.Add(value);
                        break;
                    case "Remove":
                        sequence.RemoveAt(sequence.IndexOf(value));
                        break;
                    case "Replace":
                        var index = sequence.IndexOf(value);
                        var target = int.Parse(tokens[2]);

                        if(index < 0) continue;

                        sequence[index] = target;
                        break;
                    case "Collapse":
                        sequence = sequence.Where(x => x >= value).ToList();
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", sequence));
        }
    }
}
