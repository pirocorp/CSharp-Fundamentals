using System;
using System.Globalization;

namespace _11.Book_Library
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        public static Book Parse(string inputData)
        {
            var tokens = inputData.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var title = tokens[0];
            var author = tokens[1];
            var publisher = tokens[2];
            var format = "dd.MM.yyyy";
            var releaseDate = DateTime.ParseExact(tokens[3], format, CultureInfo.InvariantCulture);
            var isbn = tokens[4];
            var price = decimal.Parse(tokens[5]);

            var newBook = new Book()
            {
                Title = title,
                Author = author,
                Publisher = publisher,
                ReleaseDate = releaseDate,
                ISBN = isbn,
                Price = price
            };

            return newBook;
        }
    }
}
