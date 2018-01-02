using System;
//using System.Numerics;

namespace DifferentIntegersSize
{
    class DifferentIntegersSize
    {
        static void Main()
        {
            var numString = Console.ReadLine();
            try
            {                
                var num = long.Parse(numString);

                Console.WriteLine($"{num} can fit in:");
                if (num >= sbyte.MinValue && num <= sbyte.MaxValue)
                {
                    Console.WriteLine("* sbyte");
                }
                if (num >= byte.MinValue && num <= byte.MaxValue)
                {
                    Console.WriteLine("* byte");
                }
                if (num >= short.MinValue && num <= short.MaxValue)
                {
                    Console.WriteLine("* short");
                }
                if (num >= ushort.MinValue && num <= ushort.MaxValue)
                {
                    Console.WriteLine("* ushort");
                }
                if (num >= int.MinValue && num <= int.MaxValue)
                {
                    Console.WriteLine("* int");
                }
                if (num >= uint.MinValue && num <= uint.MaxValue)
                {
                    Console.WriteLine("* uint");
                }
                if (num >= long.MinValue && num <= long.MaxValue)
                {
                    Console.WriteLine("* long");
                }
            }
            catch
            {
                //BigInteger num = BigInteger.Parse(Console.ReadLine());
                Console.WriteLine($"{numString} can't fit in any type");
            }
        }
    }
}
