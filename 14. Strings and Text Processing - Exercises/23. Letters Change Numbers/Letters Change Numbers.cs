namespace _23.Letters_Change_Numbers
{
    using System;

    class Program
    {
        static void Main()
        {
            var inputData = Console.ReadLine().Split(new []{' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0.0m;

            for (var i = 0; i < inputData.Length; i++)
            {
                var currentString = inputData[i];
                var firstLetter = currentString[0];
                var lastLetter = currentString[currentString.Length - 1];
                var number = decimal.Parse(currentString.Substring(1, currentString.Length - 2));
                number = ProcessFirstLetter(firstLetter, number);
                number = ProcessLastLetter(lastLetter, number);
                sum += number;
            }

            Console.WriteLine($"{sum:F2}");
        }

        private static decimal ProcessLastLetter(char lastLetter, decimal number)
        {
            var result = 0.0m;
            var positionInAlphabet = GetPositionInAlphabet(lastLetter);

            if (Char.IsUpper(lastLetter))
            {
                result = number - positionInAlphabet;
            }
            else
            {
                result = number + positionInAlphabet;
            }

            return result;
        }

        private static decimal GetPositionInAlphabet(char letter)
        {
            var positionInAlphabet = 0m;

            if (Char.IsUpper(letter))
            {
                positionInAlphabet = letter - 'A' + 1;
            }
            else
            {
                positionInAlphabet = letter - 'a' + 1;
            }

            return positionInAlphabet;
        }

        private static decimal ProcessFirstLetter(char firstLetter, decimal number)
        {
            var result = 0.0m;
            var positionInAlphabet = GetPositionInAlphabet(firstLetter);

            if (Char.IsUpper(firstLetter))
            {
                result = number / positionInAlphabet;
            }
            else
            {
                result = number * positionInAlphabet;
            }

            return result;
        }
    }
}