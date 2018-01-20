using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Closest_Two_Points
{
    class Program
    {
        class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

        static void Main()
        {
            Point[] points = ReadPoints();
            Point[] closestPoints = FindClosestTwoPoints(points);

            PrintDistance(closestPoints);

            PrintPoint(closestPoints[0]);
            PrintPoint(closestPoints[1]);
        }

        static Point[] ReadPoints()
        {
            var n = int.Parse(Console.ReadLine());

            Point[] points = new Point[n];

            for (int i = 0; i < n; i++)
            {
                points[i] = ReadPoint();
            }

            return points;
        }

        static void PrintPoint(Point point)
        {
            Console.WriteLine("({0}, {1})", point.X, point.Y);
        }

        static void PrintDistance(Point[] points)
        {
            var distance = CalcDistance(points[0], points[1]);
            Console.WriteLine("{0:f3}", distance);
        }

        static Point[] FindClosestTwoPoints(Point[] points)
        {
            var minDistance = double.MaxValue;
            Point[] closestTwoPoints = null;

            for (int p1 = 0; p1 < points.Length; p1++)
            {
                for (int p2 = p1 + 1; p2 < points.Length; p2++)
                {
                    var distance = CalcDistance(points[p1], points[p2]);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestTwoPoints = new Point[] {points[p1], points[p2]};
                    }
                }
            }

            return closestTwoPoints;
        }

        static Point ReadPoint()
        {
            int[] pointInfo = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            var point = new Point();
            point.X = pointInfo[0];
            point.Y = pointInfo[1];
            return point;
        }

        static double CalcDistance(Point p1, Point p2)
        {
            var deltaX = p2.X - p1.X;
            var deltaY = p2.Y - p1.Y;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
    }
}
