using System;

namespace CountIntegers
{
    class CountIntegers
    {
        static void Main()
        {
            int counter = 0;

            try
            {
                while (true)
                {               
                    var n = int.Parse(Console.ReadLine());
                    counter++;
                }
            }
            catch
            {
                Console.WriteLine(counter);
            }
        }
    }
}
