namespace _17.Convert_from_Base_N_to_Base_10
{
    using System;
    using System.Numerics;

    class Program
    {
        static void Main()
        {
            var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var numberBase = BigInteger.Parse(tokens[0]);
            var numberInBase = BigInteger.Parse(tokens[1]);
            BigInteger currentNumberInDec = 0;
            var power = 0;

            while (numberInBase > 0)
            {
                currentNumberInDec += (numberInBase % 10) * BigInteger.Pow(numberBase, power);
                numberInBase = numberInBase / 10;
                power++;
            }

            Console.WriteLine(currentNumberInDec);
        }
    }
}
