using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookService
{
    public class Book : IEquatable<Book>, IComparable<Book>
    {
        #region Fields

        private string _isbn;
        private string _author;
        private string _title;
        private string _publisher;
        private int _year;
        private int _pages;
        private double _price;

        #endregion

        #region Constructors

        public Book()
        {
            Isbn = string.Empty;
            Author = string.Empty;
            Title = string.Empty;
            Publisher = string.Empty;
        }

        public Book(string isbn, string author, string title, string publisher, int year, int pages, double price)
        {
            Isbn = isbn;
            Author = author;
            Title = title;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Price = price;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The international Standard Book Number.
        /// </summary>
        /// <see cref="https://en.wikipedia.org/wiki/International_Standard_Book_Number"/>
        public string Isbn
        {
            get => _isbn;
            private set
            {
                if (!IsIsbnValid(value))
                {
                    throw new ArgumentException("Invalid ISBN.");
                }

                _isbn = value;
            }
        }

        /// <summary>
        /// Name of the author of the book.
        /// </summary>
        public string Author
        {
            get => _author;
            private set
            {
                _author = value ?? throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Title of the book.
        /// </summary>
        public string Title
        {
            get => _title;
            private set
            {
                _title = value ?? throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Name of the publisher of the book.
        /// </summary>
        public string Publisher
        {
            get => _publisher;
            private set
            {
                _publisher = value ?? throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Year of the publishing.
        /// </summary>
        public int Year
        {
            get => _year;
            private set
            {
                if (value < 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentNullException();
                }

                _year = value; 
            }
        }

        /// <summary>
        /// Number of pages in the book.
        /// </summary>
        public int Pages
        {
            get => _pages;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }

                _pages = value;
            }
        }

        /// <summary>
        /// Price of the book.
        /// </summary>
        public double Price
        {
            get => _price;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentNullException();
                }

                _price = value;
            }
        }
        
        #endregion

        #region Public methods

        /// <summary>
        /// Calculates the current instance's hash code.
        /// </summary>
        /// <returns>An integer hash code value.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 17;

                hashCode = (31 * hashCode) + (_isbn?.GetHashCode() ?? 0);
                hashCode = (31 * hashCode) + (_author?.GetHashCode() ?? 0);
                hashCode = (31 * hashCode) + (_title?.GetHashCode() ?? 0);
                hashCode = (31 * hashCode) + (_publisher?.GetHashCode() ?? 0);

                hashCode = (31 * hashCode) + _year.GetHashCode();
                hashCode = (31 * hashCode) + _pages.GetHashCode();
                hashCode = (31 * hashCode) + _price.GetHashCode();

                return hashCode;
            }
        }

        /// <summary>
        /// Returns string representation of the book.
        /// </summary>
        /// <returns>String that contains information about the book.</returns>
        public override string ToString()
        {
            return string.Format("{0} ({1}). {2}. ed. {3}, p.{4}. {5}. Price: {6}.", Author, Year, Title, Publisher, Pages, Isbn, Price);
        }

        /// <summary>
        /// Checks if the current instance and the other book are equal.
        /// </summary>
        /// <param name="other">The book to be compared to.</param>
        /// <returns>True, if the books are equal; otherwise, false.</returns>
        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return this.Isbn == other.Isbn &&
                   this.Author == other.Author &&
                   this.Title == other.Title &&
                   this.Publisher == other.Publisher &&
                   this.Year == other.Year &&
                   this.Pages == other.Pages &&
                   this.Price == other.Price;
        }

        /// <summary>
        /// Check if the current instance and the object are equal.
        /// </summary>
        /// <param name="obj">The object to be compared to.</param>
        /// <returns>rue, if the instance and object are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Book)obj);
        }

        /// <summary>
        /// Compare current instance with the other book by ISBN.
        /// </summary>
        /// <param name="other">The book to be compared to.</param>
        /// <returns>
        /// 1, if this instance's ISBN is greater.
        /// 0, if ISBNs are equal.
        /// -1, if the other's ISBN is greater.
        /// </returns>
        /// <example> 
        /// ISBN: 9971-5-0210-0 and 9971502100 -> true
        /// 0-8044-2957-X and 080-4429-57-x -> true
        /// </example>
        public int CompareTo(Book other)
        {
            string thisIsbn = this.Isbn?.Where(c => char.IsDigit(c) || char.ToUpper(c) == 'X').ToString();
            string otherIsbn = other?.Isbn?.Where(c => char.IsDigit(c) || char.ToUpper(c) == 'X').ToString();

            return thisIsbn.CompareTo(otherIsbn);
        }

        #endregion

        #region Private methods
        
        // Validate ISBN-10 and ISBN-13.
        // Some examples:
        // 0-684-84328-5 -> true
        // 0-8044-2957-X -> true
        // 0-9752298-0-x -> true
        // ISBN: 9971-5-0210-0 -> true
        // 8090273416 -> true
        // 0-85131-041-8 -> false
        // ISBN 978-0-306-40615-7 -> true
        // 978-0-306-40615-5 -> false
        private bool IsIsbnValid(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
            {
                return false;
            }

            int[] digits = isbn
                .Where(c => char.IsDigit(c) || char.ToUpper(c) == 'X')
                .Select(c => char.IsDigit(c) ? (int)char.GetNumericValue(c) : 10)
                .ToArray();

            switch (digits.Length)
            {
                case 10:
                    return IsIsbn10Valid(digits);
                case 13:
                    return ChecksumIsbn13(digits) == (digits.Last() % 10);
                default:
                    return false;
            }
        }
        
        // Calculate checksum of the ISBN-10.
        // NOTE: Parameters are not checked!
        // See: https://en.wikipedia.org/wiki/International_Standard_Book_Number
        private bool IsIsbn10Valid(int[] digits)
        {
            int sum = 0;
            int temp = 0;

            for (int i = 0; i < digits.Length; i++)
            {
                temp += digits[i];
                sum += temp;
            }

            return sum % 11 == 0;
        }

        // Calculate checksum of the ISBN-13.
        // NOTE: Parameters are not checked!
        // See: https://en.wikipedia.org/wiki/International_Standard_Book_Number
        private int ChecksumIsbn13(int[] digits)
        {
            // Calculate weighed sum of the first 9 digits.
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += (i % 2 == 0) ? digits[i] : digits[i] * 3;
            }
            
            // Checksum should be from 0 to 9. If calculated as 10 then = 0.
            return (10 - (sum % 10)) % 10;
        }

        #endregion
    }
}
