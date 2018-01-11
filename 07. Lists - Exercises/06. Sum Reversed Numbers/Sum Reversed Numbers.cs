using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Sum_Reversed_Numbers
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            List<int> nums = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            List<int> listOfResults = new List<int>();

            for (int i = 0; i < nums.Count; i++)
            {
                int number = nums[i];
                int result = 0;
                

                while (number != 0)
                {
                    result *= 10;
                    result += number % 10;
                    number /= 10;
                }

                listOfResults.Add(result);
            }

            Console.WriteLine(listOfResults.Sum());
        }
    }
}
