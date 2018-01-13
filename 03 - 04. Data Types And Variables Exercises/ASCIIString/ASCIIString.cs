using System;

namespace ASCIIString
{
    class ASCIIString
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string result = "";

            for (int i = 0; i < n; i++)
            {
                int numLetter = int.Parse(Console.ReadLine());
                result += (char)numLetter;
            }

            Console.WriteLine(result);
        }
    }
}
