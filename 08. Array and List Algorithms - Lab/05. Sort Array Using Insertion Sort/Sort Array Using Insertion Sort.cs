using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Sort_Array_Using_Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int firstUnsorted = 0; firstUnsorted < arr.Length - 1; firstUnsorted++)
            {
                var i = firstUnsorted + 1;
                while (i > 0)
                {
                    if (arr[i - 1] > arr[i])
                        Swap(arr, i, i - 1);
                    i--;
                }
            }

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
