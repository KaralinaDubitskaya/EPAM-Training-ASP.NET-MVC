using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NumberInserting.Tests
{
    [TestClass]
    public class NumberInserterTests
    {
        [TestMethod]
        public void InsertNumber_InsertSameBit()
        {
            int numberSource = 15;
            int numberIn = 15;
            int startIndex = 0;
            int endIndex = 0;

            int expected = 15;

            int actual = NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_InsertAnotherBit()
        {
            int numberSource = 8;
            int numberIn = 15;
            int startIndex = 0;
            int endIndex = 0;

            int expected = 9;

            int actual = NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_InsertSomeBits()
        {
            int numberSource = 8;
            int numberIn = 15;
            int startIndex = 3;
            int endIndex = 8;

            int expected = 120;

            int actual = NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertNumber_InsertAllBits()
        {
            int numberSource = 8;
            int numberIn = 15;
            int startIndex = 0;
            int endIndex = 31;

            int expected = 15;

            int actual = NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_NegativeStartingIndex_ArgumentException()
        {
            int numberSource = 8;
            int numberIn = 8;
            int startIndex = -1;
            int endIndex = 2;
            NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_NegativeEndingIndex_ArgumentException()
        {
            int numberSource = 8;
            int numberIn = 8;
            int startIndex = 2;
            int endIndex = -3;
            NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InsertNumber_StartingIndexGreaterEnding_ArgumentException()
        {
            int numberSource = 8;
            int numberIn = 8;
            int startIndex = 7;
            int endIndex = 2;
            NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertNumber_TooLargeStartingIndex_IndexOutOfRangeException()
        {
            int numberSource = 8;

            int numberIn = 8;
            int startIndex = 32;
            int endIndex = 33;
            NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertNumber_TooLargeEndingIndex_IndexOutOfRangeException()
        {
            int numberSource = 8;
            int numberIn = 8;
            int startIndex = 3;
            int endIndex = 32;
            NumberInserter.InsertNumber(numberSource, numberIn, startIndex, endIndex);
        }
    }
}
