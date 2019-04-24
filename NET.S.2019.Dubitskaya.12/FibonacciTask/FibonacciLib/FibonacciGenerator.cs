using System;

namespace FibonacciLib
{
    /// <summary>
    /// Provides method that returns number of elements from fibonacci sequence
    /// </summary>
    public class FibonacciGenerator
    {
        /// <summary>
        /// Returns number of elements from fibonacci sequence in string format
        /// </summary>
        /// <param name="n"></param>
        public static string Generate(int n)
        {
            if (n < 0)
                throw new ArgumentException("Argument can't be less then 0");

            string result = string.Empty;
            FibonacciSequence fs = new FibonacciSequence();
            foreach (double num in fs.GetNextFib(n))
            {
                result += string.Format("{0:f0} ", num.ToString());
            }

            return result;
        }       
    }
}
