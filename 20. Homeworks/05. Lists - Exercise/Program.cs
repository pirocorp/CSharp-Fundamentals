namespace _05._Lists___Exercise
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
            Task10();
        }

        private static void Task01()
        {
            var wagons = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var maxCapacity = int.Parse(Console.ReadLine());

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var success = int.TryParse(input, out var passengers);

                if (!success)
                {
                    passengers = int.Parse(input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[1]);
                    wagons.Add(passengers);
                }
                else
                {
                    for (var i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <= maxCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", wagons));
        }

        private static void Task02()
        {
            var list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens.Length)
                {
                    case 2:
                        var element = int.Parse(tokens[1]);
                        list.RemoveAll(x => x == element);
                        break;
                    case 3:
                        element = int.Parse(tokens[1]);
                        var position = int.Parse(tokens[2]);
                        list.Insert(position, element);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static void Task03()
        {
            var n = int.Parse(Console.ReadLine());

            var guests = new List<string>();

            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                var guest = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];

                if (input.Contains("not"))
                {
                    if (!guests.Contains(guest))
                    {
                        Console.WriteLine($"{guest} is not in the list!");
                        continue;
                    }

                    guests.Remove(guest);
                }
                else
                {
                    if (guests.Contains(guest))
                    {
                        Console.WriteLine($"{guest} is already in the list!");
                        continue;
                    }

                    guests.Add(guest);
                }
            }

            guests.ForEach(Console.WriteLine);
        }

        private static void Task04()
        {
            var list = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                switch (command)
                {
                    case "Add":
                        var number = int.Parse(tokens[1]);
                        list.Add(number);
                        break;
                    case "Insert":
                        number = int.Parse(tokens[1]);
                        var index = int.Parse(tokens[2]);
                        if (index < 0 || index >= list.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            list.Insert(index, number);
                        } 
                        break;
                    case "Remove":
                        index = int.Parse(tokens[1]);
                        if (index < 0 || index >= list.Count)
                        {
                            Console.WriteLine("Invalid index");
                        }
                        else
                        {
                            list.RemoveAt(index);
                        }
                        break;
                    case "Shift":
                        var direction = tokens[1];
                        var count = int.Parse(tokens[2]);
                        Shift(list, direction, count);
                        break;
                }
            }

            Console.WriteLine(string.Join(" ", list));
        }

        private static void Shift(List<int> list, string direction, int count)
        {
            var rotations = count % list.Count;

            if (direction == "left")
            {
                for (var i = 0; i < rotations; i++)
                {
                    var first = list.First();
                    list.RemoveAt(0);
                    list.Add(first);
                }
                
            }
            else
            {
                for (var i = 0; i < rotations; i++)
                {
                    var last = list.Last();
                    list.RemoveAt(list.Count - 1);
                    list.Insert(0, last);
                }
            }
        }

        private static void Task05()
        {
            char[] separator = { ' ' };
            var numbersSequence = Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var bombSequence = Console.ReadLine()
                .Split(separator, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var bomb = bombSequence[0];
            var bombPower = bombSequence[1];

            var bombIndex = numbersSequence.IndexOf(bomb);

            while (bombIndex >= 0)
            {
                var bombStartIndex = bombIndex - bombPower;
                if (bombStartIndex < 0)
                {
                    bombStartIndex = 0;
                }

                var bombEndIndex = bombIndex + bombPower;
                if (bombEndIndex >= numbersSequence.Count)
                {
                    bombEndIndex = numbersSequence.Count - 1;
                }

                var boom = bombEndIndex - bombStartIndex + 1;
                while (boom > 0)
                {
                    numbersSequence.RemoveAt(bombStartIndex);
                    boom--;
                }

                bombIndex = numbersSequence.IndexOf(bomb);
            }

            Console.WriteLine(numbersSequence.Sum());
        }

        private static void Task06()
        {
            var deck1 = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            var deck2 = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            while (deck1.Count > 0 && deck2.Count > 0)
            {
                var card1 = deck1.First();
                var card2 = deck2.First();

                deck1.RemoveAt(0);
                deck2.RemoveAt(0);

                if (card1 > card2)
                {
                    deck1.Add(card1);
                    deck1.Add(card2);
                }
                else if(card2 > card1)
                {
                    deck2.Add(card2);
                    deck2.Add(card1);
                }
            }

            if (deck1.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {deck1.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {deck2.Sum()}");
            }
        }

        private static void Task07()
        {
            var tokens = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray())
                .Reverse()
                .SelectMany(x => x)
                .ToArray();

            Console.WriteLine(string.Join(" ", tokens));
        }

        private static void Task08()
        {
            var data = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "3:1")
            {
                var tokens = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                switch (command)
                {
                    case "merge":
                        var startIndex = Math.Max(0, int.Parse(tokens[1]));
                        var endIndex = Math.Min(data.Count - 1, int.Parse(tokens[2]));

                        if (startIndex >= endIndex)
                        {
                            continue;
                        }
                        
                        var merge = data
                            .Skip(startIndex)
                            .Take(endIndex - startIndex + 1)
                            .ToArray();

                        var merged = string.Join("", merge);

                        data.RemoveRange(startIndex, endIndex - startIndex + 1);
                        data.Insert(startIndex, merged);
                        break;
                    case "divide":
                        var index = int.Parse(tokens[1]);
                        var partitions = int.Parse(tokens[2]);
                        var parts = GetParts(data, index, partitions);
                        data.RemoveAt(index);
                        parts.ForEach(x => data.Insert(index, x));
                        break;
                }

                //Console.WriteLine(string.Join(" ", data));
            }

            Console.WriteLine(string.Join(" ", data));
        }

        private static List<string> GetParts(List<string> data, int index, int partitions)
        {
            var parts = new List<string>();

            var item = data[index];
            var size = item.Length / partitions;

            for (var i = 0; i < partitions - 1; i++)
            {
                var part = new string(item.Skip(i * size).Take(size).ToArray());
                parts.Add(part);
            }

            var x = new string(item.Skip((partitions - 1) * size).ToArray());
            parts.Add(x);
            parts.Reverse();

            return parts;
        }

        private static void Task09()
        {
            var arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var sum = 0L;

            while (arr.Count > 0)
            {
                var index = int.Parse(Console.ReadLine());
                var element = 0;

                if (index < 0)
                {
                    element = arr[0];
                    arr[0] = arr[^1];
                }
                else if (index >= arr.Count)
                {
                    element = arr[^1];
                    arr[^1] = arr[0];
                }
                else
                {   element = arr[index];
                    arr.RemoveAt(index);
                }

                for (var i = 0; i < arr.Count; i++)
                {
                    if (arr[i] <= element)
                    {
                        arr[i] += element;
                    }
                    else
                    {
                        arr[i] -= element;
                    }
                }

                sum += element;
            }

            Console.WriteLine(sum);
        }

        private static void Task10()
        {
            var arr = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string input;
            while ((input = Console.ReadLine()) != "course start")
            {
                var tokens = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];
                var title = tokens[1];

                switch (command)
                {
                    case "Add":
                        if (!arr.Contains(title))
                        {
                            arr.Add(title);
                        }
                        break;
                    case "Insert":
                        var index = int.Parse(tokens[2]);

                        if (index < 0 || index >= arr.Count)
                        {
                            break;
                        }

                        if (!arr.Contains(title))
                        {
                            arr.Insert(index, title);
                        }
                        break;
                    case "Remove":
                        if (arr.Contains(title))
                        {
                            arr.Remove(title);

                            if (arr.Contains($"{title}-Exercise"))
                            {
                                arr.Remove($"{title}-Exercise");
                            }
                        }
                        break;
                    case "Swap":
                        var title2 = tokens[2];
                        if (arr.Contains(title) && arr.Contains(title2))
                        {
                            var index1 = arr.IndexOf(title);
                            var index2 = arr.IndexOf(title2);

                            var swap = arr[index1];
                            arr[index1] = arr[index2];
                            arr[index2] = swap;

                            if (arr.Contains($"{title}-Exercise"))
                            {
                                var exercise1 = arr.IndexOf($"{title}-Exercise");
                                swap = arr[exercise1];
                                arr.RemoveAt(exercise1);

                                var course1 = arr.IndexOf(title);
                                arr.Insert(course1 + 1, swap);
                            }

                            if (arr.Contains($"{title2}-Exercise"))
                            {
                                var exercise2 = arr.IndexOf($"{title2}-Exercise");
                                swap = arr[exercise2];
                                arr.RemoveAt(exercise2);

                                var course2 = arr.IndexOf(title2);
                                arr.Insert(course2 + 1, swap);
                            }
                        }

                        break;
                    case "Exercise":
                        if (arr.Contains(title))
                        {
                            if (!arr.Contains($"{title}-Exercise"))
                            {
                                var i = arr.IndexOf(title);
                                arr.Insert(i, $"{title}-Exercise");
                            }
                        }
                        else
                        {
                            arr.Add(title);
                            arr.Add($"{title}-Exercise");
                        }
                        break;
                }
            }

            var n = 1;
            foreach (var title in arr)
            {
                Console.WriteLine($"{n}.{title}");
                n++;
            }
        }
    }
}
