using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Rabbit_Hole
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var listOfStrings = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries).ToList();
            int energy = int.Parse(Console.ReadLine());

            bool killByBomb = false;
            var currentIndex = 0;

            while (energy > 0)
            {
                var currentObstacle = listOfStrings[currentIndex].Split('|');
                var command = currentObstacle[0];
                
                switch (command)
                {
                    case "RabbitHole":
                        Console.WriteLine("You have 5 years to save Kennedy!");
                        return;
                    case "Left":
                        var valueLeft = int.Parse(currentObstacle[1]);
                        energy -= valueLeft;
                        killByBomb = false;
                        valueLeft %= listOfStrings.Count;
                        currentIndex -= valueLeft;
                        currentIndex = Math.Abs(currentIndex);

                        break;
                    case "Right":
                        var valueRight = int.Parse(currentObstacle[1]);
                        energy -= valueRight;
                        killByBomb = false;
                        valueRight %= listOfStrings.Count;
                        currentIndex += valueRight;

                        if (currentIndex > listOfStrings.Count - 1)
                        {
                            currentIndex = currentIndex - listOfStrings.Count;
                        }

                        break;
                    case "Bomb":
                        var valueBomb = int.Parse(currentObstacle[1]);
                        energy -= valueBomb;
                        killByBomb = true;
                        listOfStrings.RemoveAt(currentIndex);
                        currentIndex = 0;
                        break;
                }

                if (listOfStrings[listOfStrings.Count -1] != "RabbitHole")
                {
                    listOfStrings.RemoveAt(listOfStrings.Count - 1);
                    listOfStrings.Add($"Bomb|{energy}");
                }
                else
                {
                    listOfStrings.Add($"Bomb|{energy}");
                }
                currentObstacle = listOfStrings[currentIndex].Split('|');
                command = currentObstacle[0];
            }

            if (killByBomb)
            {
                Console.WriteLine("You are dead due to bomb explosion!");
            }
            else
            {
                Console.WriteLine("You are tired. You can't continue the mission.");
            }
        }
    }
}
