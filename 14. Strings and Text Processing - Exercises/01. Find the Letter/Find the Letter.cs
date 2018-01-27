namespace _01.Find_the_Letter
{
    using System;

    class Program
    {
        static void Main()
        {
            var inputString = Console.ReadLine();
            var inputCommand = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var leterToSearch = inputCommand[0];
            var letterOccurrence = int.Parse(inputCommand[1]);

            var occurrence = 0;
            var indexOfOccurrence = -1;
            var currentOccurrence = -1;

            while (occurrence < letterOccurrence || inputString.IndexOf(leterToSearch, currentOccurrence + 1) > 0)
            {
                currentOccurrence = inputString.IndexOf(leterToSearch, currentOccurrence + 1);

                if (++occurrence == letterOccurrence)
                {
                    indexOfOccurrence = currentOccurrence;
                }
            }

            if (indexOfOccurrence < 0)
            {
                Console.WriteLine($"Find the letter yourself!");
            }
            else
            {
                Console.WriteLine(indexOfOccurrence);
            }
        }
    }
}