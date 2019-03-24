using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthRootFinding
{
    public static class NthRootFinder
    {
        /// <summary>
        /// Find Nth root of the number using the Newton method.
        /// </summary>
        /// <param name="number">A double-precision floating-point number root of which should be calculated.</param>
        /// <param name="rootPower">A root to be found.</param>
        /// <param name="eps">Calculation precision.</param>
        /// <returns>Nth root of the number.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the epsilon value is negative.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the root power isn't positive.</exception>
        /// <exception cref="ArgumentException">Thrown when the root power is even and the number is negative.</exception>
        /// <example> FindNthRoot(1, 5, 0.001) -> 1 </example>
        /// <example> FindNthRoot(0.04100625, 4, 0.0001) -> 0.45 </example>
        /// <example> FindNthRoot(-0.008, 3, 0.1) -> -0.2 </example>
        public static double FindNthRoot(double number, long rootPower, double eps)
        {
            if (eps < 0)
            {
                throw new ArgumentOutOfRangeException("The epsilon value cannot be negative.");
            }
            
            if (rootPower <= 0)
            {
                throw new ArgumentOutOfRangeException("The root power value should be positive.");
            }

            if (number < 0 && rootPower % 2 == 0)
            {
                throw new ArgumentException("Incorrect root power value for a negative number.");
            }

            // x^1 = x
            if (rootPower == 1)
            {
                return number;
            }

            // 0^x = 0; 1^x = 1
            if (number == 0 || number == 1)
            {
                return number;
            }

            double power = rootPower;
            double x0 = number / power;
            double x1 = (1 / power) * (((power - 1) * x0) + (number / Math.Pow(x0, power - 1)));

            while (Math.Abs(x1 - x0) >= eps)
            {
                x0 = x1;
                x1 = (1 / power) * (((power - 1) * x0) + (number / Math.Pow(x0, power - 1)));
            }

            return x1;
        }
    }
}
