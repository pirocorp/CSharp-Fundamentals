using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _02.Change_List
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var numbers = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var command = Console.ReadLine()
                .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Odd" && command[0] != "Even")
            {
                switch (command[0])
                {
                    case "Delete":
                        numbers.RemoveAll(x => x == int.Parse(command[1]));
                        break;
                    case "Insert": 
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                        break;
                    default:
                        Console.WriteLine("Invalid Command");
                        break;
                }

                command = Console.ReadLine()
                    .Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            }

            if (command[0] == "Odd")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] % 2 == 0)
                    {
                        numbers.RemoveAt(i);
                        i--;
                    }
                }
            }
            else if (command[0] == "Even")
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] % 2 == 1)
                    {
                        numbers.RemoveAt(i);
                        i--;
                    }
                }
            }
            
            string result = String.Join(" ", numbers);
            Console.WriteLine(result);
        }
    }
}
