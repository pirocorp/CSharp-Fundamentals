namespace _10.Extract_Sentences_by_Keyword
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            var filter = Console.ReadLine();
            var filterRegex = new Regex($@"\b{filter}\b");
            var sentenceRegex = new Regex ("(?<sentance>.+?)[.!?]");
            var inputData = Console.ReadLine();
            var sentances = sentenceRegex.Split(inputData).Where(x => !string.IsNullOrEmpty(x)).ToArray();

            foreach (var sentance in sentances)
            {
                if (filterRegex.IsMatch(sentance))
                {
                    Console.WriteLine(sentance.Trim());
                }
            }
        }
    }
}
