using System;

namespace BalancedBrackets
{
    class BalancedBrackets
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            bool openBracked = false;
            bool balancedBraked = true;

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                if (line == "(")
                {
                    if (openBracked)
                    {
                        balancedBraked = false;
                        break;
                    }
                    openBracked = true;
                    balancedBraked = false;
                }

                if (line == ")")
                {
                    balancedBraked = true;

                    if (!openBracked)
                    {
                        balancedBraked = false;
                        break;
                    }

                    openBracked = false;
                }
            }

            if (balancedBraked)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
