using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26.Immune_System
{
    class Program
    {
        static void Main()
        {
            var viruses = new List<string>();
            var health = int.Parse(Console.ReadLine());
            var inputData = Console.ReadLine();
            double remainingHealth = health;

            while (inputData != "end")
            {
                var virusName = inputData;
                double virusStrengthOriginal = (int)(inputData.Sum(x => x) / 3.0);
                var virusStrength = virusStrengthOriginal;
                if (viruses.Contains(virusName))
                {
                    virusStrength = (virusStrength / 3.0);
                }
                else
                {
                    viruses.Add(virusName);
                }

                var TimeToDefeatInSec = (int)(virusStrength * virusName.Length);
                Console.WriteLine($"Virus {virusName}: {virusStrengthOriginal} => {TimeToDefeatInSec} seconds");

                if (TimeToDefeatInSec < remainingHealth)
                {
                    var defeatMins = (int)TimeToDefeatInSec / 60;
                    var defeatSecs = (int)TimeToDefeatInSec % 60;
                    Console.WriteLine($"{virusName} defeated in {defeatMins}m {defeatSecs}s.");
                    remainingHealth -= TimeToDefeatInSec;
                    Console.WriteLine($"Remaining health: {remainingHealth}");
                }
                else
                {
                    Console.WriteLine("Immune System Defeated.");
                    return;
                }

                remainingHealth = Math.Min(health, (int)Math.Floor(remainingHealth * 1.2));
                inputData = Console.ReadLine();
            }

            Console.WriteLine($"Final Health: {remainingHealth}");
        }
    }
}
