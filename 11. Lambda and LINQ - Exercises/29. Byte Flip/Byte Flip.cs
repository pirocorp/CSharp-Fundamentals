using System;
using System.Globalization;
using System.Linq;

namespace _29.Byte_Flip
{
    class Program
    {
        static void Main()
        {
            var numbersStrings = Console.ReadLine().Split(new []{ ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            numbersStrings = numbersStrings.Where(x => x.Length == 2).ToList();
            numbersStrings = numbersStrings.Select(x => new string(x.Reverse().ToArray())).Reverse().ToList();
            var numbers = numbersStrings.Select(x => int.Parse(x, NumberStyles.HexNumber)).ToList();
            var result = new string(numbers.Select(x => (char) x).ToArray());
            Console.WriteLine(result);
        }
    }
}
