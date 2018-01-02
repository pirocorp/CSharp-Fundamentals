using System;
using System.Numerics;

namespace DifferentIntegersSize
{
    class DifferentIntegersSize
    {
        static void Main()
        {
            BigInteger num = BigInteger.Parse(Console.ReadLine());

            if (num > long.MaxValue || num < long.MinValue)
            {
                Console.WriteLine($"{num} can't fit in any type");
            }
            else
            {
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
        }
    }
}
