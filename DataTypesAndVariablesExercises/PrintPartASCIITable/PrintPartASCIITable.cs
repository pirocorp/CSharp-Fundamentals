using System;

namespace PrintPartASCIITable
{
    class PrintPartASCIITable
    {
        static void Main()
        {
            var startAscii = int.Parse(Console.ReadLine());
            var endAscii = int.Parse(Console.ReadLine());

            for (char i = (char)startAscii; i <= endAscii; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }
    }
}
