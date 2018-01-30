namespace _16.Convert_from_base_10_to_base_N
{
    using System;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            var tokens = Console.ReadLine().Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numberBase = BigInteger.Parse(tokens[0]);
            var numberInDec = BigInteger.Parse(tokens[1]);
            BigInteger multiplayer = 1;
            BigInteger currentDigitInNBase = 0;

            if (numberBase == 0)
            {
                Console.WriteLine("Error");
            }

            if (numberBase == 1)
            {
                Console.WriteLine("Error");
            }

            while (numberInDec > 0)
            {
                currentDigitInNBase += (numberInDec % numberBase) * multiplayer;
                multiplayer *= 10;
                numberInDec = numberInDec / numberBase;
            }

            Console.WriteLine(currentDigitInNBase);
        }
    }
}