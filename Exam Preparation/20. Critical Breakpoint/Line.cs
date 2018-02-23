using System;
using System.Linq;

namespace _20.Critical_Breakpoint
{
    public class Line
    {
        public Line(Point pointOne, Point pointTwo)
        {
            PointOne = pointOne;
            PointTwo = pointTwo;
        }

        public Point PointOne { get; set; }
        public Point PointTwo { get; set; }

        public long CriticalRatio
        {
            get
            {
                var x1 = PointOne.X;
                var y1 = PointOne.Y;
                var x2 = PointTwo.X;
                var y2 = PointTwo.Y;
                var criticalRatio = Math.Abs((x2 + y2) - (x1 + y1));
                return criticalRatio;
            }
        }

        public static Line Parse(string inputLine)
        {
            var numbers = inputLine
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
            var pointOneX = numbers[0];
            var pointOneY = numbers[1];
            var pointOne = new Point(pointOneX, pointOneY);
            var pointTwoX = numbers[2];
            var pointTwoY = numbers[3];
            var pointTwo = new Point(pointTwoX, pointTwoY);

            return new Line(pointOne, pointTwo);
        }
    }
}
