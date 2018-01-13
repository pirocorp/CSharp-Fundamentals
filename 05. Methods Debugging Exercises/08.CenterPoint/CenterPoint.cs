using System;

namespace CenterPoint
{
    class CenterPoint
    {
        static void Main()
        {
            var x1 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());

            PrintClosestToCenterPoint(x1, y1, x2, y2);
        }

        static void PrintClosestToCenterPoint(double x1, double y1, double x2, double y2)
        {
            var distanceToCenterPoint1 = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            var distanceToCenterPoint2 = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            if (distanceToCenterPoint1 <= distanceToCenterPoint2) Console.WriteLine($"({x1}, {y1})");
            else Console.WriteLine($"({x2}, {y2})");          
        }
    }
}
