using System;

namespace HelloName
{
    class HelloName
    {
        static void Main()
        {
            var name = Console.ReadLine();

            PrintName(name);
        }

        private static void PrintName(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}
