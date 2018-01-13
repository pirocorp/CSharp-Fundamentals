using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Shoot_List_Elements
{
    class Program
    {
        static double lastRemovedInt = double.NaN;
        private static bool bang = true;

        static void Main()
        {
            var resutList = new List<int>();
            var command = Console.ReadLine();

            while (command != "stop")
            {
                if (command == "bang")
                {
                    BangProcessing(resutList);
                    if (!bang)
                    {
                        return;
                    }
                }
                else
                {
                    resutList.Insert(0, int.Parse(command));
                }

                command = Console.ReadLine();
            }

            if (resutList.Count > 0)
            {
                Console.WriteLine($"survivors: {String.Join(" ", resutList)}");
            }
            else
            {
                Console.WriteLine($"you shot them all. last one was {lastRemovedInt}");
            }
        }

        private static void BangProcessing(List<int> resutList)
        {
            if (resutList.Count > 0)
            {
                double average = resutList.Average();
                lastRemovedInt = RemoveFirstElementSmallerThanAverage(average, resutList);
                DecrementEveryElementInList(1, resutList);
            }
            else
            {
                Console.WriteLine($"nobody left to shoot!last one was {lastRemovedInt}");
                bang = false;
            }

            bang = true;
        }

        private static void DecrementEveryElementInList(int i, List<int> resutList)
        {
            for (int j = 0; j < resutList.Count; j++)
            {
                resutList[j] -= i;
            }
        }

        private static double RemoveFirstElementSmallerThanAverage(double average, List<int> resutList)
        {
            for (int i = 0; i < resutList.Count; i++)
            {
                if (resutList[i] <= average)
                {
                    int lastBangElement = resutList[i];
                    resutList.RemoveAt(i);
                    Console.WriteLine($"shot {lastBangElement}");
                    return lastBangElement;
                }
            }

            return Double.NaN;
        }
    }
}
