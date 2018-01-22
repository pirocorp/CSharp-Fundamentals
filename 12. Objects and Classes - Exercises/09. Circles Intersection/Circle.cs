using System;
using System.Linq;

namespace _09.Circles_Intersection
{
    public class Circle
    {
        public Point Center { get; set; }
        public double Radius { get; set; }

        public static Circle Parse (string inputData)
        {
            var tokens = inputData.Split(' ').ToList();
            var radius = double.Parse(tokens[2]);
            tokens.RemoveAt(2);
            var center = Point.Parse(String.Join(" ", tokens));

            var result = new Circle()
            {
                Radius = radius,
                Center = center
            };

            return result;
        }
    }
}


