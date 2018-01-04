using System;

namespace CubeProperties
{
    class CubeProperties
    {
        static void Main()
        {
            double cubeSide = double.Parse(Console.ReadLine());
            string propertiOfCube = Console.ReadLine().ToLower().Trim();

            switch (propertiOfCube)
            {
                case "face": Console.WriteLine($"{Math.Sqrt(2 * cubeSide * cubeSide):f2}"); break;
                case "space": Console.WriteLine($"{Math.Sqrt(3 * cubeSide * cubeSide):f2}"); break;
                case "volume": Console.WriteLine($"{cubeSide * cubeSide * cubeSide:f2}"); break;
                case "area": Console.WriteLine($"{6 * cubeSide * cubeSide:f2}"); break;
            }
        }
    }
}
