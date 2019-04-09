using BookService.Comparators;
using BookService.Finders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BookService.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book0 = new Book("0-8044-2957-X", "title0", "author0",
               "publisher0", 2012, 10, 1.3);

            BookListService booksService = new BookListService(book0, book0);

            WriteLine("Create BookListService.");
            DisplayBooks(booksService.Books);

            booksService.AddBook(new Book("0-8044-2957-x", "title1", "author1",
                "publisher1", 2018, 150, 2.3));
            booksService.AddBook(new Book("0-684-84328-5", "title2", "author2",
               "publisher2", 2018, 150, 6.3));
            booksService.AddBook(new Book("ISBN: 0-8044-2957-X", "title3", "author3",
               "publisher3", 2018, 150, 5.7));
            booksService.AddBook(new Book("8090273416", "title4", "author4",
               "publisher4", 2018, 150, 3.2));
            booksService.AddBook(new Book(" 0-8044-2957-X", "title5", "author5",
               "publisher5", 2018, 150, 4.1));

            WriteLine("Add some books.");
            DisplayBooks(booksService.Books);

            booksService.SortBooks(new PriceComparator());

            WriteLine("Sort books by price.");
            DisplayBooks(booksService.Books);

            WriteLine("Save books to file \"books\".bin.");

            BookListStorage storage = new BookListStorage("books.bin");
            booksService.SaveBooks(storage);

            WriteLine("Clear list of books.");
            booksService = new BookListService();
            DisplayBooks(booksService.Books);

            booksService.LoadBooks(storage);

            WriteLine("Load books from file.");
            DisplayBooks(booksService.Books);

            var finder = new BookFinderByPriceRange(1.0, 5.0);
            WriteLine("Books with price from 1.0 to 5.0.");
            DisplayBooks(booksService.FindBookByTag(finder));

            ReadKey();
        }

        private static void DisplayBooks(IEnumerable<Book> books)
        {
            WriteLine("Books:");

            foreach(Book book in books)
            {
                WriteLine(book);
            }
        }
    }
}
