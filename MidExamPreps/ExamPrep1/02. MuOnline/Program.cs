namespace _02._MuOnline
{
    using System;
    using System.Linq;

    public static class Program
    {
        public static void Main()
        {
            var health = 100;
            var bitcoins = 0;

            var rooms = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            for (var index = 0; index < rooms.Count; index++)
            {
                var room = rooms[index];
                var tokens = room
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var command = tokens[0];
                var value = int.Parse(tokens[1]);

                switch (command)
                {
                    case "potion":
                        Console.WriteLine($"You healed for {Math.Min(value, 100 - health)} hp.");
                        health = Math.Min(100, health + value);
                        Console.WriteLine($"Current health: {health} hp.");
                        break;
                    case "chest":
                        Console.WriteLine($"You found {value} bitcoins.");
                        bitcoins += value;
                        break;
                    default:
                        health -= value;
                        if (health > 0)
                        {
                            Console.WriteLine($"You slayed {command}.");
                        }
                        else
                        {
                            Console.WriteLine($"You died! Killed by {command}.");
                            Console.WriteLine($"Best room: {index + 1}");
                            return;
                        }
                        break;
                }
            }

            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {bitcoins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
