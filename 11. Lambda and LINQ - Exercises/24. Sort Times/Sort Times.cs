using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
