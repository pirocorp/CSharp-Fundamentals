namespace _04.Palindromes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Palindromes
    {
        static void Main()
        {
            var delimeterList = new []{' ', '.', ',', '!', '?'};
            var words = Console.ReadLine().Split(delimeterList, StringSplitOptions.RemoveEmptyEntries);
            var resultedList = new List<string>();

            for (var i = 0; i < words.Length; i++)
            {
                var currentWord = words[i];
                var reversedCurrentWord = new string(currentWord.Reverse().ToArray());

                if (currentWord == reversedCurrentWord)
                {
                    resultedList.Add(currentWord);
                }
            }

            resultedList = resultedList.Distinct().OrderBy(x => x).ToList();
            Console.WriteLine(String.Join(", ", resultedList));
        }
    }
}
