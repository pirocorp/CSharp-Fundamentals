namespace _18.Unicode_Characters
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var inputString = Console.ReadLine();

            var chars = inputString
                .Select(c => (int)c)
                .Select(c => $"\\u{c:x4}")
                .ToArray();

            var result = string.Join("", chars);
            Console.WriteLine(result);
        }
    }
}
