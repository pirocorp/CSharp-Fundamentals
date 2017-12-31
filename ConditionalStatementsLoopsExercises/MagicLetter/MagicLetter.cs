using System;

namespace MagicLetter
{
    class MagicLetter
    {
        static void Main(string[] args)
        {
            var startLetter = char.Parse(Console.ReadLine());
            var endLetter = char.Parse(Console.ReadLine());
            var magicLetter = char.Parse(Console.ReadLine());

            for (char letter1 = startLetter; letter1 <= endLetter; letter1++)
            {
                for (char letter2 = startLetter; letter2 <= endLetter; letter2++)
                {
                    for (char letter3 = startLetter; letter3 <= endLetter; letter3++)
                    {
                        if (letter1 != magicLetter && letter2 != magicLetter && letter3 != magicLetter)
                        {
                            Console.Write($"{letter1}{letter2}{letter3} ");
                        }
                    }
                }
            }

            Console.WriteLine();
        }
    }
}
