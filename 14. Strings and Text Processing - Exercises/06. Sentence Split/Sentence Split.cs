namespace _06.Sentence_Split
{
    using System;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var delimiters = Console.ReadLine();
            Console.WriteLine("[" + string.Join(", ", input.Split(new[] { delimiters }, StringSplitOptions.None)) + "]");
        }
    }
}
