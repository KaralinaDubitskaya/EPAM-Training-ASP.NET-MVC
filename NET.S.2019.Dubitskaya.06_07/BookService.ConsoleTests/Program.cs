using BookService.Comparators;
using BookService.Finders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService booksService = new BookListService();

            booksService.AddBook(new Book("0-85131-041-8", "title1", "author1",
                "publisher1", 2018, 150, 2.3));
            booksService.AddBook(new Book("0-684-84328-5", "title2", "author2",
               "publisher2", 2018, 150, 3.3));
            booksService.AddBook(new Book("ISBN: 9971-5-0210-0", "title3", "author3",
               "publisher3", 2018, 150, 4.3));
            booksService.AddBook(new Book("8090273416", "title4", "author4",
               "publisher4", 2018, 150, 5.3));
            booksService.AddBook(new Book(" 0-8044-2957-X", "title5", "author5",
               "publisher5", 2018, 150, 6.3));

            booksService.SortBooks(new PriceComparator());

            foreach (Book book in booksService.Books)
                Console.WriteLine(book);

            BookListStorage storage = new BookListStorage();
            booksService.SaveBooks(storage, "books.bin");

            booksService.Books.Clear();
            booksService.LoadBooks(storage, "books.bin");

            var finder = new BookFinderByPriceRange(1.0, 5.0);
            List<Book> tmp = booksService.FindBookByTag(finder);
            foreach (Book book in tmp)
                Console.WriteLine(book);
        }
    }
}
