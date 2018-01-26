namespace _02.Count_Substring_Occurrences
{
    using System;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine().ToLower();
            var pattern = Console.ReadLine().ToLower();
            var counter = 1;
            var index = input.IndexOf(pattern);

            while ((index = input.IndexOf(pattern, index + 1)) != -1)
            {
                counter++;
            }

            Console.WriteLine(counter);
        }
    }
}
