namespace _22.Multiply_big_number
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var num1Chars = Console.ReadLine().TrimStart(new[] { '0' }).ToCharArray();
            var num2Chars = int.Parse(Console.ReadLine());

            var resultList = new List<string>();
            var inMemory = 0;

            for (var i = num1Chars.Length - 1; i >= 0; i--)
            {
                var currentResult = int.Parse(new string(num1Chars[i], 1)) * num2Chars + inMemory;
                inMemory = currentResult / 10;
                currentResult %= 10;
                resultList.Add($"{currentResult}");
            }

            if (inMemory > 0)
            {
                resultList.Add($"{inMemory}");
            }

            var result = string.Empty;

            for (var i = resultList.Count - 1; i >= 0; i--)
            {
                result += resultList[i];
            }

            result = result.TrimStart(new[] {'0'});

            if (result == string.Empty)
            {
                result = "0";
            }

            Console.WriteLine(result);
        }
    }
}