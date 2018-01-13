using System;

namespace IntegerToHexAndBinary
{
    class IntegerToHexAndBinary
    {
        static void Main()
        {
            var decNum = int.Parse(Console.ReadLine());

            string binNum = Convert.ToString(decNum, 2);
            string hexNum = Convert.ToString(decNum, 16);
            hexNum = hexNum.ToUpper();

            Console.WriteLine(hexNum);
            Console.WriteLine(binNum);
        }
    }
}
