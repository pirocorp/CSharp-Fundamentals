namespace _04._Methods___Exercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Program
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
            Task11();
        }

        private static void Task01()
        {
            PrintSmallestOfThreeNumbers();
        }

        private static void Task02()
        {
            var vowels = new[] { 'a', 'e', 'i', 'o', 'u', };

            var input = Console.ReadLine();

            var count = input.Count(c => vowels.Contains(char.ToLower(c)));
            Console.WriteLine(count);
        }

        private static void Task03()
        {
            var a = Console.ReadLine()[0];
            var b = Console.ReadLine()[0];

            var start = Math.Min(a, b);
            var end = Math.Max(a, b);

            var characters = new List<char>();
            for (var i = start + 1; i < end; i++)
            {
                characters.Add((char)i);
            }

            Console.WriteLine(string.Join(' ', characters));
        }

        private static void Task04()
        {
            var password = Console.ReadLine() ?? string.Empty;
            var valid = true;

            if (password.Length < 6 || password.Length > 10)
            {
                valid = false;
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!password.All(c => char.IsDigit(c) || char.IsLetter(c)))
            {
                valid = false;
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (password.Count(char.IsDigit) < 2)
            {
                valid = false;
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (valid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static void Task05()
        {
            var nums = new List<int>();

            for (var i = 0; i < 3; i++)
            {
                var num = int.Parse(Console.ReadLine());
                nums.Add(num);
            }

            var result = nums.Take(2).Sum() - nums.Last();
            Console.WriteLine(result);
        }

        private static void Task06()
        {
            var str = Console.ReadLine() ?? string.Empty;

            if (str.Length % 2 == 0)
            {
                Console.WriteLine(str.Substring((str.Length / 2) - 1, 2));
            }
            else
            {
                Console.WriteLine(str[str.Length / 2]);
            }
        }

        private static void Task07()
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", Enumerable.Repeat(n, n)));
            }
        }

        private static void Task08()
        {
            var a = long.Parse(Console.ReadLine());
            var b = long.Parse(Console.ReadLine());

            a = Factor(a);
            b = Factor(b);
            var result = a / (decimal) b;

            Console.WriteLine($"{result:F2}");
        }

        private static void Task09()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                var reverse = new string(input.Reverse().ToArray());

                Console.WriteLine($"{(reverse == input).ToString().ToLower()}");
            }
        }

        private static void Task10()
        {
            var n = int.Parse(Console.ReadLine());

            for (var i = 1; i <= n; i++)
            {
                if (IsTop(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        private static void Task11()
        {
            var arr = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray() ?? new int[0];

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new[] { string.Empty };
                var command = tokens[0];

                switch (command)
                {
                    case "exchange":
                        var index = int.Parse(tokens[1]);
                        arr = Exchange(arr, index);
                        break;
                    case "max":
                    case "min":
                        Select(arr, command, tokens[1]);
                        break;
                    case "first":
                    case "last":
                        var count = int.Parse(tokens[1]);
                        Get(arr, command, count, tokens[2]);
                        break;
                }

                //Console.WriteLine($"[{string.Join(", ", arr)}]");
            }

            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        private static void PrintSmallestOfThreeNumbers()
        {
            var numbers = new List<int>();

            for (var i = 0; i < 3; i++)
            {
                var num = int.Parse(Console.ReadLine());

                numbers.Add(num);
            }

            Console.WriteLine(numbers.Min());
        }

        private static long Factor(long n)
        {
            var factor = 1L;

            for (var i = 1; i <= n; i++)
            {
                factor *= i;
            }

            return factor;
        }

        private static bool IsTop(int i)
        {
            var sum = i.ToString().Sum(c => int.Parse($"{c}"));

            if (sum % 8 == 0 && i.ToString().Any(c => int.Parse($"{c}") % 2 == 1))
            {
                return true;
            }

            return false;
        }

        private static int[] Exchange(int[] arr, int index)
        {
            if (index < 0 || index >= arr.Length)
            {
                Console.WriteLine("Invalid index");
                return arr;
            }

            var part1 = arr.Take(index + 1);
            var part2 = arr.Skip(index + 1);

            return part2.Concat(part1).ToArray();
        }

        private static void Select(int[] array, string order, string token)
        {
            var index = -1;

            var filter = token == "even" 
                ? (Predicate<int>) (x => x % 2 == 0) 
                : x => x % 2 == 1;

            var condition = order == "max"
                ? (Func<int[], int, int, bool>) ((arr, i, max) => arr[i] >= max)
                : (arr, i, min) => arr[i] <= min;

            index = Best(array, filter, condition, order);

            var action = index == -1 
                ? (Action<int>) ((x) => Console.WriteLine("No matches"))
                : Console.WriteLine;

            action(index);
        }

        private static int Best(int[] arr, Predicate<int> filter, Func<int[], int, int, bool> condition, string order)
        {
            var best = order == "max" 
                ? int.MinValue
                : int.MaxValue;

            var index = -1;

            for (var i = 0; i < arr.Length; i++)
            {
                if (filter(arr[i]) && condition(arr, i, best))
                {
                    index = i;
                    best = arr[i];
                }
            }

            return index;
        }

        private static void Get(int[] arr, string command, int count, string token)
        {
            if (count > arr.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }

            var filter = token == "even" 
                ? (Predicate<int>) (x => x % 2 == 0) 
                : x => x % 2 == 1;

            var array = command == "first" ? arr.ToArray() : arr.Reverse().ToArray();

            var result = array.Where(x => filter(x)).Take(count);
            result = command == "first" ? result : result.Reverse();

            Console.WriteLine($"[{string.Join(", ", result)}]");
        }
    }
}
