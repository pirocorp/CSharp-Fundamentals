using System;

class TrickyStrings
{
    static void Main(string[] args)
    {
        var delimiter = Console.ReadLine();
        var numberOfStrings = int.Parse(Console.ReadLine());

        var result = string.Empty;
        var currentString = string.Empty;
        for (int i = 0; i < numberOfStrings; i++)
        {
            currentString += Console.ReadLine();
            result += currentString + delimiter;
            currentString = string.Empty;
        }

        if (delimiter.Length != 0)
        {
            result = result.Remove(result.Length - delimiter.Length);
        }

        Console.WriteLine(result);
    }
}