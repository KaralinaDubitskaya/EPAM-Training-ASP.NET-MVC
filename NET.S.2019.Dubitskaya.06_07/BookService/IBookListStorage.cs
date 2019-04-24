using System.Collections.Generic;

namespace BookService
{
    public interface IBookListStorage
    {
        /// <summary>
        /// Save books to the specified file.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        void SaveBooks(List<Book> books);

        /// <summary>
        /// Load books from the specified file.
        /// </summary>
        /// <returns>List of loaded books.</returns>
        List<Book> LoadBooks();
    }
}