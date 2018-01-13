using System;

namespace DifferentNumbers
{
    class DifferentNumbers
    {
        static void Main()
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            bool no = true;
            for (int n1 = start; n1 <= end; n1++)
            {
                for (int n2 = n1 + 1; n2 <= end; n2++)
                {
                    for (int n3 = n2 + 1; n3 <= end; n3++)
                    {
                        for (int n4 = n3 + 1; n4 <= end; n4++)
                        {
                            for (int n5 = n4 + 1; n5 <= end; n5++)
                            {
                                Console.WriteLine($"{n1} {n2} {n3} {n4} {n5}");
                                no = false;
                            }
                        }
                    }
                }
            }

            if (no) Console.WriteLine("No");
        }
    }
}
