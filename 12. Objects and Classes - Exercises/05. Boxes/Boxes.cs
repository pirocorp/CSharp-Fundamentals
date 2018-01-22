using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Boxes
{
    class Boxes
    {
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public static double CalculateDistance(Point p1, Point p2)
            {
                var deltaX = p2.X - p1.X;
                var deltaY = p2.Y - p1.Y;
                return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            }

            public static Point Parse(string inputData)
            {
                var pointInfo = inputData.Split(new []{ ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .Select(int.Parse)
                    .ToArray();

                var point = new Point()
                {
                    X = pointInfo[0],
                    Y = pointInfo[1]
                };

                return point;
            }
        }

        public class Box
        {
            public Point UpperLeft { get; set; }
            public Point UpperRight { get; set; }
            public Point BottomLeft { get; set; }
            public Point BottomRight { get; set; }

            public double Width
            {
                get
                {
                    return Point.CalculateDistance(UpperLeft, UpperRight);
                }
            }

            public double Height
            {
                get
                {
                    return Point.CalculateDistance(UpperLeft, BottomLeft);
                }
            }

            public static Box Parse(string inputData)
            {
                var tokens = inputData
                    .Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => x.Trim())
                    .ToArray();

                var upperLeft = Point.Parse(tokens[0]);
                var upperRight = Point.Parse(tokens[1]);
                var bottomLeft = Point.Parse(tokens[2]);
                var bottomRight = Point.Parse(tokens[3]);

                var result = new Box()
                {
                    UpperLeft = upperLeft,
                    UpperRight = upperRight,
                    BottomLeft = bottomLeft,
                    BottomRight = bottomRight
                };

                return result;
            }

            public static double CalculatePerimeter(double width, double height)
            {
                return (2 * width + 2 * height);
            }

            public static double CalculateArea(double width, double height)
            {
                return (width * height);
            }
        }


        static void Main()
        {
            var inputData = Console.ReadLine();
            var listOfBoxes = new List<Box>();

            while (inputData != "end")
            {
                listOfBoxes.Add(Box.Parse(inputData));
                inputData = Console.ReadLine();
            }

            foreach (var box in listOfBoxes)
            {
                Console.WriteLine($"Box: {box.Width}, {box.Height}");
                Console.WriteLine($"Perimeter: {Box.CalculatePerimeter(box.Width, box.Height)}");
                Console.WriteLine($"Area: {Box.CalculateArea(box.Width, box.Height)}");
            }
        }
    }
}
