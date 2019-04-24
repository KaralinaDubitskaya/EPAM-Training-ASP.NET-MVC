using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public static class BookExtensions
    {
        /// <summary>
        /// Returns information about the book in a Harvard referencing style.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>String representation of the book.</returns>
        public static string HarvardRefference(this Book book)
        {
            return string.Format(
                "{0} ({1}). {2}. ed. {3}, p.{4}. {5}. Price: {6}.", 
                book.Author, 
                book.Year, 
                book.Title,
                book.Publisher,
                book.Pages,
                book.Isbn,
                book.Price);
        }
    }
}
