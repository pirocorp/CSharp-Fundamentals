using System;

namespace IncrementVariable
{
    class IncrementVariable
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            int overflow = 0;
            byte num = 0;

            for (int i = 0; i < n; i++)
            {
                num++;
                Console.Write(num + "\r");
                if (num == 0) overflow++;
            }

            Console.WriteLine(num);
            if (overflow > 0) Console.WriteLine($"Overflowed {overflow} times");
        }
    }
}
