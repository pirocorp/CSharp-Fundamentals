using System;
using System.Linq;

namespace _09.Circles_Intersection
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public static double CalculateDistance(Point p1, Point p2)
        {
            var deltaX = p2.X - p1.X;
            var deltaY = p2.Y - p1.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        public static Point Parse(string inputData)
        {
            var pointInfo = inputData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Select(double.Parse)
                .ToArray();

            var point = new Point()
            {
                X = pointInfo[0],
                Y = pointInfo[1]
            };

            return point;
        }
    }
}
