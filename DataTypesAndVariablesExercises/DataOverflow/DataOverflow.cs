using System;

namespace DataOverflow
{
    class DataOverflow
    {
        static void Main()
        {
            ulong numOne = ulong.Parse(Console.ReadLine());
            ulong numTwo = ulong.Parse(Console.ReadLine());

            var numMax = Math.Max(numOne, numTwo);
            var numMin = Math.Min(numOne, numTwo);

            string biggerType = "";
            string smallerType = "";

            ulong numMinTypeMaxValue = 0;

            if (numMin <= byte.MaxValue)
            {
                smallerType = "byte";
                numMinTypeMaxValue = byte.MaxValue;
            }
            else if (numMin <= ushort.MaxValue)
            {
                smallerType = "ushort";
                numMinTypeMaxValue = ushort.MaxValue;

            }
            else if (numMin <= uint.MaxValue)
            {
                smallerType = "uint";
                numMinTypeMaxValue = uint.MaxValue;

            }
            else if (numMin <= ulong.MaxValue)
            {
                smallerType = "ulong";
                numMinTypeMaxValue = ulong.MaxValue;
            }

            if (numMax <= byte.MaxValue)
            {
                biggerType = "byte";
            }
            else if (numMax <= ushort.MaxValue)
            {
                biggerType = "ushort";
            }
            else if (numMax <= uint.MaxValue)
            {
                biggerType = "uint";
            }
            else if (numMax <= ulong.MaxValue)
            {
                biggerType = "ulong";
            }

            ulong overflow = (ulong)Math.Round((double) numMax / numMinTypeMaxValue);

            Console.WriteLine($"bigger type: {biggerType}");
            Console.WriteLine($"smaller type: {smallerType}");
            Console.WriteLine($"{numMax} can overflow {smallerType} {overflow} times");
        }
    }
}
