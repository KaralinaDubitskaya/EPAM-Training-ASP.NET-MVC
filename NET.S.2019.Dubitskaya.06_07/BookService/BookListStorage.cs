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
        public BookListStorage(string filename)
        {
            Filename = filename;
        }

        /// <summary>
        /// Name of the file to store the data about books.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// Load books from the specified file.
        /// </summary>
        /// <returns>List of loaded books.</returns>
        /// <exception cref="ArgumentException">Thrown if the filename is a zero-length string, 
        /// contains only white space, or contains one or more invalid characters.</exception>
        /// <exception cref="IOException">Thrown if an I/O error occurs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the filename is too long.</exception>
        /// <exception cref="PathTooLongException">Thrown if the specified path, 
        /// file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if the specified path is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown if the file is read-only.</exception>
        public List<Book> LoadBooks()
        {
            if (!File.Exists(Filename))
            {
                return null;
            }

            List<Book> books = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(Filename, FileMode.Open)))
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
        /// <exception cref="ArgumentException">Thrown if the filename is a zero-length string, 
        /// contains only white space, or contains one or more invalid characters.</exception>
        /// <exception cref="IOException">Thrown if an I/O error occurs.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the filename is too long.</exception>
        /// <exception cref="PathTooLongException">Thrown if the specified path, 
        /// file name, or both exceed the system-defined maximum length.</exception>
        /// <exception cref="DirectoryNotFoundException">Thrown if the specified path is invalid.</exception>
        public void SaveBooks(List<Book> books)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(Filename, FileMode.Create)))
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
