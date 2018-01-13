using System;

namespace _26.Index_of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] chars = Console.ReadLine().ToCharArray();
            int result;
            for (int i = 0; i < chars.Length; i++)
            {
                result = chars[i] - 'a';
                Console.WriteLine($"{chars[i]} -> {result}");
            }
        }
    }
}
