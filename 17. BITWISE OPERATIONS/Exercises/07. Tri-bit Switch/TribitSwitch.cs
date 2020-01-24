namespace _07._Tri_bit_Switch
{
    using System;

    public class TriBitSwitch
    {
        public static void Main()
        {
            var number = int.Parse(Console.ReadLine());
            var pos = int.Parse(Console.ReadLine());

            var result = BitSwitch(number, pos);
            Console.WriteLine(result);
        }

        private static int BitSwitch(int number, int pos)
        {
            var mask = 7 << pos;
            var result = number ^ mask; //Coping and Negating bytes
            return result;
        }
    }
}