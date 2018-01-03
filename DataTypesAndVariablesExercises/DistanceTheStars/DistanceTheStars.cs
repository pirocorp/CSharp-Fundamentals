using System;

namespace DistanceTheStars
{
    class DistanceTheStars
    {
        static void Main()
        {
            double proximaCentauri = 4.22;
            double theCenterOfGalaxy = 26000;
            double milkyWay = 100000;
            double observableUniverse = 46500000000;
            double lightYear = 9450000000000;

            proximaCentauri *= lightYear;
            theCenterOfGalaxy *= lightYear;
            milkyWay *= lightYear;
            observableUniverse *= lightYear;

            Console.WriteLine($"{proximaCentauri:e2}");
            Console.WriteLine($"{theCenterOfGalaxy:e2}");
            Console.WriteLine($"{milkyWay:e2}");
            Console.WriteLine($"{observableUniverse:e2}");
        }
    }
}
