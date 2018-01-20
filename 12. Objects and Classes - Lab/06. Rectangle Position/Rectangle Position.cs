using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Rectangle_Position
{
    class Program
    {
        static void Main()
        {
            Rectangle r1 = ReadRectangle(), r2 = ReadRectangle();
            Console.WriteLine(r1.IsInside(r2) ? "Inside" : "Not inside");
        }

        public class Rectangle
        {
            public int Top { get; set; }
            public int Left { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }

            public int Right { get { return Left + Width; } }
            public int Bottom { get { return Top + Height; } }

            public bool IsInside(Rectangle other)
            {
                var isInLeft = this.Left >= other.Left;
                var isInRight = this.Right <= other.Right;
                var isInsideHorizontal = isInLeft && isInRight;
                var isInTop = this.Top >= other.Top;
                var isInBottom = this.Bottom <= other.Bottom;
                var isInsideVertical = isInTop && isInBottom;
                return isInsideHorizontal && isInsideVertical;
            }
        }

        public static Rectangle ReadRectangle()
        {
            var sizes = Console.ReadLine().Split().Select(int.Parse);
            Rectangle rectangle = new Rectangle()
            {
                Left = sizes.First(),
                Top = sizes.Skip(1).First(),
                Width = sizes.Skip(2).First(),
                Height = sizes.Skip(3).First()
            };
            return rectangle;
        }
    }
}
