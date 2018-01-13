using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Largest_N_Elements
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();
            var n = int.Parse(Console.ReadLine());

            SortArrayUsingInsertionSort(arr);
            ReverseArray(arr);
            var largestNElements = new List<int>();

            for (int i = 0; i < n; i++)
            {
                largestNElements.Add(arr[i]);
            }

            Console.WriteLine(string.Join(" ", largestNElements));
        }

        private static void ReverseArray(int[] arr)
        {
            var n = arr.Length / 2;
            var end = arr.Length - 1;
            for (int i = 0; i < n; i++)
            {
               Swap(arr, i, end - i); 
            }
        }

        private static void SortArrayUsingInsertionSort(int[] arr)
        {
            for (int arrIndex = 0; arrIndex < arr.Length - 1; arrIndex++)
            {
                var firstUnsorted = arrIndex + 1;

                while (firstUnsorted > 0)
                {
                    if (arr[firstUnsorted - 1] > arr[firstUnsorted])
                    {
                        Swap(arr, firstUnsorted - 1, firstUnsorted);
                    }

                    firstUnsorted--;
                }
            }
        }

        private static void Swap(int[] arr, int x, int y)
        {
            var swap = arr[x];
            arr[x] = arr[y];
            arr[y] = swap;
        }
    }
}
