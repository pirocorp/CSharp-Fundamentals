using System;

namespace _07.Count_of_Capital_Letters_in_Array
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            string[] inputStrings = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            for (int i = 0; i < inputStrings.Length; i++)
            {
                if (inputStrings[i].Length == 1 && inputStrings[i][0] >= 'A' && inputStrings[i][0] <= 'Z')
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}
