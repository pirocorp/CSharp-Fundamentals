namespace _01._Basic_Syntax__Conditional_Statements_and_Loops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            // Task1();
            // Task2();
            // Task3();
            // Task4();
            // Task5();
            // Task6();
            // Task7();
            // Task8();
            // Task9();
            Task10();
        }

        private static void Task1()
        {
            var input = int.Parse(Console.ReadLine() ?? string.Empty);

            if(input <= 2)
            {
                Console.WriteLine("baby");
            }
            else if (input <= 13)
            {
                Console.WriteLine("child");
            }
            else if (input <= 19)
            {
                Console.WriteLine("teenager");
            }
            else if (input <= 65)
            {
                Console.WriteLine("adult");
            }
            else
            {
                Console.WriteLine("elder");
            }
        }

        private static void Task2()
        {
            var input = int.Parse(Console.ReadLine() ?? string.Empty);

            var divisors = new[] { 2, 3, 6, 7, 10 }.Reverse().ToArray();

            foreach (var divisor in divisors)
            {
                if (input % divisor is 0)
                {
                    Console.WriteLine($"The number is divisible by {divisor}");
                    return;
                }
            }

            Console.WriteLine("Not divisible");
        }

        private static void Task3NotSupportedByJudge()
        {
            //var visitors = int.Parse(Console.ReadLine());
            //var row = Console.ReadLine();
            //var col = Console.ReadLine();

            //var price = (row, col) switch
            //{
            //    ("Students", "Friday") => (8.45M),
            //    ("Students", "Saturday") => (9.80M),
            //    ("Students", "Sunday") => (10.46M),
            //    ("Business", "Friday") => (10.90M),
            //    ("Business", "Saturday") => (15.60M),
            //    ("Business", "Sunday") => (16.00M),
            //    ("Regular", "Friday") => (15.00M),
            //    ("Regular", "Saturday") => (20.00M),
            //    ("Regular", "Sunday") => (22.50M),
            //    _ => throw new ArgumentException()
            //};

            //var are30OrMore = visitors >= 30;
            //var are100OrMore = visitors >= 100;
            //var areBetween10And20 = visitors >= 10 && visitors <= 20;

            //var total = (row, are30orMore: are30OrMore, are100orMore: are100OrMore, areBetween10And20) switch
            //{
            //    ("Students", true, _, _) => price * visitors * 0.85M,
            //    ("Business", _, true, _) => price * (visitors - 10),
            //    ("Regular", _, _, true) => price * visitors * 0.95M,
            //    _ => price * visitors
            //};

            //Console.WriteLine($"Total price: {total:F2}");
        }

        private static void Task3()
        {
            var visitors = int.Parse(Console.ReadLine());
            var row = Console.ReadLine();
            var col = Console.ReadLine();

            var prices = new Dictionary<string, Dictionary<string, decimal>>()
            {
                {
                    "Students", new Dictionary<string, decimal>()
                    {
                        { "Friday", 8.45M },
                        { "Saturday", 9.80M },
                        { "Sunday", 10.46M },
                    }
                },
                {
                    "Business", new Dictionary<string, decimal>()
                    {
                        { "Friday", 10.90M },
                        { "Saturday", 15.60M },
                        { "Sunday", 16.00M },
                    }
                },
                {
                    "Regular", new Dictionary<string, decimal>()
                    {
                        { "Friday", 15.00M },
                        { "Saturday", 20.00M },
                        { "Sunday", 22.50M },
                    }
                }
            };

            var price = prices[row][col];

            decimal total;

            if (row is "Students" && visitors >= 30)
            {
                total = visitors * price * 0.85M;
            }
            else if (row is "Business" && visitors >= 100)
            {
                total = (visitors - 10) * price;
            }
            else if (row is "Regular" && visitors >= 10 && visitors <= 20)
            {
                total = visitors * price * 0.95M;
            }
            else
            {
                total = visitors * price;
            }

            Console.WriteLine($"Total price: {total:F2}");
        }

        private static void Task4()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());


            var numbers = new List<int>();

            for (var i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine($"Sum: {numbers.Sum()}");
        }

        private static void Task5()
        {
            var user = Console.ReadLine();

            for (var i = 0; i < 4; i++)
            {
                var password = Console.ReadLine();

                if (user == new string(password.Reverse().ToArray()))
                {
                    Console.WriteLine($"User {user} logged in.");
                    return;
                }
                else if(i < 4 - 1)
                {
                    Console.WriteLine($"Incorrect password. Try again.");
                }
            }

            Console.WriteLine($"User {user} blocked!");
        }

        private static void Task6()
        {
            var number = Console.ReadLine();
            var result = 0;

            foreach (var @char in number)
            {
                var digit = int.Parse(new string(@char, 1));
                var factor = 1;

                for (var i = 1; i <= digit; i++)
                {
                    factor *= i;
                }

                result += factor;
            }

            if (result == int.Parse(number))
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        private static void Task7()
        {
            var coinTypes = new HashSet<decimal>()
            {
                0.1M, 0.2M, 0.5M, 1.0M, 2.0M,
            };

            var products = new Dictionary<string, decimal>()
            {
                { "Nuts", 2.0M },
                { "Water", 0.7M },
                { "Crisps", 1.5M },
                { "Soda", 0.8M },
                { "Coke", 1.0M },
            };

            var coins = new List<decimal>();

            var input = Console.ReadLine();

            while (input != "Start")
            {
                var coin = decimal.Parse(input);

                if (!coinTypes.Contains(coin))
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                else
                {
                    coins.Add(coin);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            var sum = coins.Sum();

            while (input != "End")
            {
                if (!products.ContainsKey(input))
                {
                    Console.WriteLine($"Invalid product");
                }
                else
                {
                    if (sum < products[input])
                    {
                        Console.WriteLine("Sorry, not enough money");
                    }
                    else
                    {
                        Console.WriteLine($"Purchased {input.ToLower()}");
                        sum -= products[input];
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:F2}");
        }

        private static void Task8()
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 1; i <= n; i++)
            {
                var row =string.Join(" ", Enumerable.Repeat(i.ToString(), i));
                Console.WriteLine(row);
            }
        }

        private static void Task9()
        {
            var cashAmount = decimal.Parse(Console.ReadLine());
            var padawans = int.Parse(Console.ReadLine());

            var priceOfLightsaber = decimal.Parse(Console.ReadLine());
            var priceOfRobe = decimal.Parse(Console.ReadLine());
            var priceOfBelt = decimal.Parse(Console.ReadLine());

            var lightsabersCount = Math.Ceiling(padawans * 1.1);
            var robesCount = padawans;
            var beltsCount = padawans -= (padawans / 6);

            var totalCost =
                priceOfLightsaber * (decimal) lightsabersCount
                + priceOfRobe * robesCount
                + priceOfBelt * beltsCount;

            if (totalCost <= cashAmount)
            {
                Console.WriteLine($"The money is enough - it would cost {totalCost:F2}lv.");
            }
            else
            {
                var missing = totalCost - cashAmount;
                Console.WriteLine($"Ivan Cho will need {missing:F2}lv more.");
            }
        }

        private static void Task10()
        {
            var lostGamesCount = int.Parse(Console.ReadLine());

            var headsetPrice = decimal.Parse(Console.ReadLine());
            var mousePrice = decimal.Parse(Console.ReadLine());
            var keyboardPrice = decimal.Parse(Console.ReadLine());
            var displayPrice = decimal.Parse(Console.ReadLine());

            var headsetsCount = lostGamesCount / 2;
            var mouseCount = lostGamesCount / 3;
            var keyboardCount = lostGamesCount / 6;
            var displayCount = lostGamesCount / 12;

            var expenses =
                headsetsCount * headsetPrice
                + mouseCount * mousePrice
                + keyboardCount * keyboardPrice
                + displayCount * displayPrice;

            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
