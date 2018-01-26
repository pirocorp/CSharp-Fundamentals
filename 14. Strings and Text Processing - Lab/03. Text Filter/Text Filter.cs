namespace _03.Text_Filter
{
    using System;

    class Program
    {
        static void Main()
        {
            var banWords = Console.ReadLine().Split(new []{',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            var text = Console.ReadLine();

            foreach (var banWord in banWords)
            {
                if (text.Contains(banWord))
                {
                    text = text.Replace(banWord, new string('*', banWord.Length));
                }
            }

            Console.WriteLine(text);
        }
    }
}
