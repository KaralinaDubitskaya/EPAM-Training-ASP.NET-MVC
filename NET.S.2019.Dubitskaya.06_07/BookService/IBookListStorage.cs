using System.Collections.Generic;

namespace BookService
{
    public interface IBookListStorage
    {
        /// <summary>
        /// Save books to the specified file.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        /// <param name="fileName">File for books to be stored.</param>
        void SaveBooks(List<Book> books, string fileName);

        /// <summary>
        /// Load books from the specified file.
        /// </summary>
        /// <param name="fileName">File to be loaded.</param>
        /// <returns>List of loaded books.</returns>
        List<Book> LoadBooks(string fileName);
    }
}