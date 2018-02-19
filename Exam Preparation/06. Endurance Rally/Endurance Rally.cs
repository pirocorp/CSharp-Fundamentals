namespace _06.Endurance_Rally
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var participants = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var trackLayout = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            var checkPointsIndexes = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (var i = 0; i < participants.Length; i++)
            {
                var currentParticipant = participants[i];
                var startingFuel = (double)currentParticipant[0];
                var kvp = ProcessFuel(startingFuel, trackLayout, checkPointsIndexes);
                var reached = kvp.Key;
                var fuelLeft = kvp.Value;

                if (reached == trackLayout.Length - 1)
                {
                    Console.WriteLine($"{currentParticipant} - fuel left {fuelLeft:F2}");
                }
                else
                {
                    Console.WriteLine($"{currentParticipant} - reached {reached + 1}");
                }
            }
        }

        private static KeyValuePair<int, double> ProcessFuel(double startingFuel, double[] trackLayout, int[] checkPointsIndexes)
        {
            var reached = - 1;

            for (var i = 0; i < trackLayout.Length; i++)
            {
                if (checkPointsIndexes.Contains(i))
                {
                    startingFuel += trackLayout[i];
                }
                else
                {
                    startingFuel -= trackLayout[i];
                }

                if (startingFuel <= 0)
                {
                    break;
                }

                reached = i;
            }

            startingFuel = Math.Max(0, startingFuel);
            return new KeyValuePair<int, double>(reached, startingFuel);
        }
    }
}