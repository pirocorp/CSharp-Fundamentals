using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace _15.Book_Library_Modification
{
    class Program
    {
        static void Main()
        {
            var inputLines = File.ReadAllLines("Input.txt");
            var books = new List<Book>();

            for (int i = 0; i < inputLines.Length - 1; i++)
            {
                var currentBook = Book.Parse(inputLines[i]);
                books.Add(currentBook);
            }

            var format = "dd.MM.yyyy";
            var startDate = DateTime.ParseExact(inputLines[inputLines.Length - 1], format, CultureInfo.InvariantCulture);

            books.Where(x => x.ReleaseDate > startDate)
                .OrderBy(x => x.ReleaseDate)
                .ThenBy(x => x.Title)
                .ToList()
                .ForEach(x => File.AppendAllLines("Output.txt", new []{ $"{x.Title} -> {x.ReleaseDate.Day}.{x.ReleaseDate.Month:d2}.{x.ReleaseDate.Year}" }));
        }
    }
}
