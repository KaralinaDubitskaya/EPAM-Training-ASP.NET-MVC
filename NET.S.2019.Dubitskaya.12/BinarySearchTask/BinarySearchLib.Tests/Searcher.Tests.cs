using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchLib.Tests
{
    [TestFixture]
    public class SearcherTests
    {
        private object[] _sourceLists = { new object[] {new List<char> { 'a', 'b', 'c', 'd', 'e' } },
                                          new object[] {new List<char> { 'e', 'd', 'c', 'b', 'a' } }};

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 4, ExpectedResult = "Index of the element is 3")]
        [TestCase(new int[] { 1, 4, 4, 4, 5, 6, 7, 8 }, 4, ExpectedResult = "Index of the element is 1")]
        [TestCase(new int[] { 1, 2, 3, 5, 6, 7, 8 }, 4, ExpectedResult = "No such value in the array")]
        public string SearchForIndex_CorrectParamsIntIncreasingArr_ExpectedResult(int[] arr, int value)
        {
            return Searcher.SearchForIndex(arr, value);
        }

        [TestCase(new string[] { "oo", "ooo", "oooo", "ooooo", "oooooo" }, "ooooo", ExpectedResult = "Index of the element is 3")]
        public string SearchForIndex_CorrectParamsStringIncreasingArr_ExpectedResult(string[] arr, string value)
        {
            return Searcher.SearchForIndex<string>(arr, value);
        }

        [Test]
        public void SearchForIndex_CorrectParamsListIncreasingArr_ExpectedResult()
        {
            List<char> list = new List<char> { 'a', 'b', 'c', 'd', 'e' };
            string result = Searcher.SearchForIndex<char>(list, 'c');
            string expected = "Index of the element is 2";

            Assert.AreEqual(expected, result);
        }

        [TestCase(new int[] { 8, 7, 6, 5, 4, 3, 2, 1 }, 4, ExpectedResult = "Index of the element is 4")]
        [TestCase(new int[] { 8, 7, 6, 4, 4, 3, 2, 1 }, 4, ExpectedResult = "Index of the element is 3")]
        [TestCase(new int[] { 8, 7, 6, 5, 3, 2, 1 }, 4, ExpectedResult = "No such value in the array")]
        public string SearchForIndex_CorrectParamsDecreasingArr_ExpectedResult(int[] arr, int value)
        {
            return Searcher.SearchForIndex(arr, value);
        }

        [TestCase(new int[] { 1, 2, 3, 5, 10, 7, 8 }, 4)]
        public void SearchForIndex_IncorrectParamsUnsorted_ThrowsExeption(int[] arr, int value)
        {
            Assert.Throws<ArgumentException>(() => Searcher.SearchForIndex(arr, value));
        }

        [TestCase(new string[] { "oo", "ooo", "oooo", "ooooo", "oooooo" }, null)]
        public void SearchForIndex_IncorrectParamsNullParam_ThrowsExeption(string[] arr, string value)
        {
            Assert.Throws<ArgumentNullException>(() => Searcher.SearchForIndex(arr, value));
        }
    }
}
