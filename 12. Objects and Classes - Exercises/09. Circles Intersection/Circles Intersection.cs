using System;

namespace _09.Circles_Intersection
{
    class Program
    {
        static void Main()
        {
            var circle1 = Circle.Parse(Console.ReadLine());
            var circle2 = Circle.Parse(Console.ReadLine());

            if (Intersect(circle1, circle2))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        public static bool Intersect(Circle c1, Circle c2)
        {
            var distance = Point.CalculateDistance(c1.Center, c2.Center);
            var sumOfRadiuses = c1.Radius + c2.Radius;

            if (distance <= sumOfRadiuses)
            {
                return true;
            }

            return false;
        }
    }
}
