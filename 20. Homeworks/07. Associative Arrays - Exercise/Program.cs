namespace _07._Associative_Arrays___Exercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main()
        {
            //Task01();
            //Task02();
            //Task03();
            Task04();
            //Task05();
            //Task06();
            //Task07();
            //Task08();
            //Task09();
            //Task10();
        }

        private static void Task01()
        {
            var occurrences = new Dictionary<char, int>();
            var input = Console.ReadLine() ?? string.Empty;

            foreach (var @char in input)
            {
                if (@char == ' ')
                {
                    continue;
                }

                if (!occurrences.ContainsKey(@char))
                {
                    occurrences.Add(@char, 0);
                }

                occurrences[@char]++;
            }

            foreach (var occurrence in occurrences)
            {
                Console.WriteLine($"{occurrence.Key} -> {occurrence.Value}");
            }
        }

        private static void Task02()
        {
            var resources = new Dictionary<string, long>();

            string resource;
            while ((resource = Console.ReadLine()) != "stop")
            {
                var quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(resource))
                {
                    resources.Add(resource, 0);
                }

                resources[resource] += quantity;
            }

            foreach (var res in resources)
            {
                Console.WriteLine($"{res.Key} -> {res.Value}");
            }
        }

        private static void Task03()
        {
            var materials = new Dictionary<string, int>();
            var items = new Dictionary<string, string>()
            {
                { "shards", "Shadowmourne" },
                { "motes", "Dragonwrath" },
                { "fragments", "Valanyr" },
            };

            items.ToList().ForEach(i => materials.Add(i.Key, 0));

            var isFinished = false;

            while (!isFinished)
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (var i = 0; i < tokens.Length; i += 2)
                {
                    var quantity = int.Parse(tokens[i]);
                    var materialName = tokens[i + 1].ToLower();

                    if (!materials.ContainsKey(materialName))
                    {
                        materials.Add(materialName, 0);
                    }

                    materials[materialName] += quantity;

                    var isObtainable = materials
                        .Where(m => m.Key.Equals("shards") || m.Key.Equals("fragments") || m.Key.Equals("motes"))
                        .Any(m => m.Value >= 250);

                    if (isObtainable)
                    {
                        var material = materials
                            .Where(m => m.Key.Equals("shards") || m.Key.Equals("fragments") || m.Key.Equals("motes"))
                            .First(m => m.Value >= 250);

                        materials[material.Key] -= 250;

                        Console.WriteLine($"{items[material.Key]} obtained!");

                        isFinished = true;
                        break;
                    }
                }
            }

            materials
                .Where(m => m.Key.Equals("shards") || m.Key.Equals("fragments") || m.Key.Equals("motes"))
                .OrderByDescending(m => m.Value)
                .ThenBy(m => m.Key)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));

            materials
                .Where(m => !m.Key.Equals("shards") && !m.Key.Equals("fragments") && !m.Key.Equals("motes"))
                .OrderBy(m => m.Key)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key}: {x.Value}"));
        }

        private static void Task04()
        {
            var products = new Dictionary<string, Product>();

            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var price = decimal.Parse(tokens[1]);
                var quantity = int.Parse(tokens[2]);

                if (!products.ContainsKey(name))
                {
                    var product = new Product(name, price);
                    products.Add(name, product);
                }
            }
        }

        private static void Task05()
        {

        }

        private static void Task06()
        {

        }

        private static void Task07()
        {

        }

        private static void Task08()
        {

        }

        private static void Task09()
        {

        }

        private static void Task10()
        {

        }

        public class Product
        {
            public Product(string name, decimal price)
            {
                this.Name = name;
                this.Price = price;
            }

            public string Name { get; set; }

            public decimal Price { get; set; }
        }
    }
}
