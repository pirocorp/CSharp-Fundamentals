using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JapaneseRoulette
{
    class Program
    {
        static void Main(string[] args)
        {
            var cylinder = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var players = Console.ReadLine()
                .Split()
                .ToList();

            var deadMan = false;
            var deadPlayer = 0;

            foreach (var player in players)
            {
                var spinInfo = player
                    .Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .Select(a => a.Trim())
                    .ToArray();

                var spinStrength = int.Parse(spinInfo[0]) % cylinder.Count;
                var spinDirection = spinInfo[1];

                if (spinDirection == "Left")
                {
                    cylinder = SpinLeft(cylinder, spinStrength);

                }
                else if (spinDirection == "Right")
                {
                    cylinder = SpinRight(cylinder, spinStrength);
                }

                if (cylinder[2] == 1)
                {
                    deadMan = true;
                    deadPlayer = players.IndexOf(player);
                    break;
                }
                cylinder = SpinRight(cylinder, 1); //Trigger
            }

            if (deadMan)
            {
                Console.WriteLine($"Game over! Player {deadPlayer} is dead.");
            }
            else
            {
                Console.WriteLine("Everybody got lucky!");
            }
        }

        private static List<int> SpinLeft(List<int> cylinder, int spinStrength)
        {
            for (int i = 0; i < spinStrength; i++)
            {
                cylinder = cylinder
                    .Skip(1)
                    .Concat(cylinder.Take(1))
                    .ToList();
            }
            return cylinder;
        }

        private static List<int> SpinRight(List<int> cylinder, int spinStrength)
        {
            for (int i = 0; i < spinStrength; i++)
            {
                cylinder = cylinder
                    .Skip(cylinder.Count - 1)
                    .Concat(cylinder.Take(cylinder.Count - 1))
                    .ToList();
            }
            return cylinder;
        }
    }
}