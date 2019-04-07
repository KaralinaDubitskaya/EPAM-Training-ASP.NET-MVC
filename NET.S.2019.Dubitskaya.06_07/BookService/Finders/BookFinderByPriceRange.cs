using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService.Finders
{
    public class BookFinderByPriceRange : IFinder
    {
        public double Min { get; set; }
        public double Max { get; set; }

        public BookFinderByPriceRange(double min, double max)
        {
            Min = min;
            Max = max;
        }

        public bool IsMatch(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            return book.Price >= Min && book.Price <= Max;
        }
    }
}
