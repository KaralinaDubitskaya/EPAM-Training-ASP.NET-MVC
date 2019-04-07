using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public class BookListService
    {
        public List<Book> Books { get; private set; }

        /// <summary>
        /// Initializes a new instance of the BookListService class.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        /// <returns>Returns instance of the BookListService class.</returns>
        public BookListService(params Book[] books)
        {
            Books = new List<Book>();

            foreach (Book book in books)
            {
                if (book == null)
                {
                    throw new ArgumentNullException();
                }

                Books.Add(book);
            }
        }

        /// <summary>
        /// Add the book.
        /// </summary>
        /// <param name="book">Book to be added.</param>
        /// <exception cref="ArgumentException">Thrown when the book has already been stored.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is null.</exception>
        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            if (Books.IndexOf(book) >= 0)
            {
                throw new ArgumentException("The  book has already been stored.");
            }

            Books.Add(book);
        }

        /// <summary>
        /// Remove the book.
        /// </summary>
        /// <param name="book">Book to be removed.</param>
        /// <exception cref="ArgumentException">Thrown when the book couldn't be found.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is null.</exception>
        public void RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            if (Books.IndexOf(book) == -1)
            {
                throw new ArgumentException("The BookListStorage doesn't contain the book.");
            }

            Books.Remove(book);
        }

        /// <summary>
        /// Sort books using the given comparator.
        /// </summary>
        /// <param name="comparator">Comparator to sort the books.</param>
        /// <exception cref="ArgumentNullException">Thrown if the argument is null.</exception>
        public void SortBooks(IComparer<Book> comparator)
        {
            if (comparator == null)
            {
                throw new ArgumentNullException();
            }

            Books.Sort(comparator);
        }

        /// <summary>
        /// find books by some field
        /// </summary>
        /// <param name="searcher">searcher</param>
        /// <param name="tag">book field</param>
        /// <returns></returns>
        public List<Book> FindBookByTag(IFinder finder)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in Books)
            {
                if (finder.IsMatch(book))
                {
                    result.Add(book);
                }
            }

            return result;
        }

        /// <summary>
        /// Save books to the specified file.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        /// <param name="filename">File for books to be stored.</param>
        public void SaveBooks(IBookListStorage storage, string filename)
        {
            storage.SaveBooks(Books, filename);
        }

        /// <summary>
        /// Load books from the specified file.
        /// </summary>
        /// <param name="fileName">File to be loaded.</param>
        public void LoadBooks(IBookListStorage storage, string filename)
        {
            Books = storage.LoadBooks(filename);
        }
    }
}
