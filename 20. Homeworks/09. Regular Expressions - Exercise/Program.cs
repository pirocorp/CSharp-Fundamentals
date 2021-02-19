namespace _09._Regular_Expressions___Exercise
{
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main()
        {
            //Task01();
            //Task02();
            //Task03();
            //Task04();
            Task05();
            //Task06();
        }

        private static void Task01()
        {
            var pattern = "(>>)(?<furniture>[A-Za-z]+)(<<)(?<price>\\d+(\\.\\d+)?)!(?<quantity>\\d+)";
            var regex = new Regex(pattern);

            var furnitures = new List<string>();
            var sum = 0M;

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                var match = regex.Match(input);

                if (match.Success)
                {
                    var furniture = match.Groups["furniture"].Value;
                    var price = decimal.Parse(match.Groups["price"].Value);
                    var quantity = int.Parse(match.Groups["quantity"]?.Value ?? "0");

                    furnitures.Add(furniture);
                    sum += price * quantity;
                }
            }

            Console.WriteLine("Bought furniture:");
            foreach (var furniture in furnitures)
            {
                Console.WriteLine(furniture);
            }

            Console.WriteLine($"Total money spend: {sum:F2}");
        }

        private static void Task02()
        {
            var participants = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).ToDictionary(x => x.Trim(), x => 0);
            var letters = new Regex("[A-Za-z]+[^A-Za-z]*?");
            var digits = new Regex("[0-9][^0-9]*?");

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                var name = GetName(letters, input);
                var sum = GetDistance(digits, input);

                if (participants.ContainsKey(name))
                {
                    participants[name] += sum;
                }
            }

            var i = 0;
            var positions = new[] { "1st", "2nd", "3rd" };
            participants
                .OrderByDescending(x => x.Value)
                .Take(3)
                .ToList()
                .ForEach(x => Console.WriteLine($"{positions[i++]} place: {x.Key.Trim()}"));
        }

        private static int GetDistance(Regex digits, string input)
        {
            var matches = digits.Matches(input);

            var sum = 0;

            foreach (Match match in matches)
            {
                sum += int.Parse(match.Value);
            }

            return sum;
        }

        private static string GetName(Regex letters, string input)
        {
            var matches = letters.Matches(input);
            var sb = new StringBuilder();

            foreach (Match x in matches)
            {
                sb.Append(x.Value.Trim());
            }

            return sb.ToString().Trim();
        }

        private static void Task03()
        {
            var pattern = ".*?%(?<customer>[A-Z][a-z]+)%.*?<(?<product>\\w+)>.*?\\|(?<count>\\d+)\\|.*?(?<price>\\d+(\\.\\d+)?)\\$";
            var regex = new Regex(pattern);

            var income = 0M;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                var match = regex.Match(input);

                if (match.Success)
                {
                    var customer = match.Groups["customer"].Value;
                    var product = match.Groups["product"].Value;
                    var count = int.Parse(match.Groups["count"].Value);
                    var price = decimal.Parse(match.Groups["price"].Value);

                    var total = price * count;
                    Console.WriteLine($"{customer}: {product} - {total:F2}");

                    income += total;
                }
            }

            Console.WriteLine($"Total income: {income:F2}");
        }

        private static void Task04()
        {
            var pattern = "(.*?)@(?<name>[a-zA-Z]+)([^@\\-!:>]*?):(?<population>\\d+)([^@\\-!:>]*?)!(?<attack>[A,D])!([^@\\-!:>]*?)->(?<solders>\\d+)";
            var regex = new Regex(pattern);
            
            var inputs = ReadInput();

            var attacked = new List<string>();
            var destroyed = new List<string>();

            for (var i = 0; i < inputs.Count; i++)
            {
                var match = regex.Match(inputs[i]);

                if (match.Success)
                {
                    var planet = match.Groups["name"].Value;
                    var attack = match.Groups["attack"].Value;

                    if (attack == "A")
                    {
                        attacked.Add(planet);
                    }
                    else
                    {
                        destroyed.Add(planet);
                    }
                }
            }

            Console.WriteLine($"Attacked planets: {attacked.Count}");
            attacked
                .OrderBy(x => x)
                .ToList()
                .ForEach(x => Console.WriteLine($"-> {x}"));

            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            destroyed
                .OrderBy(x => x)
                .ToList()
                .ForEach(x => Console.WriteLine($"-> {x}"));
        }

        private static List<string> ReadInput()
        {
            var n = int.Parse(Console.ReadLine());

            var inputs = new List<string>();

            for (var i = 0; i < n; i++)
            {
                var crypto = Console.ReadLine() ?? string.Empty;
                var decrypt = new List<char>();

                var key = crypto.ToLower().Count(x => x == 's' || x == 't' || x == 'a' || x == 'r');

                for (var j = 0; j < crypto.Length; j++)
                {
                    var currentChar = (char) (crypto[j] - key);
                    decrypt.Add(currentChar);
                }

                inputs.Add(new string(decrypt.ToArray()));
            }

            return inputs;
        }

        private static void Task05()
        {
            throw new System.NotImplementedException();
        }

        private static void Task06()
        {
            throw new System.NotImplementedException();
        }
    }
}
