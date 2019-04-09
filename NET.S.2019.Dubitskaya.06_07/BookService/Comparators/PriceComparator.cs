using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Comparators
{
    public class PriceComparator : IComparer<Book>
    {
        /// <summary>
        /// Compare two books by their price.
        /// </summary>
        /// <param name="book1">Book to be compared.</param>
        /// <param name="book2">Book to be compared.</param>
        /// <returns>
        /// 1, if the first book's price is greater.
        /// 0, if price of the books is equal.
        /// -1, if the the second book's price is greater.
        /// </returns>
        /// <remarks>
        /// According to MSDN documentation, any object compares greater than null, 
        /// and two null references compare equal to each other.
        /// </remarks>
        public int Compare(Book book1, Book book2)
        {
            if (book1 == null && book2 != null) 
            {
                return -1;
            }

            if (book1 == null && book2 == null)
            {
                return 0;
            }

            if (book1 != null && book2 == null)
            {
                return 1;
            }

            return book1.Price.CompareTo(book2.Price);
        }
    }
}
