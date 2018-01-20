using System;
using System.Linq;

namespace _24.Sort_Times
{
    class Program
    {
        static void Main()
        {
            var timeList = Console.ReadLine().Split(' ').ToList();
            timeList.Sort();
            Console.WriteLine(String.Join(", ", timeList));
        }
    }
}
