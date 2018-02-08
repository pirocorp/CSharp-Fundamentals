namespace _05.Match_Numbers
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var pattern = @"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))";
            var numbersString = Console.ReadLine();
            var numbers = Regex.Matches(numbersString, pattern);

            foreach (Match number in numbers)
            {
                Console.Write(number.Value + " ");
            }

            Console.WriteLine();
        }
    }
}