namespace _15.Nilapdromes
{
    using System;

    class Nilapdromes
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();

            while (inputLine != "end")
            {
                var newNailapdrome = string.Empty;

                if (IsNilapdrome(inputLine, out newNailapdrome))
                {
                    Console.WriteLine(newNailapdrome);
                }

                inputLine = Console.ReadLine();
            }
        }

        private static bool IsNilapdrome(string inputLine, out string newNailapdrome)
        {
            newNailapdrome = string.Empty;
            var biggestLeftPart = String.Empty;
            var biggestRightPart = String.Empty;

            for (int i = 0; i < inputLine.Length / 2; i++)
            {
                var leftPart = inputLine.Substring(0, i + 1);
                var rightPartStartIndex = inputLine.Length - 1 - i;
                var rightPart = inputLine.Substring(rightPartStartIndex, i + 1);

                if (leftPart == rightPart && leftPart.Length > biggestLeftPart.Length)
                {
                    biggestLeftPart = leftPart;
                    biggestRightPart = rightPart;
                }
            }

            var totalLengthOfParts = biggestRightPart.Length + biggestLeftPart.Length;

            if (biggestRightPart != string.Empty && biggestLeftPart != string.Empty &&
                totalLengthOfParts < inputLine.Length)
            {
                var startIndex = biggestLeftPart.Length;
                var count = inputLine.Length - totalLengthOfParts;
                var centerPart = inputLine.Substring(startIndex, count);
                newNailapdrome = centerPart + biggestLeftPart + centerPart;
                return true;
            }

            return false;
        }
    }
}