using System;

namespace DecryptingMessages
{
    class DecryptingMessages
    {
        static void Main()
        {
            var key = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            string result = "";

            for (int i = 0; i < n; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                letter += (char)key;
                result += letter;
            }

            Console.WriteLine(result);
        }
    }
}
