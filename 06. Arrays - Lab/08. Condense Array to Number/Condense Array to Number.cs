using System;
using System.Linq;

namespace _08.Condense_Array_to_Number
{
    class Program
    {
        static void Main()
        {
            //Data input and processing
            string consoleLine = Console.ReadLine();
            char[] delimiterList = {' '};
            string[] inputStrings = consoleLine.Split(delimiterList, StringSplitOptions.RemoveEmptyEntries);

            int[] nums = inputStrings.Select(int.Parse).ToArray();
            while (nums.Length > 1)
            {
                int[] condensed = new int[nums.Length - 1];
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    condensed[i] = nums[i] + nums[i + 1];
                }

                nums = condensed;
            }

            Console.WriteLine(nums[0]);
        }
    }
}
