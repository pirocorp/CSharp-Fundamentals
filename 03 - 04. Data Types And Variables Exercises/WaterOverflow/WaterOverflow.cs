using System;

namespace WaterOverflow
{
    class WaterOverflow
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var waterInTank = 0;


            for (int i = 0; i < n; i++)
            {
                var water = int.Parse(Console.ReadLine());
                if (waterInTank + water > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    waterInTank += water;
                }
            }

            Console.WriteLine(waterInTank);
        }
    }
}
