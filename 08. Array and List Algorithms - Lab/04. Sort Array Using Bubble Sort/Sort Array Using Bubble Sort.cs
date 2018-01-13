using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Sort_Array_Using_Bubble_Sort
{
    class Program
    {
        static void Main()
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            bool swapped;
            do
            {
                swapped = false;
                int n = arr.Length - 1;

                for (int i = 0; i < n; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(arr, i, i + 1); 
                        swapped = true;
                    }
                }

                n = n - 1;

            } while (swapped);

            Console.WriteLine(string.Join(" ", arr));
        }

        private static void Swap(int[] arr, int i, int i1)
        {
            var temp = arr[i];
            arr[i] = arr[i1];
            arr[i1] = temp;
        }
    }
}
