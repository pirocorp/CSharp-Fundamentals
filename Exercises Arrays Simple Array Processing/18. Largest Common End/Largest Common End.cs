using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Largest_Common_End
{
    class Program
    {
        static void Main()
        {
            char[] delimeterLIst = {' '};
            string[] arrayOfWords1 = Console.ReadLine()
                .Split(delimeterLIst, StringSplitOptions.RemoveEmptyEntries);

            string[] arrayOfWords2 = Console.ReadLine()
                .Split(delimeterLIst, StringSplitOptions.RemoveEmptyEntries);

            int countFromBeggining = 0;
            int minLength = Math.Min(arrayOfWords1.Length, arrayOfWords2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (arrayOfWords1[i] == arrayOfWords2[i])
                {
                    countFromBeggining++;
                }
            }

            int countFromEnd = 0;

            for (int i = 1; i <= minLength; i++)
            {
                int index1 = arrayOfWords1.Length - i;
                int index2 = arrayOfWords2.Length - i;
                if (arrayOfWords1[index1] == arrayOfWords2[index2])
                {
                    countFromEnd++;
                }
            }

            int result = Math.Max(countFromBeggining, countFromEnd);
            Console.WriteLine(result);
        }
    }
}
