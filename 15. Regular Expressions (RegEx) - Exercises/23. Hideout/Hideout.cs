namespace _23.Hideout
{
    using System;
    using System.Text.RegularExpressions;

    class Hideout
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            while (true)
            {
                var tokens = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                var character = tokens[0];
                var count = int.Parse(tokens[1]);
                var search = $"\\{character}{{{count},}}";
                var regex = new Regex(search);

                if (regex.IsMatch(inputLine))
                {
                    var indexAtFound = regex.Match(inputLine).Index;
                    var sizeOfFound = regex.Match(inputLine).Length;
                    Console.WriteLine($"Hideout found at index {indexAtFound} and it is with size {sizeOfFound}!");
                    break;
                }
            }
        }
    }
}