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
            //Task04();
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

                products[name].Quantity += quantity;
                products[name].Price = price;
            }

            products
                .Values
                .ToList()
                .ForEach(p => Console.WriteLine($"{p.Name} -> {(p.Quantity * p.Price):F2}"));
        }

        private static void Task05()
        {
            var n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, string>();

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var username = tokens[1];

                switch (tokens.Length)
                {
                    case 2:
                        if (dict.ContainsKey(username))
                        {
                            dict.Remove(username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        else
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        break;
                    case 3:
                        if (dict.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {dict[username]}");
                        }
                        else
                        {
                            var licensePlate = tokens[2];
                            dict.Add(username, licensePlate);
                            Console.WriteLine($"{username} registered {licensePlate} successfully");
                        }
                        break;
                }
            }

            dict
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Key} => {x.Value}"));
        }

        private static void Task06()
        {
            var courses = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input.Split(" : ");
                var course = tokens[0];
                var student = tokens[1];

                if (!courses.ContainsKey(course))
                {
                    courses.Add(course, new List<string>());
                }

                courses[course].Add(student);
            }

            courses = courses
                .OrderByDescending(c => c.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var course in courses)
            {
                var name = course.Key;
                var students = course.Value
                    .OrderBy(s => s)
                    .ToList();

                Console.WriteLine($"{name}: {students.Count}");
                students.ForEach(s => Console.WriteLine($"-- {s}"));
            }
        }

        private static void Task07()
        {
            var n = int.Parse(Console.ReadLine());
            var students = new Dictionary<string, List<double>>();

            for (var i = 0; i < n; i++)
            {
                var student = Console.ReadLine();
                var grade = double.Parse(Console.ReadLine());

                if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<double>());
                }

                students[student].Add(grade);
            }

            students
                .Select(s => new 
                {
                    Name = s.Key,
                    Grade = s.Value.Average()
                })
                .Where(s => s.Grade >= 4.5)
                .OrderByDescending(s => s.Grade)
                .ToList()
                .ForEach(s => Console.WriteLine($"{s.Name} -> {s.Grade:F2}"));
        }

        private static void Task08()
        {
            var dict = new Dictionary<string, HashSet<string>>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                var company = tokens[0];
                var id = tokens[1];

                if (!dict.ContainsKey(company))
                {
                    dict.Add(company, new HashSet<string>());
                }

                dict[company].Add(id);
            }

            dict = dict
                .OrderBy(c => c.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var company in dict)
            {
                Console.WriteLine(company.Key);

                foreach (var id in company.Value)
                {
                    Console.WriteLine($"-- {id}");
                }
            }
        }

        private static void Task09()
        {
            // sides, users
            var forceUsers = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                var tokens = input.Split(new[] {" | ", " -> "}, StringSplitOptions.RemoveEmptyEntries);
                var side = tokens[0];
                var user = tokens[1];

                if (input.Contains("|"))
                {
                    var users = forceUsers.SelectMany(x => x.Value).ToList();

                    if (users.Contains(user))
                    {
                        continue;
                    }

                    RegisterForceUser(forceUsers, user, side);
                }
                else
                {
                    side = tokens[1];
                    user = tokens[0];

                    if (!forceUsers.ContainsKey(side))
                    {
                        forceUsers.Add(side, new List<string>());
                    }

                    foreach (var currentSide in forceUsers)
                    {
                        currentSide.Value.Remove(user);
                    }

                    forceUsers[side].Add(user);
                    Console.WriteLine($"{user} joins the {side} side!");
                }
            }

            var sides = forceUsers
                .Select(x => new { Name = x.Key, Members = x.Value.OrderBy(x => x).ToList() })
                .Where(x => x.Members.Count > 0)
                .OrderByDescending(u => u.Members.Count)
                .ThenBy(u => u.Name)
                .ToList();

            foreach (var side in sides)
            {
                Console.WriteLine($"Side: {side.Name}, Members: {side.Members.Count}");

                foreach (var member in side.Members)
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }

        private static void RegisterForceUser(Dictionary<string, List<string>> forceUsers, string user, string side)
        {
            if (!forceUsers.ContainsKey(side))
            {
                forceUsers.Add(side, new List<string>());
            }

            forceUsers[side].Add(user);
        }

        private static void Task10()
        {
            var banned = new HashSet<string>();
            var languages = new Dictionary<string, int>();
            var users = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                var tokens = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                var username = tokens[0];

                if (tokens.Length == 2)
                {
                    banned.Add(username);
                    users.Remove(username);
                    continue;
                }

                if (banned.Contains(username))
                {
                    continue;
                }

                var language = tokens[1];
                var points = int.Parse(tokens[2]);

                if (!languages.ContainsKey(language))
                {
                    languages.Add(language, 0);
                }

                if (!users.ContainsKey(username))
                {
                    users.Add(username, 0);
                }

                languages[language]++;
                users[username] = Math.Max(points, users[username]);
            }

            Console.WriteLine($"Results:");
            foreach (var user in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine($"Submissions:");
            foreach (var lang in languages.OrderByDescending(x => x.Value).ThenBy(x => x.Key))     
            {
                Console.WriteLine($"{lang.Key} - {lang.Value}");
            }
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

            public int Quantity { get; set; }
        }
    }
}
