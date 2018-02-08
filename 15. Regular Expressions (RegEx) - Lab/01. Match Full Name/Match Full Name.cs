namespace _01.Match_Full_Name
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        public static void Main()
        {
            var pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            var names = Console.ReadLine();
            var matchedNames = Regex.Matches(names, pattern);

            foreach (Match name in matchedNames)
            {
                Console.Write(name.Value + " ");
            }

            Console.WriteLine();
        }
    }
}