using System;

namespace PrimesInGivenRange
{
    class PrimesInGivenRange
    {
        static void Main()
        {
            long startNum = long.Parse(Console.ReadLine());
            long endNum = long.Parse(Console.ReadLine());
            string result = PrimeInRange(startNum, endNum);
            Console.WriteLine(result);
            //Console.WriteLine(IsPrime(n));
        }

        static string PrimeInRange(long startNum, long endNum)
        {
            if (endNum <= startNum) return string.Empty;

            string result = string.Empty;
            for (long i = startNum; i <= endNum; i++)
            {
                if (IsPrime(i))
                {
                    result += i + ", ";
                }
            }

            result = result.Remove(result.Length - 2);
            return result;
        }

        static bool IsPrime(long number)
        {
            bool IsPrime = true;
            if (number == 0) return false;
            if (number == 1) return false;
            for (long i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0) IsPrime = false;
            }

            return IsPrime;
        }
    }
}
