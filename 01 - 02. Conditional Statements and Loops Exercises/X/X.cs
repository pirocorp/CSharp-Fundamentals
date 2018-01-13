using System;

namespace X
{
    class X
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var spaces = 0;
            var innerspaces = n - 2;

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine("{1}x{0}x{1}", new string(' ', innerspaces), new string(' ', spaces));
                spaces++;
                innerspaces -= 2;

            }

            Console.WriteLine("{0}x{0}", new string(' ', spaces));
            spaces--;
            innerspaces += 2;

            for (int i = n / 2; i > 0; i--)
            {
                Console.WriteLine("{1}x{0}x{1}", new string(' ', innerspaces), new string(' ', spaces));
                spaces--;
                innerspaces += 2;

            }
        }
    }
}
