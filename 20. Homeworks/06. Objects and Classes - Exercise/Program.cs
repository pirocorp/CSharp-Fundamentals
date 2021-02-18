namespace _06._Objects_and_Classes___Exercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            // Task1();
            // Task2();
            // Task3();
            // Task4();
            // Task5();
            // Task6();
            Task7();
        }

        private static void Task1()
        {
            var phrases = new[]
            {
                "Excellent product.", "Such a great product.", "I always use that product.",
                "Best product of its category.", "Exceptional product.", "I can’t live without this product."
            };

            var events = new[]
            {
                "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"
            };
            
            var authors = new[] {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"};
            var cities = new[] {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};

            var n = int.Parse(Console.ReadLine());
            var randomGenerator = new Random();

            for (var i = 0; i < n; i++)
            {
                var p = randomGenerator.Next(0, phrases.Length);
                var e = randomGenerator.Next(0, events.Length);
                var a = randomGenerator.Next(0, authors.Length);
                var c = randomGenerator.Next(0, cities.Length);

                Console.WriteLine( $"{phrases[p]} {events[e]} {authors[a]} – {cities[c]}.");
            }
        }

        private static void Task2()
        {
            var tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            var title = tokens[0];
            var content = tokens[1];
            var author = tokens[2];

            var article = new Article(title, content, author);
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                tokens = Console.ReadLine().Split(": ");
                var command = tokens[0];
                var parameter = tokens[1];

                switch (command)
                {
                    case "Edit":
                        article.Edit(parameter);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(parameter);
                        break;
                    case "Rename":
                        article.Rename(parameter);
                        break;
                }
            }

            Console.WriteLine(article);
        }

        private static void Task3()
        {
            var articles = new List<Article>();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                var title = tokens[0];
                var content = tokens[1];
                var author = tokens[2];

                var article = new Article(title, content, author);
                articles.Add(article);
            }

            var order = Console.ReadLine();

            switch (order)
            {
                case "title":
                    articles = articles.OrderBy(x => x.Title).ToList();
                    break;
                case "content":
                    articles = articles.OrderBy(x => x.Content).ToList();
                    break;
                case "author":
                    articles = articles.OrderBy(x => x.Author).ToList();
                    break;
            }

            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }
        }

        private static void Task4()
        {
            var n = int.Parse(Console.ReadLine());
            var students = new List<Student>();

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var firstName = tokens[0];
                var lastName = tokens[1];
                var grade = double.Parse(tokens[2]);

                var student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            students = students.OrderByDescending(s => s.Grade).ToList();
            foreach (var student in students)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:F2}");
            }
        }

        private static void Task5()
        {
            var n = int.Parse(Console.ReadLine());
            var teams = new List<Team>();

            for (var i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split("-", StringSplitOptions.RemoveEmptyEntries);
                var creator = tokens[0];
                var name = tokens[1];

                if (teams.Any(t => t.Name.Equals(name)))
                {
                    Console.WriteLine($"Team {name} was already created!");
                    continue;
                }

                if (teams.Any(t => t.Creator.Equals(creator)))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                var team = new Team(name, creator);
                teams.Add(team);
                Console.WriteLine($"Team {name} has been created by {creator}!");
            }

            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                var tokens = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                var member = tokens[0];
                var team = tokens[1];

                if (teams.All(t => t.Name != team))
                {
                    Console.WriteLine($"Team {team} does not exist!");
                    continue;
                }

                if (teams.Any(t => t.Creator.Equals(member) || t.Members.Any(m => m.Equals(member))))
                {
                    Console.WriteLine($"Member {member} cannot join team {team}!");
                    continue;
                }

                var currentTeam = teams.First(t => t.Name.Equals(team));
                currentTeam.AddMember(member);
            }

            teams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name)
                .ToList()
                .ForEach(Console.WriteLine);

            Console.WriteLine("Teams to disband:");

            teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)
                .ToList()
                .ForEach(x => Console.WriteLine(x.Name));
        }

        private static void Task6()
        {
            var catalog = new List<Vehicle>();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var type = tokens[0].ToLower();
                var model = tokens[1];
                var color = tokens[2].ToLower();
                var horsepower = int.Parse(tokens[3]);

                var vehicle = new Vehicle(type, model, color, horsepower);
                catalog.Add(vehicle);
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                var model = input;
                var vehicle = catalog.FirstOrDefault(v => v.Model.Equals(model));

                if (vehicle is null)
                {
                    continue;
                }

                Console.WriteLine(vehicle);
            }

            var cars = catalog.Where(v => v.Type == "car").ToArray();
            var trucks = catalog.Where(v => v.Type == "truck").ToArray();

            if (cars.Length > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {cars.Average(c => c.Horsepower):F2}.");
            }
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0D:F2}.");
            }

            if (trucks.Length > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {trucks.Average(t => t.Horsepower):F2}.");
            }
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0D:F2}.");
            }
        }

        private static void Task7()
        {
            var people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[0];
                var id = int.Parse(tokens[1]);
                var age = int.Parse(tokens[2]);

                var person = new Person(id, name, age);
                people.Add(person);
            }

            people = people.OrderBy(p => p.age).ToList();
            people.ForEach(Console.WriteLine);
        }

        public class Person
        {
            public Person(long id, string name, int age)
            {
                this.Id = id;
                this.Name = name;
                this.age = age;
            }

            public long Id { get; private set; }

            public string Name { get; private set; }

            public int age { get; private set; }

            public override string ToString()
            {
                return $"{this.Name} with ID: {this.Id} is {this.age} years old.";
            }
        }

        public class Vehicle
        {
            public Vehicle(string type, string model, string color, int horsepower)
            {
                this.Type = type;
                this.Model = model;
                this.Color = color;
                this.Horsepower = horsepower;
            }

            public string Type { get; private set; }

            public string Model { get; private set; }

            public string Color { get; private set; }

            public int Horsepower { get; private set; }

            public override string ToString()
            {
                var sb = new StringBuilder();

                sb.AppendLine($"Type: {char.ToUpper(this.Type[0]) + this.Type.Substring(1)}");
                sb.AppendLine($"Model: {this.Model}");
                sb.AppendLine($"Color: {this.Color}");
                sb.AppendLine($"Horsepower: {this.Horsepower}");

                return sb.ToString().Trim();
            }
        }

        public class Team
        {
            private readonly List<string> members;

            public Team(string name, string creator)
            {
                this.Name = name;
                this.Creator = creator;
                this.members = new List<string>();
            }

            public string Name { get; set; }

            public string Creator { get; set; }

            public IReadOnlyCollection<string> Members => this.members.AsReadOnly();

            public void AddMember(string member) => this.members.Add(member);

            public override string ToString()
            {
                var sb = new StringBuilder();

                sb.AppendLine(this.Name);
                sb.AppendLine($"- {this.Creator}");

                foreach (var member in this.members.OrderBy(m => m))
                {
                    sb.AppendLine($"-- {member}");
                }

                return sb.ToString().Trim();
            }
        }

        public class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }

            public string Title { get; private set; }

            public string Content { get; private set; }

            public string Author { get; private set; }

            public void Edit(string content)
            {
                this.Content = content;
            }

            public void ChangeAuthor(string author)
            {
                this.Author = author;
            }

            public void Rename(string title)
            {
                this.Title = title;
            }

            public override string ToString()
            {
                return $"{this.Title} - {this.Content}: {this.Author}";
            }
        }

        public class Student
        {
            public Student(string firstName, string lastName, double grade)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Grade = grade;
            }

            public string FirstName { get; private set; }

            public string LastName { get; private set; }

            public double Grade { get; private set; }
        }
    }
}
