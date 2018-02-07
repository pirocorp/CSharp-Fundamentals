namespace _24.Melrah_Shake
{
    using System;

    class Program
    {
        static void Main()
        {
            var stringInput = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (stringInput.Length > 0 && pattern.Length > 0)
            {
                var firstIndex = stringInput.IndexOf(pattern);
                var lastIndex = stringInput.LastIndexOf(pattern);

                if (firstIndex >= 0 && lastIndex >= 0 && firstIndex != lastIndex)
                {
                    Console.WriteLine($"Shaked it.");

                    stringInput = stringInput.Remove(firstIndex, pattern.Length);
                    lastIndex = stringInput.LastIndexOf(pattern);
                    stringInput  = stringInput.Remove(lastIndex, pattern.Length);
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine($"No shake.");
            Console.WriteLine(stringInput);
        }
    }
}