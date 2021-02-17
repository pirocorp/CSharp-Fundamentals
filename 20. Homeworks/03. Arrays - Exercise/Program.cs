namespace _03._Arrays___Exercise
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
            Task010();
        }

        private static void Task01()
        {
            var cars = int.Parse(Console.ReadLine());
            var train = new List<int>();

            for (var i = 0; i < cars; i++)
            {
                var car = int.Parse(Console.ReadLine());
                train.Add(car);
            }

            Console.WriteLine(string.Join(" ", train));
            Console.WriteLine(train.Sum());
        }

        private static void Task02()
        {
            var arr1 = Console.ReadLine().Split(" ").ToArray();
            var arr2 = Console.ReadLine().Split(" ").ToArray();

            var common = arr2.Where(i => arr1.Contains(i));
            Console.WriteLine(string.Join(" ", common));
        }

        private static void Task03()
        {
            var n = int.Parse(Console.ReadLine());

            var arr1 = new List<int>();
            var arr2 = new List<int>();

            var sw = true;
            int a1;
            int a2;

            for (var i = 0; i < n; i++)
            {
                var elements = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (sw)
                {
                    a1 = elements[0];
                    a2 = elements[1];
                }
                else
                {
                    a2 = elements[0];
                    a1 = elements[1];
                }

                arr1.Add(a1);
                arr2.Add(a2);
                sw = !sw;
            }

            Console.WriteLine(string.Join(" ", arr1));
            Console.WriteLine(string.Join(" ", arr2));
        }

        private static void Task04()
        {
            var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var n = int.Parse(Console.ReadLine());
            n %= arr.Count;

            for (var i = 0; i < n; i++)
            {
                var swap = arr[0];
                arr.RemoveAt(0);
                arr.Add(swap);
            }

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Task05()
        {
            var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var res = new List<int>();

            for (var i = 0; i < arr.Length; i++)
            {
                var x = arr[i];
                var temp = arr.Skip(i + 1).ToArray();

                if (temp.All(t => x > t))
                {
                    res.Add(x);
                }
            }

            Console.WriteLine(string.Join(" ", res));
        }

        private static void Task06()
        {
            var arr = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var index = -1;

            for (var i = 0; i < arr.Length; i++)
            {
                var left = arr.Take(i);
                var right = arr.Skip(i + 1);

                if (left.Sum() == right.Sum())
                {
                    index = i;
                    break;
                }
            }

            if (index > -1)
            {
                Console.WriteLine(index);
            }
            else
            {
                Console.WriteLine("no");
            }
        }

        private static void Task07()
        {
            var arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var length = 1;
            var maxlength = 1;
            var maxElement = arr[0];
            var element = arr[0];

            for (var i = 1; i < arr.Length; i++)
            {
                if (element == arr[i])
                {
                    length++;
                }
                else
                {
                    if (maxlength < length)
                    {
                        maxlength = length;
                        maxElement = element;
                    }

                    length = 1;
                    element = arr[i];
                }
            }

            if (maxlength < length)
            {
                maxlength = length;
                maxElement = element;
            }

            Console.WriteLine(string.Join(" ", Enumerable.Repeat(maxElement, maxlength)));
        }

        private static void Task08()
        {
            var arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());

            for (var i = 0; i < arr.Length - 1; i++)
            {
                var first = arr[i];

                for (var j = i + 1; j < arr.Length; j++)
                {
                    var second = arr[j];

                    if (first + second == target)
                    {
                        Console.WriteLine($"{first} {second}");
                    }
                }
            }
        }

        private static void Task09()
        {
            var n = int.Parse(Console.ReadLine());
            var bestDna = new int[0];
            var bestDnaStartIndex = -1;
            var bestDnaLength = -1;
            var bestDnaId = 0;

            var sequenceId = 1;
            string input;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                var dna = input.Split("!", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                var length = 0;
                var dnaLength = 0;
                var bestIndex = 0;
                var startIndex = 0;

                for (var index = 0; index < dna.Length; index++)
                {
                    var t = dna[index];
                    if (1 == t)
                    {
                        length++;
                    }
                    else
                    {
                        if (dnaLength < length)
                        {
                            dnaLength = length;
                            bestIndex = startIndex;
                        }

                        length = 0;
                        startIndex = index;
                    }
                }

                if (dnaLength < length)
                {
                    dnaLength = length;
                    bestIndex = startIndex;
                }

                if (bestDnaLength < dnaLength
                    || (dnaLength == bestDnaLength && (bestDna.Sum() < dna.Sum() || bestIndex < bestDnaStartIndex)))
                {
                    bestDnaLength = dnaLength;
                    bestDna = dna;
                    bestDnaStartIndex = bestIndex;
                    bestDnaId = sequenceId;
                }

                sequenceId++;
            }

            Console.WriteLine($"Best DNA sample {bestDnaId} with sum: {bestDna.Sum()}.");
            Console.WriteLine(string.Join(" ", bestDna));
        }

        private static void Task010()
        {
            var size = int.Parse(Console.ReadLine());
            var bugs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            var field = new bool[size];

            foreach (var bug in bugs)
            {
                if (bug < size && bug >= 0)
                {
                    field[bug] = true;
                }
            }

            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var start = long.Parse(tokens[0]);
                var direction = tokens[1];
                var distance = long.Parse(tokens[2]);

                if ( start < 0 || start >= size || !field[start])
                {
                    continue;
                }

                field[start] = false;
                var dest = direction == "right" ? start + distance : start - distance;

                while (dest >= 0 && dest < size)
                {
                    if (dest < 0 || dest >= size)
                    {
                        break;
                    }

                    if (!field[dest])
                    {
                        field[dest] = true;
                        break;
                    }

                    dest = direction == "right" ? dest + distance : dest - distance;
                }
            }

            Console.WriteLine(string.Join(" ", field.Select(i => i ? 1 : 0)));
        }
    }
}
