using System;


namespace TriangleFormations
{
    class TriangleFormations
    {
        static void Main()
        {
            int sideA = int.Parse(Console.ReadLine());
            int sideB = int.Parse(Console.ReadLine());
            int sideC = int.Parse(Console.ReadLine());

            bool isValid = (sideA < (sideB + sideC) && sideB < (sideA + sideC) && sideC < (sideA + sideB));
            bool sideAIshypotenuse = (Math.Pow(sideA, 2) == Math.Pow(sideB, 2) + Math.Pow(sideC, 2));
            bool sideBIshypotenuse = (Math.Pow(sideB, 2) == Math.Pow(sideA, 2) + Math.Pow(sideC, 2));
            bool sideCIshypotenuse = (Math.Pow(sideC, 2) == Math.Pow(sideA, 2) + Math.Pow(sideB, 2));

            if (isValid)
            {
                Console.WriteLine("Triangle is valid.");
            }
            else
            {
                Console.WriteLine("Invalid Triangle.");
                return;
            }

            if (sideAIshypotenuse)
            {
                Console.WriteLine("Triangle has a right angle between sides b and c");
            }
            else if (sideBIshypotenuse)
            {
                Console.WriteLine("Triangle has a right angle between sides a and c");
            }
            else if (sideCIshypotenuse)
            {
                Console.WriteLine("Triangle has a right angle between sides a and b");
            }
            else
            {
                Console.WriteLine("Triangle has no right angles");
            }
        }
    }
}
