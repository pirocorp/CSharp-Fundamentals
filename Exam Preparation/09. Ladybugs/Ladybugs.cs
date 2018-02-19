namespace _09.Ladybugs
{
    using System;
    using System.Linq;

    class Ladybugs
    {
        static void Main()
        {
            var sizeOfField = int.Parse(Console.ReadLine());
            var listOfBugIndexes = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            listOfBugIndexes = listOfBugIndexes.Where(x => x < sizeOfField && x >= 0).ToArray();
            var field = new int [sizeOfField];

            for (var i = 0; i < listOfBugIndexes.Length; i++)
            {
                var currentIndex = listOfBugIndexes[i];
                field[currentIndex] = 1;
            }

            var command = Console.ReadLine();

            while (command != "end")
            {
                var tokens = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var bugIndex = long.Parse(tokens[0]);
                var direction = tokens[1];
                var flyLenght = long.Parse(tokens[2]);

                if (bugIndex >= field.Length || bugIndex < 0)
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (field[bugIndex] == 1)
                {
                    MoveBugInDirection(bugIndex, direction, flyLenght, field);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", field));
        }

        private static void MoveBugInDirection(long bugIndex, string direction, long flyLenght, int[] field)
        {
            field[bugIndex] = 0;

            if (direction == "left")
            {
                flyLenght *= -1;
            }

            while (true)
            {
                bugIndex = bugIndex + flyLenght;

                if (bugIndex >= field.Length || bugIndex < 0)
                {
                    return;
                }

                if (field[bugIndex] == 0)
                {
                    field[bugIndex] = 1;
                    break;
                }
            }
        }
    }
}