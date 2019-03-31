using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialClass
{
    public sealed class Polynomial
    {
        private double[] _coefficients;

        /// <summary>
        /// Represent a polynomial in one variable.
        /// </summary>
        /// <param name="coefficients">Coefficients of the polynomial.</param>
        /// <exception cref="ArgumentNullException">Thrown if the argument is null.</exception>
        public Polynomial(double[] coefficients)
        {
            Coefficients = coefficients;
        }

        /// <summary>
        /// Coefficients of the polynomial.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when there is an attempt to set null value.</exception>
        public double[] Coefficients
        {
            get
            {
                return _coefficients;
            }

            set
            {
                _coefficients = value ?? throw new ArgumentNullException();
            }
        }

        /// <summary>
        /// Negates a polynomial.
        /// </summary>
        /// <param name="polynomial">A polynomial to be negated.</param>
        /// <returns>The negation of the polynomial.</returns>
        public static Polynomial operator -(Polynomial polynomial)
        {
            var resultPolynomial = new Polynomial(polynomial.Coefficients);

            for (int i = 0; i < resultPolynomial.Coefficients.Length; i++)
            {
                resultPolynomial.Coefficients[i] *= -1;
            }

            return resultPolynomial;
        }

        /// <summary>
        /// Adds a scalar and a polynomial.
        /// </summary>
        /// <param name="polynomial">A polynomial.</param>
        /// <param name="multiplier">A scalar.</param>
        /// <returns>A new polynomial containing the sum.</returns>
        /// <example> (2x - 1) + 3 = 2x + 2</example>
        public static Polynomial operator +(Polynomial polynomial, double summand)
        {
            double[] resultCoefficients = new double[polynomial.Coefficients.Length];

            for (int i = 0; i < polynomial.Coefficients.Length; i++)
            {
                resultCoefficients[i] = polynomial.Coefficients[i] + summand;
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// Adds a scalar and a polynomial.
        /// </summary>
        /// <param name="multiplier">A scalar.</param>
        /// <param name="polynomial">A polynomial.</param>
        /// <returns>A new polynomial containing the sum.</returns>
        /// <example> 3 + (2x - 1) = 2x + 2</example>
        public static Polynomial operator +(double summand, Polynomial polynomial)
        {
            return polynomial + summand;
        }

        /// <summary>
        /// Add two polynomials.
        /// </summary>
        /// <param name="first">The first polynomial to be added.</param>
        /// <param name="second">The second polynomial to be added.</param>
        /// <returns>The sum of the polynomials.</returns>
        /// <example> (2x^3 + 4x) + (4x^3 + x^2 + 1) = 6x^3 + x^2 + 4x + 1</example>
        public static Polynomial operator +(Polynomial first, Polynomial second)
        {
            int minLength = Math.Min(first.Coefficients.Length, second.Coefficients.Length);
            int maxLength = Math.Max(first.Coefficients.Length, second.Coefficients.Length);

            double[] resultCoefficients = new double[maxLength];

            for (int i = 0; i < minLength; i++)
            {
                resultCoefficients[i] = first.Coefficients[i] + second.Coefficients[i];
            }

            if (first.Coefficients.Length > second.Coefficients.Length)
            {
                Array.Copy(first.Coefficients, minLength, resultCoefficients, minLength, maxLength - minLength);
            }
            else
            {
                Array.Copy(second.Coefficients, minLength, resultCoefficients, minLength, maxLength - minLength);
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// Subtract a scalar from a polynomial.
        /// </summary>
        /// <param name="polynomial">A polynomial.</param>
        /// <param name="multiplier">A scalar.</param>
        /// <returns>A new polynomial containing the difference.</returns>
        /// <example> (2x - 1) - 3 = 2x - 4</example>
        public static Polynomial operator -(Polynomial polynomial, double minuend)
        {
            return polynomial + (-minuend);
        }

        /// <summary>
        /// Subtract a scalar and a polynomial.
        /// </summary>
        /// <param name="polynomial">A polynomial.</param>
        /// <param name="multiplier">A scalar.</param>
        /// <returns>A new polynomial containing the difference.</returns>
        /// <example> 3 - (2x - 1) = -2x + 4 </example>
        public static Polynomial operator -(double subtrahend, Polynomial polynomial)
        {
            return subtrahend + (-polynomial);
        }

        /// <summary>
        /// Subtract two polynomials.
        /// </summary>
        /// <param name="first">A minuend.</param>
        /// <param name="second">A subtrahend.</param>
        /// <returns>A new polynomial containing the difference.</returns>
        /// <example> (2x^3 + 4x) - (4x^3 + x^2 + 1) = -2x^3 - x^2 + 4x - 1</example>
        public static Polynomial operator -(Polynomial first, Polynomial second)
        {
            return first + (-second);
        }

        /// <summary>
        /// Multiplies a scalar and a polynomial.
        /// </summary>
        /// <param name="polynomial">A polynomial.</param>
        /// <param name="multiplier">A scalar.</param>
        /// <returns>A new polynomial containing the result of multiplication.</returns>
        /// <example> (2x - 1)*3 = 6x - 6</example>
        public static Polynomial operator *(Polynomial polynomial, double multiplier)
        {
            double[] resultCoefficients = new double[polynomial.Coefficients.Length];

            for (int i = 0; i < polynomial.Coefficients.Length; i++)
            {
                resultCoefficients[i] = polynomial.Coefficients[i] * multiplier;
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// Multiplies a scalar and a polynomial.
        /// </summary>
        /// <param name="multiplier">A scalar.</param>
        /// <param name="polynomial">A polynomial.</param>
        /// <returns>A new polynomial containing the result of multiplication.</returns>
        /// <example> 3*(2x - 1) = 6x - 6</example>
        public static Polynomial operator *(int multiplier, Polynomial polynomial)
        {
            return polynomial * multiplier;
        }

        /// <summary>
        /// Multiplies two polynomials.
        /// </summary>
        /// <param name="first">A polynomial to be multiplied.</param>
        /// <param name="second">A polynomial to be multiplied.</param>
        /// <returns>A new polynomial containing the result of multiplication.</returns>
        /// <example> (2x - 1)(5x - 6) = 10x^2 - 17x + 6</example>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            int resultLength = first.Coefficients.Length + second.Coefficients.Length - 1;

            double[] resultCoefficients = new double[resultLength];

            for (int i = 0; i < first.Coefficients.Length; i++)
            {
                for (int j = 0; j < second.Coefficients.Length; j++)
                {
                    resultCoefficients[i + j] += first.Coefficients[i] * second.Coefficients[j];
                }
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// Divides a polynomial by a scalar.
        /// </summary>
        /// <param name="polynomial">A polynomial.</param>
        /// <param name="divider">A scalar.</param>
        /// <returns>A new polynomial containing the quotient.</returns>
        /// <example> (6x - 4) / 2 = 3x - 2</example>
        public static Polynomial operator /(Polynomial polynomial, double divider)
        {
            double[] resultCoefficients = new double[polynomial.Coefficients.Length];

            for (int i = 0; i < polynomial.Coefficients.Length; i++)
            {
                resultCoefficients[i] = polynomial.Coefficients[i] / divider;
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// Tests for equality two polynomials. They are equal if their coefficient vectors
        /// have the same dimensions and all values are equal.
        /// </summary>
        /// <param name="first">A polynomial to be compared.</param>
        /// <param name="second">A polynomial to be compared.</param>
        /// <returns>True, if polynomials are equal; otherwise, false.<returns>
        public static bool operator ==(Polynomial first, Polynomial second)
        {
            if (first.Coefficients.Length != second.Coefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < first.Coefficients.Length; i++)
            {
                if (first.Coefficients[i] != second.Coefficients[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Tests for inequality two polynomials. They are equal if their coefficient vectors
        /// have the same dimensions and all values are equal.
        /// </summary>
        /// <param name="first">A polynomial to be compared.</param>
        /// <param name="second">A polynomial to be compared.</param>
        /// <returns>True, if polynomials are inequal; otherwise, false.<returns>
        public static bool operator !=(Polynomial first, Polynomial second)
        {
            return !(first == second);
        }

        /// <summary>
        /// Returns a string representation of the polynomial.
        /// </summary>
        /// <returns>A string representation of the polynomial: an*x^n + ... + a1*x + a0.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = Coefficients.Length - 1; i >= 0; i--)
            {
                if (Coefficients[i] != 0.0)
                {
                    if (i == 0)
                    {
                        if (sb.Length > 0)
                        {
                            sb.AppendFormat($" + {Coefficients[i]}");
                        }
                        else
                        {
                            sb.Append(Coefficients[i]);
                        }
                    }
                    else
                    {
                        if (sb.Length > 0)
                        {
                            if (Coefficients[i] > 0)
                            {
                                sb.AppendFormat($" + {Coefficients[i]}*x^{i}");
                            }
                            else
                            {
                                sb.AppendFormat($" - {Math.Abs(Coefficients[i])}*x^{i}");
                            }
                        }
                        else
                        {
                            sb.AppendFormat($"{Coefficients[i]}*x^{i}");
                        }
                    }
                }
            }

            return (sb.Length == 0) ? "0" : sb.ToString();
        }

        /// <summary>
        /// Returns an integer hash code for this polynomial.
        /// </summary>
        /// <returns>An integer hash code.</returns>
        public override int GetHashCode()
        {
            int hashcode = 13;

            for (int i = 0; i < Coefficients.Length; i++)
            {
                hashcode = (hashcode * 7) + Coefficients[i].GetHashCode();
            }

            return hashcode;
        }

        /// <summary>
        /// Checks if current instance and object are equal
        /// </summary>
        /// <param name="obj">The object to be compared.</param>
        /// <returns>
        /// True, if the instance and object are equal; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType() || obj == null || this != (Polynomial)obj)
            {
                return false;
            }

            return true;
        }
    }
}
