namespace _04._Activation
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var rawActivationKey = Console.ReadLine();

            string input;

            while ((input = Console.ReadLine()) != "Generate")
            {
                var tokens = input.Split(">>>");

                var command = tokens[0];

                switch (command)
                {
                    case "Contains":
                        Contains(tokens, rawActivationKey);
                        break;
                    case "Flip":
                        rawActivationKey = Flip(tokens, rawActivationKey);
                        Console.WriteLine(rawActivationKey);
                        break;
                    case "Slice":
                        rawActivationKey = Slice(tokens, rawActivationKey);
                        Console.WriteLine(rawActivationKey);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {rawActivationKey}");
        }

        private static string Slice(string[] tokens, string rawActivationKey)
        {
            var startIndex = int.Parse(tokens[1]);
            var endIndex = int.Parse(tokens[2]);

            return rawActivationKey.Remove(startIndex, endIndex - startIndex);
        }

        private static string Flip(string[] tokens, string rawActivationKey)
        {
            var subCommand = tokens[1];
            var startIndex = int.Parse(tokens[2]);
            var endIndex = int.Parse(tokens[3]);

            var substring = rawActivationKey?.Substring(startIndex, endIndex - startIndex);
            string converted;

            if (subCommand == "Upper")
            {
                converted = substring?.ToUpper();
            }
            else
            {
                converted = substring?.ToLower();
            }

            return rawActivationKey?.Replace(substring, converted);
        }

        private static void Contains(string[] tokens, string rawActivationKey)
        {
            var substring = tokens[1];

            if (rawActivationKey?.Contains(substring) ?? false)
            {
                Console.WriteLine($"{rawActivationKey} contains {substring}");
                return;
            }

            Console.WriteLine($"Substring not found!");
        }
    }
}
