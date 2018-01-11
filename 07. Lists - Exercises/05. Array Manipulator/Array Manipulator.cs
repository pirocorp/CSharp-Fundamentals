using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _05.Array_Manipulator
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var nums = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "print")
            {
                switch (command[0])
                {
                    case "add":
                        nums.Insert(int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "addMany":
                        AddMany(command, nums);
                        break;
                    case "contains":
                        Console.WriteLine(nums.IndexOf(int.Parse(command[1])));
                        break;
                    case "remove":
                        nums.RemoveAt(int.Parse(command[1]));
                        break;
                    case "shift":
                        ShiftAtLeft(int.Parse(command[1]), nums);
                        break;
                    case "sumPairs":
                        nums = SumPairs(nums);
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }

                command = Console.ReadLine()
                    .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine($"[{String.Join(", ", nums)}]");
        }

        private static List<int> SumPairs(List<int> nums)
        {
            List<int> result = new List<int>();

            if (nums.Count % 2 == 0)
            {
                for (int i = 0; i < nums.Count; i += 2)
                {
                    result.Add(nums[i] + nums[i + 1]);
                }
            }
            else
            {
                for (int i = 0; i < nums.Count - 1; i += 2)
                {
                    result.Add(nums[i] + nums[i + 1]);
                }

                result.Add(nums[nums.Count - 1]);
            }

            return result;
        }

        private static void ShiftAtLeft(int positions, List<int> nums)
        {
            for (int i = 0; i < positions % nums.Count; i++)
            {
                nums.Add(nums[0]);
                nums.RemoveAt(0);

            }
        }

        private static void AddMany(string[] command, List<int> nums)
        {
            int index = int.Parse(command[1]);
            for (int i = command.Length - 1; i >= 2; i--)
            {
                int element = int.Parse(command[i]);
                nums.Insert(index, element);
            }
        }
    }
}
