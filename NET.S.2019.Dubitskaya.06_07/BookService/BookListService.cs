using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public class BookListService
    {
        /// <summary>
        /// Initializes a new instance of the BookListService class.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        /// <returns>Returns instance of the BookListService class.</returns>
        /// <remarks>Null parameters would be skipped.</remarks>
        public BookListService(params Book[] books)
        {
            Books = new List<Book>();

            foreach (Book book in books)
            {
                if (book == null || Books.IndexOf(book) != -1)
                {
                    continue;
                }

                Books.Add(book);
            }
        }

        /// <summary>
        /// List of books to operate with.
        /// </summary>
        public List<Book> Books { get; private set; }

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
        /// Save books to the specified storage.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        public void SaveBooks(IBookListStorage storage)
        {
            storage.SaveBooks(Books);
        }

        /// <summary>
        /// Load books from the specified storage.
        /// </summary>
        /// <param name="storage">Storage to load books from.</param>
        public void LoadBooks(IBookListStorage storage)
        {
            Books = storage.LoadBooks();
        }
    }
}
