using System;

namespace LongerLine
{
    class LongerLine
    {
        static void Main()
        {
            var line1X1 = double.Parse(Console.ReadLine());
            var line1Y1 = double.Parse(Console.ReadLine());
            var line1X2 = double.Parse(Console.ReadLine());
            var line1Y2 = double.Parse(Console.ReadLine());
            var line2X1 = double.Parse(Console.ReadLine());
            var line2Y1 = double.Parse(Console.ReadLine());
            var line2X2 = double.Parse(Console.ReadLine());
            var line2Y2 = double.Parse(Console.ReadLine());

            PrintLongerLine(line1X1, line1Y1, line1X2, line1Y2, line2X1, line2Y1, line2X2, line2Y2);

        }

        static void PrintLongerLine(double line1X1, double line1Y1, double line1X2, double line1Y2, 
            double line2X1, double line2Y1, double line2X2, double line2Y2)
        {
            var line1XComponent = line1X1 - line1X2;
            var line1YComponent = line1Y1 - line1Y2;
            var line2XComponent = line2X1 - line2X2;
            var line2YComponent = line2Y1 - line2Y2;

            var line1Size = Math.Sqrt(line1XComponent * line1XComponent + line1YComponent * line1YComponent);
            var line2Size = Math.Sqrt(line2XComponent * line2XComponent + line2YComponent * line2YComponent);

            if (line1Size >= line2Size)
            {
                PrintClosestToCenterPoint(line1X1, line1Y1, line1X2, line1Y2);
            }
            else
            {
                PrintClosestToCenterPoint(line2X1, line2Y1, line2X2, line2Y2);
            }
        }

        static void PrintClosestToCenterPoint(double x1, double y1, double x2, double y2)
        {
            var distanceToCenterPoint1 = Math.Sqrt(Math.Pow(x1, 2) + Math.Pow(y1, 2));
            var distanceToCenterPoint2 = Math.Sqrt(Math.Pow(x2, 2) + Math.Pow(y2, 2));
            if (distanceToCenterPoint1 <= distanceToCenterPoint2) Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            else Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
        }
    }
}
