namespace _02._Data_Types_and_Variables
{
    using System;
    using System.Collections.Generic;

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
            var a = long.Parse(Console.ReadLine());
            var b = long.Parse(Console.ReadLine());
            var c = long.Parse(Console.ReadLine());
            var d = long.Parse(Console.ReadLine());

            var result = a + b;

            result /= c;
            result *= d;

            Console.WriteLine(result);
        }

        private static void Task2()
        {
            var number = long.Parse(Console.ReadLine());
            var sum = 0L;

            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }

            Console.WriteLine(sum);
        }

        private static void Task3()
        {
            var p = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            var c = Math.Ceiling(p / (double)n);
            Console.WriteLine(c);
        }

        private static void Task4()
        {
            var n = int.Parse(Console.ReadLine());
            var sum = 0;

            for (var i = 0; i < n; i++)
            {
                var @char = Console.ReadLine()[0];
                sum += (int) @char;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }

        private static void Task5()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var characters = new List<char>();

            for (var i = start; i <= end; i++)
            {
                characters.Add((char) i);
            }

            Console.WriteLine(string.Join(" ", characters));
        }

        private static void Task6()
        {
            var n = int.Parse(Console.ReadLine());

            for (var i1 = 0; i1 < n; i1++)
            {
                for (var i2 = 0; i2 < n; i2++)
                {
                    for (var i3 = 0; i3 < n; i3++)
                    {
                        var firstChar = (char)('a' + i1);
                        var secondChar = (char)('a' + i2);
                        var thirdChar = (char)('a' + i3);

                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }

        private static void Task7()
        {
            var volume = 0;
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());

                if (volume + input > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }

                volume += input;
            }

            Console.WriteLine(volume);
        }

        private static void Task8()
        {
            var n = int.Parse(Console.ReadLine());
            var maxName = string.Empty;
            var maxVolume = 0D;

            for (var i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var r = double.Parse(Console.ReadLine());
                var h = double.Parse(Console.ReadLine());

                var volume = Math.PI * Math.Pow(r, 2) * h;

                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    maxName = name;
                }
            }

            Console.WriteLine(maxName);
        }

        private static void Task9()
        {
            var yield = int.Parse(Console.ReadLine());

            var spice = 0;
            var days = 0;

            while (yield >= 100)
            {
                spice += yield;
                spice = spice - 26 < 0 ? 0 : spice - 26;
                yield -= 10;
                days++;
            }

            spice = spice - 26 < 0 ? 0 : spice - 26;
            Console.WriteLine(days);
            Console.WriteLine(spice);
        }

        private static void Task10()
        {
            var power = int.Parse(Console.ReadLine());
            var distance = int.Parse(Console.ReadLine());
            var exhaustion = int.Parse(Console.ReadLine());
        }
    }
}
