using System;
using NUnit.Framework;

namespace NthRootFinding.Tests
{
    [TestFixture]
    public class NthRootFinderTests
    {
        [TestCase(9.0, 1, 0.0001, 9.0)]
        [TestCase(0, 3, 0.0001, 0)]
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void IFindNthRoot_PositiveNumber(double number, byte rootPower, double eps, double expected)
        {
            double result = NthRootFinder.FindNthRoot(number, rootPower, eps);
            Assert.AreEqual(expected, result, eps);
        }

        [TestCase(-9.0, 1, 0.0001, -9.0)]
        [TestCase(-1, 3, 0.0001, -1)]
        [TestCase(-8, 3, 0.0001, -2)]
        [TestCase(-0.001, 3, 0.0001, -0.1)]
        [TestCase(-8, 3, 0.0001, -2)]
        [TestCase(-0.0279936, 7, 0.0001, -0.6)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(-0.004241979, 9, 0.00000001, -0.545)]
        public void IFindNthRoot_NegativeNumber(double number, byte rootPower, double eps, double expected)
        {
            double result = NthRootFinder.FindNthRoot(number, rootPower, eps);
            Assert.AreEqual(expected, result, eps);
        }

        [TestCase(9.0, -1, 0.0001, 0.11111111)]
        [TestCase(1, -3, 0.0001, 1)]
        [TestCase(8, -3, 0.0001, 0.5)]
        public void IFindNthRoot_NegativeRoot(double number, double rootPower, double eps, double expected)
        {
            double result = NthRootFinder.FindNthRoot(number, rootPower, eps);
            Assert.AreEqual(expected, result, eps);
        }

        [Test]
        public void FindNthRoot_NegativeEpsilon_ArgumentException()
            => Assert.Throws<ArgumentException>(() => NthRootFinder.FindNthRoot(9.0, 2, -0.1));

        [Test]
        public void FindNthRoot_ZeroRootPower_ArgumentException()
            => Assert.Throws<ArgumentException>(() => NthRootFinder.FindNthRoot(9.0, 0, 0.001));

        [Test]
        public void FindNthRoot_NegativeNumberAndEvenRootPower_ArgumentException()
            => Assert.Throws<ArgumentException>(() => NthRootFinder.FindNthRoot(-9.0, 2, 0.001));
    }
}
