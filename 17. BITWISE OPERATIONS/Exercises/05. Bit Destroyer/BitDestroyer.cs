namespace _05._Bit_Destroyer
{
    using System;

    public class BitDestroyer
    {
        public static void Main()
        {
            var pos = 6;
            var number = 111;
            var result = DestroyBitAt(number, pos);
            Console.WriteLine(result);
        }

        private static int DestroyBitAt(int number, int pos)
        {
            var mask = ~(1 << pos); //Negating the mask mask = ~mask;
            return number & mask; //Copying bites
        }
    }
}