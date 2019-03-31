using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace GCDFinding.Tests
{
    [TestFixture]
    public class GDCFinderTests
    {
        #region TestCaseData

        public static IEnumerable<TestCaseData> GCDFinderTestCases_PositiveNumbers
        {
            get
            {
                yield return new TestCaseData(new[] { 7, 14, 49 }).Returns(7);
                yield return new TestCaseData(new[] { 16, 144, 32, 56 }).Returns(8);
                yield return new TestCaseData(new[] { 6, 35 }).Returns(1);
            }
        }

        public static IEnumerable<TestCaseData> GCDFinderTestCases_Zeros
        {
            get
            {
                yield return new TestCaseData(new[] { 0, 0 }).Returns(0);
                yield return new TestCaseData(new[] { 0, 0, 2 }).Returns(2);
                yield return new TestCaseData(new[] { 0, 0, -2 }).Returns(2);
            }
        }

        public static IEnumerable<TestCaseData> GCDFinderTestCases_NegativeNumbers
        {
            get
            {
                yield return new TestCaseData(new[] { -7, 14, 49 }).Returns(7);
                yield return new TestCaseData(new[] { -16, -144, -32, -56 }).Returns(8);
                yield return new TestCaseData(new[] { 6, -35 }).Returns(1);
            }
        }

        public static IEnumerable<TestCaseData> GCDFinderTestCases_InvalidNumberOfParameters
        {
            get
            {
                yield return new TestCaseData(new int[] { });
                yield return new TestCaseData(new[] { 1 });
            }
        }

        #endregion

        #region GetGCDByEuclideanAlgorithm Tests

        [TestCaseSource(nameof(GCDFinderTestCases_PositiveNumbers))]
        public int GetGCDByEuclideanAlgorithmTest_PositiveNumbers(int[] args)
            => GCDFinder.GetGCDByEuclideanAlgorithm(out _, args);

        [TestCaseSource(nameof(GCDFinderTestCases_Zeros))]
        public int GetGCDByEuclideanAlgorithmTest_Zeros(params int[] args)
            => GCDFinder.GetGCDByEuclideanAlgorithm(out _, args);

        [TestCaseSource(nameof(GCDFinderTestCases_NegativeNumbers))]
        public int GetGCDByEuclideanAlgorithmTest_NegativeNumbers(params int[] args)
            => GCDFinder.GetGCDByEuclideanAlgorithm(out _, args);

        [TestCaseSource(nameof(GCDFinderTestCases_InvalidNumberOfParameters))]
        public void GetGCDByEuclideanAlgorithmTest_InvalidNumberOfParameters_ArgumentException(params int[] args)
            => Assert.Throws<ArgumentException>(() => GCDFinder.GetGCDByEuclideanAlgorithm(out _, args));

        [Test]
        public void GetGCDByEuclideanAlgorithmTest_NullArgs_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => GCDFinder.GetGCDByEuclideanAlgorithm(out _, null));

        #endregion

        #region GetGCDBySteinsAlgorithm Tests

        [TestCaseSource(nameof(GCDFinderTestCases_PositiveNumbers))]
        public int GetGCDBySteinsAlgorithmTest_PositiveNumbers(params int[] args)
            => GCDFinder.GetGCDBySteinsAlgorithm(out _, args);

        [TestCaseSource(nameof(GCDFinderTestCases_Zeros))]
        public int GetGCDBySteinsAlgorithmTest_Zeros(params int[] args)
            => GCDFinder.GetGCDBySteinsAlgorithm(out _, args);

        [TestCaseSource(nameof(GCDFinderTestCases_NegativeNumbers))]
        public int GetGCDBySteinsAlgorithmTest_NegativeNumbers(params int[] args)
            => GCDFinder.GetGCDBySteinsAlgorithm(out _, args);

        [TestCaseSource(nameof(GCDFinderTestCases_InvalidNumberOfParameters))]
        public void GetGCDBySteinsAlgorithmTest_InvalidNumberOfParameters_ArgumentException(params int[] args)
            => Assert.Throws<ArgumentException>(() => GCDFinder.GetGCDBySteinsAlgorithm(out _, args));

        [Test]
        public void GetGCDBySteinsAlgorithmTest_NullArgs_ArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => GCDFinder.GetGCDBySteinsAlgorithm(out _, null));

        #endregion
    }
}
