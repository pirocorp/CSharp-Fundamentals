using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Insertion_Sort_Using_List
{
    class Program
    {
        static void Main()
        {


            for (int firstUnsorted = 0; firstUnsorted < arr.Length - 1; firstUnsorted++)
            {
                var i = firstUnsorted + 1;
                while (i > 0)
                {
                    if (arr[i - 1] > arr[i])
                        Swap(arr, i, i - 1); // todo: write Swap() method
                    i--;
                }
            }

        }
    }
}
