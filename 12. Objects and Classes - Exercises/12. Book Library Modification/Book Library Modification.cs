using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using _11.Book_Library;

namespace _12.Book_Library_Modification
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

            var format = "dd.MM.yyyy";
            var startDate = DateTime.ParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture);

            books.Where(x => x.ReleaseDate > startDate)
                .OrderBy(x => x.ReleaseDate)
                .ThenBy(x => x.Title)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Title} -> {x.ReleaseDate.Day}.{x.ReleaseDate.Month:d2}.{x.ReleaseDate.Year}"));
        }
    }
}
