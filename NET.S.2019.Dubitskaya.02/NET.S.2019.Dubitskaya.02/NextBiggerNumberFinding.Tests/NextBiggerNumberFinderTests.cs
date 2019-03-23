using NUnit.Framework;
using System;

namespace NextBiggerNumberFinding.Tests
{
    [TestFixture]
    public class NextBiggerNumberFinderTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        public int FindNextBiggerNumber_NumberExist(int number)
            => NextBiggerNumberFinder.FindNextBiggerNumber(number);


        [TestCase(0, ExpectedResult = -1)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(7654321, ExpectedResult = -1)]
        [TestCase(1111, ExpectedResult = -1)]
        [TestCase(2147483647, ExpectedResult = -1)]
        public int FindNextBiggerNumber_BiggerNotExist(int number)
            => NextBiggerNumberFinder.FindNextBiggerNumber(number);
        
        [Test]
        public void FindNextBiggerNumber_TimeSpanIsValid()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var expectedNumber = 1241233;

            var actualNumber = NextBiggerNumberFinder.FindNextBiggerNumber(1234321, out TimeSpan actualTime);
            timer.Stop();

            Assert.That(actualTime > TimeSpan.Zero && actualTime <= timer.Elapsed);
            Assert.AreEqual(expectedNumber, actualNumber);
        }

        [Test]
        public void FindNextBiggerNumberAndTimeElapsed_TimeSpanIsValid()
        {
            var timer = System.Diagnostics.Stopwatch.StartNew();
            var expectedNumber = 1241233;

            (int number, TimeSpan timeElapsed) actualResult =
                NextBiggerNumberFinder.FindNextBiggerNumberAndTimeElapsed(1234321);
            timer.Stop();

            Assert.That(actualResult.timeElapsed > TimeSpan.Zero &&
                actualResult.timeElapsed <= timer.Elapsed);
            Assert.AreEqual(expectedNumber, actualResult.number);
        }

        [Test]
        public void FindNextBiggerNumber_NegativeNumber_ArgumentException()
            => Assert.Throws<ArgumentException>(() => NextBiggerNumberFinder.FindNextBiggerNumber(-1));
    }
}
