using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            foreach (var author in authors)
            {
                var sum = books.Where(x => x.Author == author).Sum(x => x.Price);
                Console.WriteLine($"{author} -> {sum}");
            }
        }
    }
}
