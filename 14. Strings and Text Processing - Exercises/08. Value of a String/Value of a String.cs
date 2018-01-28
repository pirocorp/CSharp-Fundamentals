namespace _08.Value_of_a_String
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var inputString = Console.ReadLine();
            var command = Console.ReadLine();

            var lowercase = inputString.Where(x => char.IsLower(x)).Sum(x => x);
            var uppercase = inputString.Where(x => char.IsUpper(x)).Sum(x => x);

            switch (command)
            {
                case "LOWERCASE":
                    Console.WriteLine($"The total sum is: {lowercase}");
                    break;
                case "UPPERCASE":
                    Console.WriteLine($"The total sum is: {uppercase}");
                    break;
            }

        }
    }
}