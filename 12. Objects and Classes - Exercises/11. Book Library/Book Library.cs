using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Book_Library
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var books = new List<Book>();

            for (int i = 0; i < n; i++)
            {
                var currentBook = Book.Parse(Console.ReadLine());
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
                Console.WriteLine($"{kvp.Key} -> {kvp.Value:f2}");
            }
        }
    }
}
