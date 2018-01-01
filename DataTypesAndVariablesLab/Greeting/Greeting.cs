using System;

namespace Greeting
{
    class Greeting
    {
        static void Main()
        {
            string firstName = Console.ReadLine();
            string lastName = Console.ReadLine();
            string ageStr = Console.ReadLine();
            int age = int.Parse(ageStr); // Parse string int
            Console.WriteLine($"Hello, {firstName} {lastName}.\r\nYou are {age} years old.");

        }
    }
}
