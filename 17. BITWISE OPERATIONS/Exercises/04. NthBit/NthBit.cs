namespace _04._NthBit
{
    using System;

    public class NthBit
    {
        public static void Main()
        {
            var num = 255;
            var pos = 7;
            var nthBit = GetNthBit(num, pos);
            Console.WriteLine(nthBit);
        }

        private static int GetNthBit(int num, int pos)
        {
            var mask = 1 << pos;
            var result = num & mask;
            return result >> pos;
        }
    }
}
