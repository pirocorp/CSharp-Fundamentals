using System;
using System.Linq;

namespace _01.Reverse_String
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(new string(Console.ReadLine().Reverse().ToArray()));
        }
    }
}
