using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public class BookListStorage : IBookListStorage
    {
        /// <summary>
        /// Load books from the specified file.
        /// </summary>
        /// <param name="fileName">File to be loaded.</param>
        /// <returns>List of loaded books.</returns>
        /// <exception cref="ArgumentException">Thrown if the filename is a zero-length string, 
        /// contains only white space, or contains one or more invalid characters.</exception>
        /// <exception cref="IOException">Thrown if an I/O error occurs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the filename is too long.</exception>
        /// <exception cref="PathTooLongException">Thrown if the specified path, 
        /// file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if the specified path is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown if the file is read-only.</exception>
        public List<Book> LoadBooks(string filename)
        {
            if (!File.Exists(filename))
            {
                return null;
            }

            List<Book> books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                while (reader.BaseStream.Length != reader.BaseStream.Position)
                {
                    books.Add(new Book(
                        reader.ReadString(),     // isbn
                        reader.ReadString(),     // author
                        reader.ReadString(),     // title
                        reader.ReadString(),     // publisher
                        reader.ReadInt32(),      // year
                        reader.ReadInt32(),      // pages
                        reader.ReadDouble()));   // price
                }
            }

            return books;
        }

        /// <summary>
        /// Save books to the specified file.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        /// <param name="filename">File for books to be stored.</param>
        /// <exception cref="ArgumentException">Thrown if the filename is a zero-length string, 
        /// contains only white space, or contains one or more invalid characters.</exception>
        /// <exception cref="IOException">Thrown if an I/O error occurs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the filename is too long.</exception>
        /// <exception cref="PathTooLongException">Thrown if the specified path, 
        /// file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if the specified path is invalid.</exception>
        public void SaveBooks(List<Book> books, string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                foreach (Book book in books)
                {
                    writer.Write(book.Isbn);
                    writer.Write(book.Title);
                    writer.Write(book.Author);
                    writer.Write(book.Publisher);
                    writer.Write(book.Year);
                    writer.Write(book.Pages);
                    writer.Write(book.Price);
                }
            }
        }
    }
}
