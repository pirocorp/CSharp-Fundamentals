namespace _06._Odd_Times
{
    using System;
    using System.Linq;

    public class OddTimes
    {
        public static void Main()
        {
            var arr = Console.ReadLine()
                .Split(' ')
                .Where(x => x != "")
                .Select(int.Parse)
                .ToArray();

            var result = 0;

            foreach (var element in arr)
            {
                result ^= element;
            }

            Console.WriteLine(result);
        }
    }
}