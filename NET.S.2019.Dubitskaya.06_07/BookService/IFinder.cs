namespace BookService
{
    /// <summary>
    /// Interface that allows to find books by specified tag.
    /// </summary>
    public interface IFinder
    {
        /// <summary>
        /// Check if the book matchs the specified value of the field.
        /// </summary>
        /// <param name="book">The book to be checked.</param>
        /// <returns>True, if the book match; otherwise, false.</returns>
        bool IsMatch(Book book);
    }
}