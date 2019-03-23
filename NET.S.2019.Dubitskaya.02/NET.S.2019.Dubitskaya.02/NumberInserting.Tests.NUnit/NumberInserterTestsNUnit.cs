using System;
using NUnit.Framework;

namespace NumberInserting.Tests.NUnit
{
    [TestFixture]
    public class NumberInserterTestsNUnit
    {
        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        public int InsertNumber_InsertOneBit(int numberSource, int numberIn, int startIndex, int endIndex)
            => NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);
        
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int InsertNumber_InsertSomeBits(int numberSource, int numberIn, int startIndex, int endIndex)
            => NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);

        [TestCase(8, 15, 0, 31, ExpectedResult = 15)]
        public int InsertNumber_InsertAllBits(int numberSource, int numberIn, int startIndex, int endIndex)
            => NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);

        [Test]
        public void InsertNumber_NegativeStartingIndex_ArgumentException()
            => Assert.Throws<ArgumentException>(() => NumberInserter.InsertNumber(8, 8, -1, 2));

        [Test]
        public void InsertNumber_NegativeEndingIndex_ArgumentException()
                    => Assert.Throws<ArgumentException>(() => NumberInserter.InsertNumber(8, 8, 2, -3));

        [Test]
        public void InsertNumber_StartingIndexGreaterEnding_ArgumentException()
                   => Assert.Throws<ArgumentException>(() => NumberInserter.InsertNumber(8, 8, 7, 2));

        [Test]
        public void InsertNumber_TooLargeStartingIndex_IndexOutOfRangeException()
                   => Assert.Throws<IndexOutOfRangeException>(() => NumberInserter.InsertNumber(8, 8, 32, 32));

        [Test]
        public void InsertNumber_TooLargeEndingIndex_IndexOutOfRangeException()
                  => Assert.Throws<IndexOutOfRangeException>(() => NumberInserter.InsertNumber(8, 8, 1, 32));
    }
}
