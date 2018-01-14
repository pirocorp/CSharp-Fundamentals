using System;

namespace _03.Sort_Array_of_Strings
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = { ' ' };
            var originalStrings = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            SortArrayOfStrings(originalStrings);
            Console.WriteLine($"{String.Join(" ", originalStrings)}");
        }

        private static void SortArrayOfStrings(string[] originalStrings)
        {
            var swapped = true;
            var n = originalStrings.Length;

            while (swapped)
            {
                swapped = false;

                for (int i = 1; i < n; i++)
                {
                    var currentElement = originalStrings[i];
                    var previusElement = originalStrings[i - 1];

                    if (currentElement.CompareTo(previusElement) < 0)
                    {
                        originalStrings[i - 1] = currentElement;
                        originalStrings[i] = previusElement;
                        swapped = true;
                    }
                }

                n -= 1;
            }
        }
    }
}
