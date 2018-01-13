using System;

namespace RefactorVolumePyramid
{
    class RefactorVolumePyramid
    {
        static void Main()
        {
            Console.Write("Length: ");
            var Length = double.Parse(Console.ReadLine());
            Console.Write("Width: ");
            var Width = double.Parse(Console.ReadLine());
            Console.Write("Height: ");
            var Height = double.Parse(Console.ReadLine());
            var volume = (Length * Width * Height) / 3;
            Console.WriteLine("Pyramid Volume: {0:F2}", volume);
        }
    }
}
