using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomialClass.Tests
{
    [TestFixture]
    public class PolynomialTests
    {
        [TestCase(new double[] { 2, 3, 4 }, 4, new double[] { 8, 12, 16 }, ExpectedResult = true)]
        [TestCase(new double[] { 50, 15, 0 }, 0.5, new double[] { 25, 7.5, 0 }, ExpectedResult = true)]
        public static bool MultiplyOperatorTest_PolynomAndNumberInput(double[] coefs1, double number, double[] coefs2)
        {
            Polynomial poly1 = new Polynomial(coefs1);
            Polynomial poly2 = new Polynomial(coefs2);
            return poly2.Equals(poly1 * number);
        }

        [TestCase(new double[] { 2, 3, 4 }, new double[] { 1, 2, 3 }, new double[] { 2, 7, 16, 17, 12 }, ExpectedResult = true)]
        [TestCase(new double[] { 35, 0.0, 1, 56 }, new double[] { 15.5, -27.1, 0.0, 0.0, 345.223 },
            new double[] { 542.5, -948.5, 15.5, 840.9, 10565.205, 0.0, 345.223, 19332.488 }, ExpectedResult = true)]
        public static bool MultiplyOperatorTest_TwoPolynomsInput(double[] coefs1, double[] coefs2, double[] coefs3)
        {
            Polynomial poly1 = new Polynomial(coefs1);
            Polynomial poly2 = new Polynomial(coefs2);
            Polynomial poly3 = new Polynomial(coefs3);
            var a =(poly1 * poly2);
            return poly3 == (poly1 * poly2);
        }

        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0, 5 }, ExpectedResult = false)]
        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0 }, ExpectedResult = true)]
        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0, 6 }, ExpectedResult = true)]
        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0, -5 }, ExpectedResult = true)]
        [TestCase(new double[] { 16, 2, -63, 0, 5.001 }, new double[] { 16, 2, -63, 0, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 16, 2, -63, 0, 5.00000000001 }, new double[] { 16, 2, -63, 0, 5 }, ExpectedResult = true)]
        public static bool NotEqualOperatorTest_TwoPolynomsInput(double[] coefs1, double[] coefs2)
        {
            Polynomial poly1 = new Polynomial(coefs1);
            Polynomial poly2 = new Polynomial(coefs2);
            return poly1 != poly2;
        }

        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0, 6 }, ExpectedResult = false)]
        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0, -5 }, ExpectedResult = false)]
        [TestCase(new double[] { 16, 2, -63, 0, 5.01 }, new double[] { 16, 2, -63, 0, 5 }, ExpectedResult = false)]
        public static bool EqualOperatorTest_TwoPolynomsInput(double[] coefs1, double[] coefs2)
        {
            Polynomial poly1 = new Polynomial(coefs1);
            Polynomial poly2 = new Polynomial(coefs2);
            return poly1 == poly2;
        }

        [TestCase(new double[] { 16, 2 }, new double[] { 8, 21 }, new double[] { 8, -19 }, ExpectedResult = true)]
        [TestCase(new double[] { 16, 2 }, new double[] { 8, 21, 11 }, new double[] { 8, -19, -11 }, ExpectedResult = true)]
        [TestCase(new double[] { 16, 2 }, new double[] { -8, 21, 11 }, new double[] { 24, -19, -11 }, ExpectedResult = true)]
        public static bool MinusOperatorTest_TwoPolynomsInput(double[] coefs1, double[] coefs2, double[] coefs3)
        {
            Polynomial poly1 = new Polynomial(coefs1);
            Polynomial poly2 = new Polynomial(coefs2);
            Polynomial poly3 = new Polynomial(coefs3);
            return poly3.Equals(poly1 - poly2);
        }

        [TestCase(new double[] { 16, 2 }, new double[] { 8, 21 }, new double[] { 24, 23 }, ExpectedResult = true)]
        [TestCase(new double[] { 16, 2 }, new double[] { 8, 21, 11 }, new double[] { 24, 23, 11 }, ExpectedResult = true)]
        [TestCase(new double[] { 16, 2 }, new double[] { -8, 21, 11 }, new double[] { 8, 23, 11 }, ExpectedResult = true)]
        public static bool PlusOperatorTest_TwoPolynomsInput(double[] coefs1, double[] coefs2, double[] coefs3)
        {
            Polynomial poly1 = new Polynomial(coefs1);
            Polynomial poly2 = new Polynomial(coefs2);
            Polynomial poly3 = new Polynomial(coefs3);
            return poly3.Equals(poly1 + poly2);
        }

        [TestCase(new double[] { 8, 13, 4, 2, 19 }, ExpectedResult = "19*x^4 + 2*x^3 + 4*x^2 + 13*x^1 + 8")]
        [TestCase(new double[] { 16, -63, 0, 5 }, ExpectedResult = "5*x^3 - 63*x^1 + 16")]
        [TestCase(new double[] { 0, 0, 88 }, ExpectedResult = "88*x^2")]
        [TestCase(new double[] { 88, 0, 0 }, ExpectedResult = "88")]
        public static string ToString_PolynomInput_ReturnsStringFormOfPolynom(double[] coefs)
        {
            Polynomial poly = new Polynomial(coefs);
            return poly.ToString();
        }

        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0 }, ExpectedResult = false)]
        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0, 6 }, ExpectedResult = false)]
        [TestCase(new double[] { 16, 2, -63, 0, 5 }, new double[] { 16, 2, -63, 0, -5 }, ExpectedResult = false)]
        [TestCase(new double[] { 16, 2, -63, 0, 5.01 }, new double[] { 16, 2, -63, 0, 5 }, ExpectedResult = false)]
        public static bool Equals_TwoPolynomsInput_ReturnsTrueIfEqual(double[] coefs1, double[] coefs2)
        {
            Polynomial poly1 = new Polynomial(coefs1);
            Polynomial poly2 = new Polynomial(coefs2);
            return poly1.Equals(poly2);
        }
    }
}
