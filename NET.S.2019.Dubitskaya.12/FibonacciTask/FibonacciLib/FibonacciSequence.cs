using System;
using System.Collections;

namespace FibonacciLib
{
    internal class FibonacciSequence
    {
        /// <summary>
        /// Returns number of elements from fibonacci sequence one by one
        /// </summary>
        /// <param name="max"></param>
        public IEnumerable GetNextFib(int max)
        {
            yield return 1.0;
            double value1 = 0;
            double value2 = 1;
            double temp;
            for (int i = 1; i < max; i++)
            {
                temp = value1 + value2;
                value1 = value2;
                if (temp == double.PositiveInfinity)
                    yield break;
                else
                    yield return value2 = temp;
            }
        } 
    }
}
