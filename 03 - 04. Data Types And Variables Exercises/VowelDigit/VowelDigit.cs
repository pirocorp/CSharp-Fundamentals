using System;

namespace VowelDigit
{
    class VowelDigit
    {
        static void Main()
        {
            char symbol = char.Parse(Console.ReadLine().ToLower());

            if (symbol == 'a' || symbol == 'e' || symbol == 'i' || symbol == 'o' || symbol == 'u')
            {
                Console.WriteLine("vowel");
            }
            else if (symbol >= 48 && symbol <= 57)
            {
                Console.WriteLine("digit");
            }
            else
            {
                Console.WriteLine("other");
            }
        }
    }
}
