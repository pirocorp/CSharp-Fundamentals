using System;

namespace GeometryCalculator
{
    class GeometryCalculator
    {
        static void Main()
        {
            string figureType = Console.ReadLine().ToLower().Trim();

            switch(figureType)
            {
                case "triangle":
                    double sideOfTriangle = double.Parse(Console.ReadLine());
                    double heightOfTriangle = double.Parse(Console.ReadLine());
                    double areaOfTriangle = GetAreaOfTriangle(sideOfTriangle, heightOfTriangle);
                    Console.WriteLine($"{areaOfTriangle:f2}");
                    break;
                case "square":
                    double sideOfSquare = double.Parse(Console.ReadLine());
                    double areaOfSquare = GetAreaOfSquare(sideOfSquare);
                    Console.WriteLine($"{areaOfSquare:f2}");
                    break;
                case "rectangle":
                    double width = double.Parse(Console.ReadLine());
                    double height = double.Parse(Console.ReadLine());
                    double areaOfRectangle = GetAreaOfRectangle(width, height);
                    Console.WriteLine($"{areaOfRectangle:f2}");
                    break;
                case "circle":
                    double radius = double.Parse(Console.ReadLine());
                    double areaOfCircle = GetAreaOfCircle(radius);
                    Console.WriteLine($"{areaOfCircle:f2}");
                    break;
                default: break;
            }
        }

        static double GetAreaOfCircle(double radius)
        {
            return Math.PI * radius * radius;
        }

        static double GetAreaOfRectangle(double width, double height)
        {
            return width * height;
        }

        static double GetAreaOfSquare(double sideOfSquare)
        {
            return sideOfSquare * sideOfSquare;
        }

        static double GetAreaOfTriangle(double sideOfTriangle, double heightOfTriangle)
        {
            return (sideOfTriangle * heightOfTriangle) / 2.0;
        }
    }
}
