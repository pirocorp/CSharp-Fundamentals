namespace _02._SwapTwoNumbers
{
    using System;

    public class SwapTwoNumbers
    {
        public static void Main()
        {
            var x = 3;
            var y = 7;

            Console.WriteLine($"Initial values: x = {x}, y = {y}");

            SwapNumbers(ref x, ref y);

            Console.WriteLine($"After swapping: x = {x}, y = {y}");

            SwapNumbersBitwise(ref x, ref y);

            Console.WriteLine($"Yet another swapping: x = {x}, y = {y}");
        }

        private static void SwapNumbersBitwise(ref int x, ref int y)
        {
            //Code to swap 'x' (1010) and 'y' (0101)
            x ^= y; //x now becomes 15 (1111)
            y = x ^ y; //y becomes 10 (1010)
            x ^= y; //x becomes 5 (0101)
        }

        private static void SwapNumbers(ref int x, ref int y)
        {
            x += y;
            y = x - y;
            x -= y;
        }
    }
}