namespace _21.Sum_Big_Numbers
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var num1Chars = Console.ReadLine().TrimStart(new []{'0'}).ToCharArray();
            var num2Chars = Console.ReadLine().TrimStart(new []{'0'}).ToCharArray();

            var minLenght = Math.Min(num1Chars.Length, num2Chars.Length);
            var maxLenght = Math.Max(num1Chars.Length, num2Chars.Length);
            var resultList = new List<string>();
            var inMemory = 0;

            if (num1Chars.Length >= num2Chars.Length)
            {
                var i = maxLenght - 1;

                for (var j = minLenght - 1; j >= 0; j--)
                {
                    var currentResultInChar = int.Parse(new string(num1Chars[i], 1)) + int.Parse(new string(num2Chars[j], 1)) + inMemory;
                    inMemory = currentResultInChar / 10;
                    currentResultInChar %= 10;
                    resultList.Add($"{currentResultInChar}");
                    i--;
                }
                
                for (i = maxLenght - minLenght - 1; i >= 0; i--)
                {
                    var currentResultInChar = int.Parse(new string(num1Chars[i], 1)) + inMemory;
                    inMemory = currentResultInChar / 10;
                    currentResultInChar %= 10;
                    resultList.Add($"{currentResultInChar}");
                }
            }
            else if (num2Chars.Length > num1Chars.Length)
            {
                var i = maxLenght - 1;

                for (var j = minLenght - 1; j >= 0; j--)
                {
                    var currentResultInChar = int.Parse(new string(num1Chars[j], 1)) + int.Parse(new string(num2Chars[i], 1)) + inMemory;
                    inMemory = currentResultInChar / 10;
                    currentResultInChar %= 10;
                    resultList.Add($"{currentResultInChar}");
                    i--;
                }
                
                for (i = maxLenght - minLenght - 1; i >= 0; i--)
                {
                    var currentResultInChar = int.Parse(new string(num2Chars[i], 1)) + inMemory;
                    inMemory = currentResultInChar / 10;
                    currentResultInChar %= 10;
                    resultList.Add($"{currentResultInChar}");
                }
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

            Console.WriteLine(result);
        }
    }
}