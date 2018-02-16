namespace _18.Email_me
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var email = Console.ReadLine();
            var tokens = email.Split(new[] {'@'}, StringSplitOptions.RemoveEmptyEntries);
            var result = tokens[0].Sum(x => x) - tokens[1].Sum(x => x);

            if (result >= 0)
            {
                Console.WriteLine("Call her!");
            }
            else
            {
                Console.WriteLine($"She is not the one.");
            }
        }
    }
}
