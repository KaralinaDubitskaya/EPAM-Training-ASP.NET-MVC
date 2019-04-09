using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Finders
{
    public class BookFinderByPriceRange : IFinder
    {
        public BookFinderByPriceRange(double min, double max)
        {
            Min = min;
            Max = max;
        }

        /// <summary>
        /// Min value of price of the book.
        /// </summary>
        public double Min { get; set; }

        /// <summary>
        /// Max value of price of the book.
        /// </summary>
        public double Max { get; set; }

        /// <summary>
        /// Check if the book's price is inside the specified range.
        /// </summary>
        /// <param name="book">Book to be checked.</param>
        /// <returns>True, if the book's price is inside the specified range; otherwise, false.</returns>
        public bool IsMatch(Book book)
        {
            if (book == null)
            {
                return false;
            }

            return book.Price >= Min && book.Price <= Max;
        }
    }
}
