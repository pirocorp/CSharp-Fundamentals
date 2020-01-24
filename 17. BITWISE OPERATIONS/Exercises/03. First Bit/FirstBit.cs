namespace _03._First_Bit
{
    using System;

    public class FirstBit
    {
        public static void Main()
        {
            var n = 126;
            var bit = GetFirstBit(n);
            Console.WriteLine(bit);
        }

        private static int GetFirstBit(int n)
        {
            //var shiftedNumber = n >> 1;
            //var result = shiftedNumber & 1;
            var result = n & 2;
            return result >> 1;
        }
    }
}
