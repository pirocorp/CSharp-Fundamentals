namespace _08._Text_Processing___Exercise
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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
        }

        private static void Task01()
        {
            var words = Console.ReadLine().Split(", ");

            foreach (var word in words)
            {
                if (Validate(word))
                {
                    Console.WriteLine(word);
                }
            }
        }

        private static bool Validate(string str)
        {
            if (str.Length < 3 || str.Length > 16)
            {
                return false;
            }

            return str.All(@char => char.IsDigit(@char) || char.IsLetter(@char) || @char == '-' || @char == '_');
        }

        private static void Task02()
        {
            var tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var word1 = tokens[0];
            var word2 = tokens[1];

            var length = Math.Min(word1.Length, word2.Length);
            var sum = 0;

            for (var i = 0; i < length; i++)
            {
                sum += word1[i] * word2[i];
            }

            if (word1.Length > length)
            {
                sum = AddAdditionalCharacters(length, word1, sum);
            }

            if (word2.Length > length)
            {
                sum = AddAdditionalCharacters(length, word2, sum);
            }

            Console.WriteLine(sum);
        }

        private static int AddAdditionalCharacters(int length, string word, int sum)
        {
            for (var i = length; i < word.Length; i++)
            {
                sum += word[i];
            }

            return sum;
        }

        private static void Task03()
        {
            var path = Console.ReadLine();
            var file = path.Substring(path.LastIndexOf("\\", StringComparison.InvariantCultureIgnoreCase) + 1);
            var extension = path.Substring(path.LastIndexOf(".", StringComparison.InvariantCultureIgnoreCase) + 1);

            file = file.Replace($".{extension}", string.Empty);

            Console.WriteLine($"File name: {file}");
            Console.WriteLine($"File extension: {extension}");
        }

        private static void Task04()
        {
            var input = Console.ReadLine();
            var result = new List<char>();

            foreach (var @char in input)
            {
                result.Add((char)(@char + 3));
            }

            Console.WriteLine(new string(result.ToArray()));
        }

        private static void Task05()
        {
            var input = Console.ReadLine();
            var multiplier = int.Parse(Console.ReadLine());

            var product = new List<char>();

            var overflow = 0;

            for (var i = input.Length - 1; i >= 0; i--)
            {
                var result = (input[i] - '0') * multiplier + overflow;
                overflow = result / 10;

                product.Add((result % 10).ToString()[0]);
            }

            if (overflow > 0)
            {
                product.Add(overflow.ToString()[0]);
            }

            var number = new string(product.ToArray());
            number = number.TrimEnd('0');

            number = string.IsNullOrWhiteSpace(number) ? "0" : number;
            Console.WriteLine(new string(number.ToArray().Reverse().ToArray()));
        }

        private static void Task06()
        {
            var input = Console.ReadLine();
            var result = new List<char>();

            var lastChar = input[0];
            result.Add(lastChar);

            for (var i = 1; i < input.Length; i++)
            {
                var currentChar = input[i];

                if (currentChar != lastChar)
                {
                    result.Add(currentChar);
                    lastChar = currentChar;
                }
            }

            Console.WriteLine(new string(result.ToArray()));
        }

        private static void Task07()
        {
            var input = (Console.ReadLine() ?? string.Empty).ToList();

            for (var i = 0; i < input.Count; i++)
            {
                var currentChar = input[i];

                if (currentChar != '>' || input[i + 1] == '_')
                {
                    continue;
                }

                var explosionStr = int.Parse($"{input[i + 1]}") + 1;
                input[i + 1] = '_';
                var end = explosionStr;

                for (var j = i + 2; j < i + end; j++)
                {
                    if (j >= input.Count)
                    {
                        break;
                    }

                    currentChar = input[j];

                    if (currentChar == '>')
                    {
                        end++;
                        end += int.Parse($"{input[j + 1]}");
                    }
                    else
                    {
                        input[j] = '_';
                    }
                }
            }

            var result = new string(input.ToArray());
            result = result.Replace("_", string.Empty);
            Console.WriteLine(result);
        }

        private static void Task08()
        {
            var strings = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var sum = 0D;

            for (var i = 0; i < strings.Length; i++)
            {
                var currentString = strings[i];

                var firstChar = currentString.First();
                var lastChar = currentString.Last();

                var num = double.Parse(currentString.Substring(1, currentString.Length - 2));

                if (char.IsUpper(firstChar))
                {
                    var x = ((firstChar - 'A') + 1);
                    num /= x;
                }
                else if (char.IsLower(firstChar))
                {
                    num *= ((firstChar - 'a') + 1);
                }

                if (char.IsUpper(lastChar))
                {
                    num -= ((lastChar - 'A') + 1);
                }
                else if (char.IsLower(lastChar))
                {
                    num += ((lastChar - 'a') + 1);
                }

                sum += num;
            }

            Console.WriteLine($"{sum:F2}");
        }
    }
}
