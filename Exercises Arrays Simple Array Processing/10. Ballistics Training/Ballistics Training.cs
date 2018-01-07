using System;
using System.Linq;

namespace _10.Ballistics_Training
{
    class Program
    {
        static void Main()
        {
            char[] delimeter = {' '};
            int[] point = Console.ReadLine()
                .Split(delimeter, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string[] inputCommands = Console.ReadLine()
                .Split(delimeter, StringSplitOptions.RemoveEmptyEntries);

            int pointX = 0;
            int pointY = 0;

            for (int i = 0; i < inputCommands.Length; i += 2)
            {
                switch (inputCommands[i])
                {
                    case "right":
                        pointX += int.Parse(inputCommands[i + 1]);
                        break;
                    case "down":
                        pointY -= int.Parse(inputCommands[i + 1]);
                        break;
                    case "left":
                        pointX -= int.Parse(inputCommands[i + 1]);
                        break;
                    case "up":
                        pointY += int.Parse(inputCommands[i + 1]);
                        break;
                    default: break;
                }

                if (pointX == point[0] && pointY == point[1])
                {
                    Console.WriteLine($"firing at [{pointX}, {pointY}] got 'em!");
                    return;
                }
            }

            Console.WriteLine($"firing at [{pointX}, {pointY}] better luck next time...");
        }
    }
}
