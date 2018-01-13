using System;

namespace _08.Array_Symmetry
{
    class Program
    {
        static void Main()
        {
            char[] delimeterList = {' '};
            string[] inputStrings = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);

            bool arreyIsSymetric = true;
            for (int i = 0; i < inputStrings.Length / 2; i++)
            {
                bool stringsAreEquals = inputStrings[i].Equals(inputStrings[inputStrings.Length - 1 - i]);
                if (!stringsAreEquals)
                {
                    arreyIsSymetric = false;
                    break;
                }
            }

            if (arreyIsSymetric)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
