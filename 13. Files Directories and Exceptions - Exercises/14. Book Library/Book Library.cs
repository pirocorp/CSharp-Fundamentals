using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _14.Book_Library
{
    class Program
    {
        static void Main()
        {
            var inputLines = File.ReadAllLines("Input.txt");
            var books = new List<Book>();

            for (int i = 0; i < inputLines.Length; i++)
            {
                var currentBook = Book.Parse(inputLines[i]);
                books.Add(currentBook);
            }

            var authors = books.Select(x => x.Author).Distinct().ToList();
            var result = new Dictionary<string, decimal>();

            foreach (var author in authors)
            {
                var sum = books.Where(x => x.Author == author).Sum(x => x.Price);
                result[author] = sum;
            }

            result = result.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in result)
            {
                File.AppendAllLines("Output.txt", new []{ $"{kvp.Key} -> {kvp.Value:f2}" });
            }
        }
    }
}
