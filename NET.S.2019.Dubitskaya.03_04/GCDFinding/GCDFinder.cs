using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCDFinding
{
    public class GCDFinder
    {
        /// <summary>
        /// Find the greatest common divisor of the given integer values by Euclidean algorithm.
        /// </summary>
        /// <param name="timeElapsed">The time interval that have elapsed since the calculations started.</param>
        /// <param name="args">Numbers which GCD should be found.</param>
        /// <returns>GCD of the given numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when there're less than 2 numbers provided to calculation.</exception>
        /// <exception cref="ArgumentNullException">Thrown when given arguments are null.</exception>
        public static int GetGCDByEuclideanAlgorithm(out TimeSpan timeElapsed, params int[] args)
            => GetGCDAndTimeElapsed(EuclideanAlgorithm, out timeElapsed, args);

        /// <summary>
        /// Find the greatest common divisor of the given integer values by Stein's Algorithm (Binary GCD Algorithm). 
        /// </summary>
        /// <param name="timeElapsed">The time interval that have elapsed since the calculations started.</param>
        /// <param name="args">Numbers which GCD should be found.</param>
        /// <returns>GCD of the given numbers.</returns>
        /// <exception cref="ArgumentException">Thrown when there're less than 2 numbers provided to calculation.</exception>
        /// <exception cref="ArgumentNullException">Thrown when given arguments are null.</exception>
        public static int GetGCDBySteinsAlgorithm(out TimeSpan timeElapsed, params int[] args)
            => GetGCDAndTimeElapsed(BinaryGCDAlgorithm, out timeElapsed, args);

        /// <summary>
        /// Find the greatest common divisor of the given integer values by the specified algorithm.
        /// </summary>
        /// <param name="gcdFinder">An algorithm to find the greatest common divisor.</param>
        /// <param name="timeElapsed">The time interval that have elapsed since the calculations started.</param>
        /// <param name="args">Numbers which GCD should be found.</param>
        /// <returns>GCD of the given numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when at least one argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when there're less than 2 numbers provided to calculation.</exception>
        private static int GetGCDAndTimeElapsed(Func<int, int, int> gcdFinder, out TimeSpan timeElapsed, params int[] args)
        {
            var timer = Stopwatch.StartNew();
            
            int gcd = GetGCD(gcdFinder, args);

            timer.Stop();
            timeElapsed = timer.Elapsed;

            return gcd;
        }

        /// <summary>
        /// Find the greatest common divisor of the given integer values by the specified algorithm.
        /// </summary>
        /// <param name="gcdFinder">An algorithm to find the greatest common divisor.</param>
        /// <param name="args">Numbers which GCD should be found.</param>
        /// <returns>GCD of the given numbers.</returns>
        /// <exception cref="ArgumentNullException">Thrown when at least one argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when there're less than 2 numbers provided to calculation.</exception>
        private static int GetGCD(Func<int, int, int> gcdFinder, params int[] args)
        {
            if (gcdFinder == null || args == null)
            {
                throw new ArgumentNullException();
            }

            if (args.Length < 2)
            {
                throw new ArgumentException("At least two numbers for GCD computing should be provided.");
            }

            // gdc(a, b, c) = gdc(gdc(a, b), c) = gdc(a, gdc(b, c)) = gdc(gdc(a, c), b)
            int gcd = args[0];
            for (int i = 1; i < args.Length; i++)
            {
                gcd = gcdFinder(gcd, args[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Find the greatest common divisor of two integer values by Euclidean Algorithm. 
        /// </summary>
        /// <param name="a">The first integer number.</param>
        /// <param name="b">The second integer number.</param>
        /// <returns>The GCD of two integer values.</returns>
        /// <example> EuclideanAlgorithm(100, 45) -> 5 </example>
        /// <example> EuclideanAlgorithm(6, 35) -> 1 </example>
        /// <example> EuclideanAlgorithm(0, 10) -> 10 </example>
        /// <example> EuclideanAlgorithm(0, 0) -> 0 </example>
        /// <see cref="https://en.wikipedia.org/wiki/Euclidean_algorithm"/>
        private static int EuclideanAlgorithm(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                return 0;
            }

            // The arguments could be negative, but GCD is the same as for positive numbers.
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }

            int min = Math.Min(a, b);
            int max = Math.Max(a, b);

            while (min != 0)
            {
                max = max % min;
                Swap(ref min, ref max);
            }

            return max;
        }

        /// <summary>
        /// Find the greatest common divisor of two integer values by Stein's Algorithm (Binary GCD Algorithm). 
        /// </summary>
        /// <param name="a">The first integer number.</param>
        /// <param name="b">The second integer number.</param>
        /// <returns>The GCD of two integer values.</returns>
        /// <exception cref="ArgumentException">Thrown when both arguments are zero. GDC(0, 0) is undefined.</exception>
        /// <example> BinaryGCDAlgorithm(100, 45) -> 5 </example>
        /// <example> BinaryGCDAlgorithm(6, 35) -> 1 </example>
        /// <example> BinaryGCDAlgorithm(0, 10) -> 10 </example>
        /// <example> BinaryGCDAlgorithm(0, 0) -> 0 </example>
        /// <see cref="https://en.wikipedia.org/wiki/Binary_GCD_algorithm"/>
        private static int BinaryGCDAlgorithm(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                return 0;
            }

            // The arguments could be negative, but GCD is the same as for positive numbers.
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a == 0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }
            
            // If both numbers are even, gcd(a, b) = 2·gcd(a/2, b/2).
            int shift;
            for (shift = 0; ((a | b) & 1) == 0; ++shift)
            {
                // Divide each number by 2.
                a >>= 1;
                b >>= 1;
            }

            // While a is even, divide it by 2. 
            // b is odd, so that gcd(a, b) = gcd(a/2, b), because 2 is not a common divisor.
            while ((a & 1) == 0)
            {
                a >>= 1; 
            }

            do
            {
                // While b is even, divide it by 2. 
                // a is odd, so that gcd(a, b) = gcd(a, b/2), because 2 is not a common divisor.
                while ((b & 1) == 0)
                {
                    b >>= 1;
                }

                if (a > b)
                {
                    Swap(ref a, ref b);
                }

                b = b - a;
            }
            while (b != 0);

            return a << shift;
        }

        /// <summary>
        /// Swap two integer numbers.
        /// </summary>
        /// <param name="a">The first number to be swapped.</param>
        /// <param name="b">The second number to be swapped.</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }        
    }
}
