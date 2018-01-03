using System;

namespace BoatSimulator
{
    class BoatSimulator
    {
        static void Main()
        {
            char firstBoat = char.Parse(Console.ReadLine());
            char secondBoat = char.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            var firstBoatMovedDistance = 0;
            var secondBoatMovedDistance = 0;

            for (int i = 1; i <= n; i++)
            {
                if (firstBoatMovedDistance >= 50 || secondBoatMovedDistance >= 50)
                {
                    break;
                }

                string line = Console.ReadLine();

                if (i % 2 == 1)
                {
                    firstBoatMovedDistance += line.Length;
                }
                else
                {
                    secondBoatMovedDistance += line.Length;
                }

                if (line == "UPGRADE")
                {
                    firstBoat += (char)3;
                    secondBoat += (char)3;
                }
            }

            if (firstBoatMovedDistance > secondBoatMovedDistance)
            {
                Console.WriteLine(firstBoat);
            }
            else if (secondBoatMovedDistance > firstBoatMovedDistance)
            {
                Console.WriteLine(secondBoat);
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }
    }
}
