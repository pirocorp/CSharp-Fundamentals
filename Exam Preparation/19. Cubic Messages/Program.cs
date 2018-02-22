using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _19.Cubic_Messages
{
    class Program
    {
        static void Main()
        {
            var inputLine = Console.ReadLine();
            var digitRegex = new Regex(@"\d", RegexOptions.Compiled);

            while (inputLine != "Over!")
            {
                var number = int.Parse(Console.ReadLine());
                var pattern = $@"^\d+(?<message>[a-zA-Z]{{{number}}})[^a-zA-Z]*$";
                var match = Regex.Match(inputLine, pattern);

                if (!match.Success)
                {
                    inputLine = Console.ReadLine();
                    continue;
                }

                var cryptedMessage = match.Groups["message"].Value;
                var allDigitInMessage = digitRegex.Matches(inputLine)
                    .Cast<Match>()
                    .Select(x => x.Value)
                    .Select(int.Parse)
                    .ToArray();

                var verificationCode = GetVerificationCode(cryptedMessage, allDigitInMessage);
                Console.WriteLine($"{cryptedMessage} == {verificationCode}");
                inputLine = Console.ReadLine();
            }
        }

        private static string GetVerificationCode(string cryptedMessage, int[] allDigitInMessage)
        {
            var result = new StringBuilder();

            for (var i = 0; i < allDigitInMessage.Length; i++)
            {
                var currentDigit = allDigitInMessage[i];
                var currentChar = ' ';

                if (currentDigit >= 0 && currentDigit < cryptedMessage.Length)
                {
                    currentChar = cryptedMessage[currentDigit];
                }

                result.Append(currentChar);
            }

            return result.ToString();
        }
    }
}