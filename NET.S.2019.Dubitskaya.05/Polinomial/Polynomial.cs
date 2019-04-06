using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialClass
{
    public sealed class Polynomial : IEquatable<Polynomial>
    {
        private double[] _coefficients;
        
        /// <summary>
        /// The degree of the polynomial.
        /// </summary>
        public int Degree
        {
            get 
            {
                // Degree of a number is zero.
                if (_coefficients.Length == 1)
                {
                    return 0;
                }

                // Some coefficients could be zero.
                int i;
                for (i = _coefficients.Length - 1; i >= 0; i--)
                {
                    if (Math.Abs(_coefficients[i]) > double.Epsilon)
                    {
                        break;
                    }
                }
                return i;
            }
        }

        /// <summary>
        /// A coefficient of the specified power of the polynomial.
        /// </summary>
        /// <param name="power">A power of the variable that occurs in the polynomial.</param>
        /// <exception cref="ArgumentOutOfRangeException">Power is not a valid index.</exception>
        /// <returns>Returns a coefficient of the specified power of the variable.</returns>
        public double this[int power]
        {
            get
            {
                if (power >= 0 && power <= Degree)
                {
                    return _coefficients[power];
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            private set
            {
                if (power >= 0 && power <= Degree)
                {
                    _coefficients[power] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        /// Represent a polynomial in one variable.
        /// </summary>
        /// <param name="coefficients">Coefficients of the polynomial.</param>
        /// <exception cref="ArgumentNullException">Thrown if the argument is null.</exception>
        public Polynomial(params double[] coefficients)
        {
            _coefficients = coefficients ?? new double[] { };
        }
        
        /// <summary>
        /// Implicit conversion from double value to Polynomial object.
        /// </summary>
        /// <param name="value">Double value to be converted.</param>
        public static implicit operator Polynomial(double value)
        {
            return new Polynomial(value);
        }

        /// <summary>
        /// Negates a polynomial.
        /// </summary>
        /// <param name="polynomial">A polynomial to be negated.</param>
        /// <returns>The negation of the polynomial.</returns>
        public static Polynomial operator -(Polynomial polynomial)
        {
            var resultPolynomial = new Polynomial(polynomial._coefficients);

            for (int i = 0; i <= resultPolynomial.Degree; i++)
            {
                resultPolynomial[i] *= -1;
            }

            return resultPolynomial;
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
            int minLength = Math.Min(first.Degree, second.Degree) + 1;
            int maxLength = Math.Max(first.Degree, second.Degree) + 1;

            double[] resultCoefficients = new double[maxLength];

            for (int i = 0; i < minLength; i++)
            {
                resultCoefficients[i] = first[i] + second[i];
            }

            if (first.Degree > second.Degree)
            {
                Array.Copy(first._coefficients, minLength, resultCoefficients, minLength, maxLength - minLength);
            }
            else
            {
                Array.Copy(second._coefficients, minLength, resultCoefficients, minLength, maxLength - minLength);
            }

            return new Polynomial(resultCoefficients);
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
        /// Multiplies two polynomials.
        /// </summary>
        /// <param name="first">A polynomial to be multiplied.</param>
        /// <param name="second">A polynomial to be multiplied.</param>
        /// <returns>A new polynomial containing the result of multiplication.</returns>
        /// <example> (2x - 1)(5x - 6) = 10x^2 - 17x + 6</example>
        public static Polynomial operator *(Polynomial first, Polynomial second)
        {
            int resultLength = first.Degree + second.Degree + 2;

            double[] resultCoefficients = new double[resultLength];

            for (int i = 0; i <= first.Degree; i++)
            {
                for (int j = 0; j <= second.Degree; j++)
                {
                    resultCoefficients[i + j] += first[i] * second[j];
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
            double[] resultCoefficients = new double[polynomial.Degree];

            for (int i = 0; i < polynomial.Degree; i++)
            {
                resultCoefficients[i] = polynomial[i] / divider;
            }

            return new Polynomial(resultCoefficients);
        }

        /// <summary>
        /// Checks if the current instance and the polynomial are equal.
        /// </summary>
        /// <param name="other">The polynomial to be compared.</param>
        /// <returns>True, if the polynomials are equal; otherwise, false.</returns>
        public bool Equals(Polynomial other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (this.Degree != other.Degree)
            {
                return false;
            }

            for (int i = 0; i <= this.Degree; i++)
            {
                if (!this[i].Equals(other[i]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if current instance and object are equal.
        /// </summary>
        /// <param name="obj">The object to be compared.</param>
        /// <returns>
        /// True, if the instance and object are equal; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Polynomial)obj);
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
            if (ReferenceEquals(first, second))
            {
                return true;
            }

            if (ReferenceEquals(first, null))
            {
                return false;
            }

            return first.Equals(second);
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

            for (int i = Degree; i >= 0; i--)
            {
                if (this[i] != 0.0)
                {
                    if (i == 0)
                    {
                        if (sb.Length > 0)
                        {
                            sb.AppendFormat($" + {this[i]}");
                        }
                        else
                        {
                            sb.Append(this[i]);
                        }
                    }
                    else
                    {
                        if (sb.Length > 0)
                        {
                            if (this[i] > 0)
                            {
                                sb.AppendFormat($" + {this[i]}*x^{i}");
                            }
                            else
                            {
                                sb.AppendFormat($" - {Math.Abs(this[i])}*x^{i}");
                            }
                        }
                        else
                        {
                            sb.AppendFormat($"{this[i]}*x^{i}");
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
            unchecked
            {
                return ((_coefficients != null ? _coefficients.GetHashCode() : 0) * 397) ^ Degree;
            }
        }
    }
}
