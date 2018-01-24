using System;
using System.IO;

namespace _01.Filter_Extensions
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var dir = new DirectoryInfo("../../input");
            var result = dir.GetFiles($"*.{input}");

            foreach (var file in result)
            {
                Console.WriteLine($"{file.Name}");
            }
        }
    }
}
