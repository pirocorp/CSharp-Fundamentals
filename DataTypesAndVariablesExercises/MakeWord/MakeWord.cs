using System;

namespace MakeWord
{
    class MakeWord
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            string word = "";
            for (int i = 0; i < n; i++)
            {
                var letter = Console.ReadLine();
                word += letter;
            }

            Console.WriteLine($"The word is: {word}");
        }
    }
}
