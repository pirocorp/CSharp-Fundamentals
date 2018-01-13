using System;
using System.Linq;

namespace _04.Triple_Sum
{
    class Program
    {
        static void Main()
        {
            string values = Console.ReadLine();
            char[] delimeterList = { ' ' };
            long[] numbers = values.Split(delimeterList, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

            bool tripleSumFind = false;
            for (long a = 0; a < numbers.Length; a++)
            {
                for (long b = a + 1; b < numbers.Length; b++)
                {
                    for (long c = 0; c < numbers.Length; c++)
                    {
                        if (numbers[a] + numbers[b] == numbers[c] /*&& c != a && c != b*/)
                        {
                            Console.WriteLine($"{numbers[a]} + {numbers[b]} == {numbers[c]}");
                            tripleSumFind = true;
                            break;
                        }
                        else
                        {
                            //Console.WriteLine($"{numbers[a]} + {numbers[b]} == {numbers[c]} -> false");
                        }
                    }

                }

            }

            if (!tripleSumFind)
            {
                Console.WriteLine("No");
            }
        }
    }
}
