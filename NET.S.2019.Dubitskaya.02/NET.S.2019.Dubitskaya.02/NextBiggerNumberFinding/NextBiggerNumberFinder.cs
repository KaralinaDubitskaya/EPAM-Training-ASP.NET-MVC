using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextBiggerNumberFinding
{
    public static class NextBiggerNumberFinder
    {
        private const int ResultNotExist = -1;

        /// <summary>
        /// Return closest number which is larger than a given source number and consists of the same digits.
        /// </summary>
        /// <param name="number">The source number.</param>
        /// <returns>
        /// Next bigger number which consists of the same digits as the source number.
        /// If it doesn't exist or is bigger than 4-bytes value, return -1.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when the source number is negative.</exception>
        /// <example> FindNextBiggerNumber(414) - > 441 </example>
        /// <example> FindNextBiggerNumber(3456432) - > 3462345 </example>
        /// <example> FindNextBiggerNumber(20) - > -1 </example>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("The number should be positive.");
            }
            
            char[] digits = number.ToString().ToCharArray();

            // If all digits are in a descending order, the number is the greatest possible value.
            if (digits.SequenceEqual(digits.OrderByDescending(digit => digit)))
            {
                return ResultNotExist;
            }

            // Iterate from the least digit.
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                // If current digit is greater than the next one, swap them. 
                // After that sort current and previous digits in an ascending order.
                if (digits[i] > digits[i - 1])
                {
                    Swap<char>(ref digits[i], ref digits[i - 1]);
                    digits.PartialSort(i, digits.Length - 1);
                    break;
                }
            }
            
            try
            {
                return Convert.ToInt32(new string(digits));
            }
            catch (OverflowException)
            {
                // The value is bigger than int, so that return -1.
                return -1;
            }  
        }

        /// <summary>
        /// Swap two values.
        /// </summary>
        /// <param name="a">The first value to be swapped.</param>
        /// <param name="b">The second value to be swapped.</param>
        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Sort part of the sequence in an ascending order.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the sequence.</typeparam>
        /// <param name="sequence">The sequence which part will be sorted.</param>
        /// <param name="startIndex">The starting index of the subsequence to be sorted.</param>
        /// <param name="endIndex">The ending index of the subsequence to be sorted.</param>
        private static void PartialSort<T>(this T[] sequence, int startIndex, int endIndex)
        {
            sequence.Skip(startIndex).Take(endIndex - startIndex + 1)
                .OrderBy(el => el).ToArray().CopyTo(sequence, startIndex);
        }
    }
}
