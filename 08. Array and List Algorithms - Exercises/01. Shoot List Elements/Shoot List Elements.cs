using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shoot_List_Elements
{
    class Program
    {
        static int lastRemovedElement = -1;

        static void Main()
        {
            var numbers = new List<int>();
            var inputLine = Console.ReadLine();

            while (inputLine != "stop")
            {
                if (inputLine == "bang")
                {
                    if (numbers.Count == 0)
                    {
                        Console.WriteLine($"nobody left to shoot! last one was {lastRemovedElement}");
                        return;
                    }

                    var average = numbers.Average();
                    ShootElement(numbers, average);
                    DecrementElements(numbers);
                }
                else
                {
                    var number = int.Parse(inputLine);
                    numbers.Insert(0, number);
                }

                inputLine = Console.ReadLine();
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine($"you shot them all. last one was {lastRemovedElement}");
            }
            else
            {
                Console.WriteLine($"survivors: {String.Join(" ", numbers)}");
            }
        }

        private static void DecrementElements(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]--;
            }
        }

        private static void ShootElement(List<int> numbers, double average)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < average)
                {
                    Console.WriteLine($"shot {numbers[i]}");
                    lastRemovedElement = numbers[i];
                    numbers.RemoveAt(i);
                    return;
                }

            }

            if (numbers.Count == 1)
            {
                Console.WriteLine($"shot {numbers[0]}");
                lastRemovedElement = numbers[0];
                numbers.RemoveAt(0);
            }
        }
    }
}
