using System;

namespace GreaterTwoValues
{
    class GreaterTwoValues
    {
        static void Main()
        {
            var type = Console.ReadLine();

            if (type == "int")
            {
                int first = int.Parse(Console.ReadLine());
                int second = int.Parse(Console.ReadLine());
                int max = GetMax(first, second);
                Console.WriteLine(max);
            }
            else if (type == "char")
            {
                char first = char.Parse(Console.ReadLine());
                char second = char.Parse(Console.ReadLine());
                char max = GetMax(first, second);
                Console.WriteLine(max);
            }
            else if (type == "string")
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                string max = GetMax(first, second);
                Console.WriteLine(max);
            }
        }

        static int GetMax (int value1, int value2)
        {
            int max = Math.Max(value1, value2);
            return max;
        }

        static char GetMax(char value1, char value2)
        {
            char max = (char)Math.Max(value1, value2);
            return max;
        }

        static string GetMax(string value1, string value2)
        {
            string max;

            if (value1.CompareTo(value2) > 0)
            {
                max = value1;
            }
            else
            {
                max = value2;
            }

            return max;
        }
    }
}
