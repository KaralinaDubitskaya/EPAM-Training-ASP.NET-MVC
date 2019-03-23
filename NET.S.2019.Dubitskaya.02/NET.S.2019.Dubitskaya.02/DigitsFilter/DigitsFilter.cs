using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsFiltering
{
    public static class DigitsFilter
    {
        /// <summary>
        /// Filter given numbers and return only numbers containing the specified digit.
        /// </summary>
        /// <param name="numbers">The numbers to be filtered.</param>
        /// <param name="digit">The digit which should be found.</param>
        /// <returns>Numbers that contains the digit.</returns>
        /// <exception cref="ArgumentException"> Thrown if the digit value isn't between 0 and 9.</exception>
        /// <exception cref="ArgumentNullException"> Thrown if numbers are null.</exception>
        public static IEnumerable<int> FilterDigits(IEnumerable<int> numbers, byte digit)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            IEnumerable<int> FilterDigitsImpl()
            {
                foreach (int number in numbers)
                {
                    if (number.ContainsDigit(digit))
                    {
                        yield return number;
                    }
                }
            }

            return FilterDigitsImpl();
        }

        /// <summary>
        /// Check whether the number contains the given digit.
        /// </summary>
        /// <param name="number">The number which can contain the digit.</param>
        /// <param name="digit">The digit to be found.</param>
        /// <returns>True if the number contains the digit, else false.</returns>
        /// <exception cref="ArgumentException"> Thrown if the digit value isn't between 0 and 9.</exception>
        /// <example> ContainsDigit(10, 1) -> true </example>
        /// <example> ContainsDigit(10, 2) -> false </example>
        private static bool ContainsDigit(this int number, byte digit)
        {
            if (!char.TryParse(digit.ToString(), out char digitChar))
            {
                throw new ArgumentException("The digit should be from 0 to 9.");
            }

            string numberString = number.ToString();
            
            foreach (char ch in numberString)
            {
                if (ch == digitChar)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
