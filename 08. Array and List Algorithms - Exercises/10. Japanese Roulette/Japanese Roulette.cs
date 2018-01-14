using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JapaneseRoulette
{
    class Program
    {
        static void Main()
        {
            var cylinder = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var players = Console.ReadLine()
                .Split()
                .ToList();

            var deadMan = false;
            var deadPlayerIndex = -1;


            for (var playerIndex = 0; playerIndex < players.Count; playerIndex++)
            {
                var currentPlayer = players[playerIndex].Split(',').ToArray();
                var command = currentPlayer[1];
                var power = int.Parse(currentPlayer[0]);
                power %= cylinder.Count;

                switch (command)
                {
                    case "Left":
                        SpinLeft(cylinder, power);
                        break;
                    case "Right":
                        SpinRight(cylinder, power);
                        break;
                }

                if (cylinder[2] == 1)
                {
                    deadMan = true;
                    deadPlayerIndex = playerIndex;
                    break;
                }

                SpinRight(cylinder, 1);
            }

            if (deadMan)
            {
                Console.WriteLine($"Game over! Player {deadPlayerIndex} is dead.");
            }
            else
            {
                Console.WriteLine("Everybody got lucky!");
            }
        }

        private static void SpinRight(List<int> cylinder, int power)
        {
            for (int i = 0; i < power; i++)
            {
                var swap = cylinder[cylinder.Count - 1];
                cylinder.RemoveAt(cylinder.Count -1);
                cylinder.Insert(0, swap);
            }
        }

        private static void SpinLeft(List<int> cylinder, int power)
        {
            for (int i = 0; i < power; i++)
            {
                var swap = cylinder[0];
                cylinder.RemoveAt(0);
                cylinder.Add(swap);
            } 
        }
    }
}