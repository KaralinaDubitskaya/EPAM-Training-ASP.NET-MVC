using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberInserting
{
    public static class NumberInserter
    {
        /// <summary>
        /// Number of bits in Int32 value.
        /// </summary>
        private const int _intLengthInBits = 32;

        /// <summary>
        /// Insert starting bits from numberIn into numberSource at the given positions.
        /// </summary>
        /// <param name="numberSource">The number into which the bits will be inserted.</param>
        /// <param name="numberIn">Number from which bits will be inserted.</param>
        /// <param name="startIndex">The starting position of bits to be inserted.</param>
        /// <param name="endIndex">The ending position of bits to be inserted.</param>
        /// <returns>Number with inserted bits.</returns>
        /// <exception cref="ArgumentException">Thrown when starting index is greater than the ending index or some index is negative.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when some index is greater than 31 (the last index of the Int32 value).</exception>
        /// <example> InsertNumber(15, 15, 0, 0) -> 15 </example>
        /// <example> InsertNumber(8, 15, 0, 0) -> 9 </example>
        /// <example> InsertNumber(8, 15, 3, 8) -> 120 </example>
        public static int InsertNumber(int numberSource, int numberIn, int startIndex, int endIndex)
        {
            ValidateIndexes(startIndex, endIndex);

            int bitsToBeInserted = ExtractBits(numberIn, endIndex - startIndex + 1);
            int mask = bitsToBeInserted << startIndex;

            numberSource = FillBitsWithZeros(numberSource, startIndex, endIndex);
            return numberSource ^ mask;
        }

        /// <summary>
        /// Extract starting bits from the number.
        /// </summary>
        /// <param name="number">The number with bits to be extracted.</param>
        /// <param name="numOfBits">Number of bits to be extracted.</param>
        /// <returns>Extracted bits.</returns>
        /// <exception cref="ArgumentException">Thrown when the number of bits is negative.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when the number of bits is greater than 31 (the last index of the Int32 value).</exception>
        /// <example> ExtractBits(14, 3) -> 6 </example>
        private static int ExtractBits(int number, int numOfBits)
        {
            if (numOfBits < 0)
            {
                throw new ArgumentException("The number of bits cannot be negative.");
            }

            if (numOfBits > _intLengthInBits)
            {
                throw new IndexOutOfRangeException("The number of bits cannot be greater than 31 for Int32 values.");
            }

            // Example: 0b0100 - 1 = 0b0011.
            int mask = (1 << numOfBits) - 1;
            return number & mask;
        }

        /// <summary>
        /// Fill the specified range of bits of the number with zeros.
        /// </summary>
        /// <param name="number">The number with bits to be filled with zeros.</param>
        /// <param name="start">The starting index of the range.</param>
        /// <param name="end">The ending index of the range.</param>
        /// <returns>The number with the range of bits filled with zeros.</returns>
        /// <exception cref="ArgumentException">Thrown when starting index is greater than the ending index or some index is negative.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when some index is greater than 31 (the last index of the Int32 value).</exception>
        /// <example> FillBitsWithZeros(15, 1, 2) -> 9 </example>
        private static int FillBitsWithZeros(int number, int start, int end)
        {
            ValidateIndexes(start, end);

            int numOfZeroBits = end - start + 1;
            int mask = (1 << numOfZeroBits) - 1;
            return number & ~mask;
        }

        /// <summary>
        /// Validate the indexes of a bits range in the Int32 value.
        /// </summary>
        /// <param name="start">The starting index.</param>
        /// <param name="end">The ending index.</param>
        /// <exception cref="ArgumentException">Thrown when starting index is greater than the ending index or some index is negative.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown when some index is greater than 31 (the last index of the Int32 value).</exception>
        private static void ValidateIndexes(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException("The starting index cannot be greater than the ending index.");
            }

            if (start < 0 || end < 0)
            {
                throw new ArgumentException("Index cannot be negative.");
            }

            if (start >= _intLengthInBits || end >= _intLengthInBits)
            {
                throw new IndexOutOfRangeException("The index cannot be greater than 31 (the last index of the Int32 value).");
            }
        }
    }
}
