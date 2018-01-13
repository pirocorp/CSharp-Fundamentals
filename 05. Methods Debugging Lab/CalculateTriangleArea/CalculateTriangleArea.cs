using System;

namespace CalculateTriangleArea
{
    class CalculateTriangleArea
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Console.WriteLine(CalcTriangleArea(width, height));
        }

        static double CalcTriangleArea(double width, double height)
        {
            return width * height / 2;
        }
    }
}
