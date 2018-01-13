using System;


namespace FromTerabytesBits
{
    class FromTerabytesBits
    {
        static void Main()
        {
            double teraByte = double.Parse(Console.ReadLine());
            double bits = teraByte * 1024 * 1024 * 1024 * 1024 * 8;
            Console.WriteLine(bits);
        }
    }
}
