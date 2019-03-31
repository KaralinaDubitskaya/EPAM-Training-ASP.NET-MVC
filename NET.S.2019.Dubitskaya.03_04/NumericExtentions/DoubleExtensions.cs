using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumericExtentions
{
    public static class DoubleExtensions
    {
        private const byte ulongLengthInBits = 64;

        /// <summary>
        /// Convert double value to binary string representation according to IEEE 754 format. 
        /// </summary>
        /// <param name="value">Value to be convarted.</param>
        /// <returns>Binary string representation of the number.</returns>
        /// <example> 255.255 -> "0100000001101111111010000010100011110101110000101000111101011100" </example>
        public static unsafe string ToBinaryString(this double value)
        {
            ulong ulongValue = *((ulong*)&value);

            StringBuilder sb = new StringBuilder(ulongLengthInBits);
            for (int index = ulongLengthInBits - 1; index >= 0; index--)
            {
                sb.Append(IsBitSet(ulongValue, index) ? '1' : '0'); 
            }

            return sb.ToString();
        }

        /// <summary>
        /// Check if the specified bit is set. 
        /// </summary>
        /// <param name="value">Number which bit will be checked.</param>
        /// <param name="position">Index of the bit to be checked.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the bit position is less than 0 or greater than 63.</exception>
        /// <returns>True if the bit equals 1, else returns false.</returns>
        private static bool IsBitSet(ulong value, int position)
        {
            if (position < 0 || position > ulongLengthInBits - 1)
            {
                throw new ArgumentOutOfRangeException();
            }

            return (value & ((ulong)1 << position)) != 0;
        }
    }
}
