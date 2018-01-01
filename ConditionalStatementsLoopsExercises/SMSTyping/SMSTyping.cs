using System;

public class SMS_Typing
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        var SMS = string.Empty;

        for (int i = 0; i < n; i++)
        {
            var currentMessageCharacter = Console.ReadLine();

            if (currentMessageCharacter == "0")
            {
                SMS += " ";
            }
            else
            {
;
                var mainDigit = int.Parse(currentMessageCharacter[0].ToString());
                var numberOfDigits = currentMessageCharacter.Length;
                var offset = (mainDigit - 2) * 3;

                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }

                var letterIndex = offset + numberOfDigits - 1;
                var currentMessage = (char)(letterIndex + 97);

                SMS += currentMessage;
            }
        }

        Console.WriteLine(SMS);
    }

}