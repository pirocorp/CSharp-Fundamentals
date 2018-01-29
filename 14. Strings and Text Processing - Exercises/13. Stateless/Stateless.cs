namespace _13.Stateless
{
    using System;

    class Stateless
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            while (inputLine != "collapse")
            {
                var fiction = Console.ReadLine();
                var colapsedInputLine = ColapseString(inputLine, fiction);

                if (colapsedInputLine.Length == 0)
                {
                    Console.WriteLine("(void)");
                }
                else
                {
                    Console.WriteLine(colapsedInputLine);
                }

                inputLine = Console.ReadLine();
            }
        }

        private static string ColapseString(string inputLine, string fiction)
        {
            while (fiction.Length > 0)
            {
                inputLine = inputLine.Replace(fiction, string.Empty);
                fiction = fiction.Substring(1, Math.Max(0, fiction.Length - 2));
            }

            return inputLine.Trim();
        }
    }
}