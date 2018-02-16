namespace _17.Censorship
{
    using System;
    using System.Text.RegularExpressions;

    class Censorship
    {
        static void Main()
        {
            var word = Console.ReadLine();
            var inputLine = Console.ReadLine();
            var replace = new string('*', word.Length);
            var result = Regex.Replace(inputLine, word, replace);
            Console.WriteLine(result);
        }
    }
}
