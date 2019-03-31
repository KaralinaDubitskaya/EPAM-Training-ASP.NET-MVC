using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraysSorting.Tests
{
    [TestFixture]
    public class JaggedArraysSorterTests
    {
        private readonly int[][] testArray =
            {
            new int[] { 1, 2 },
            new int[] { 9, 7, 4, 6 },
            new int[] { 8, 9, 10 },
            new int[] { 3, 4, 5, 6, 7 },
            new int[] { 1 }
        };

        [Test]
        public void SortBySumUp_CorrectParam()
        {
            int[][] actual = new int[testArray.Length][];
            testArray.CopyTo(actual, 0);

            int[][] expected = new int[5][];
            expected[0] = new int[] { 1 };
            expected[1] = new int[2] { 1, 2 };
            expected[2] = new int[] { 3, 4, 5, 6, 7 };
            expected[3] = new int[] { 9, 7, 4, 6 };
            expected[4] = new int[3] { 8, 9, 10 };

            JaggedArraySorter.SortBySumUp(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void SortBySumDown_CorrectParam()
        {
            int[][] actual = new int[testArray.Length][];
            testArray.CopyTo(actual, 0);

            int[][] expected = new int[5][];
            expected[0] = new int[] { 8, 9, 10 };
            expected[1] = new int[] { 9, 7, 4, 6 };
            expected[2] = new int[] { 3, 4, 5, 6, 7 };
            expected[3] = new int[] { 1, 2 };
            expected[4] = new int[] { 1 };

            JaggedArraySorter.SortBySumDown(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        public void SortBySum_NullAsParam_ArgumentNullExeption(int[][] array)
        {
            Assert.Throws<ArgumentNullException>(() => JaggedArraySorter.SortBySumUp(array));
        }

        [Test]
        public void SortBySum_IncorrectParam_ArgumentNullException()
        {
            int[][] array = new int[5][];
            array[0] = new int[2] { 1, 2 };
            array[1] = new int[] { 9, 7, 4, 6 };
            array[2] = new int[3] { 8, 9, 10 };
            array[3] = new int[] { 3, 4, 5, 6, 7 };

            Assert.Throws<ArgumentNullException>(() => JaggedArraySorter.SortBySumUp(array));
        }

        [Test]
        public void SortByMinUp_CorrectParam()
        {
            int[][] actual = new int[testArray.Length][];
            testArray.CopyTo(actual, 0);

            int[][] expected = new int[5][];
            expected[0] = new int[] { 1, 2 };
            expected[1] = new int[] { 1 };
            expected[2] = new int[] { 3, 4, 5, 6, 7 };
            expected[3] = new int[] { 9, 7, 4, 6 };
            expected[4] = new int[3] { 8, 9, 10 };

            JaggedArraySorter.SortByMinUp(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByMinDown_CorrectParam()
        {
            int[][] actual = new int[testArray.Length][];
            testArray.CopyTo(actual, 0);

            int[][] expected = new int[5][];
            expected[0] = new int[] { 8, 9, 10 };
            expected[1] = new int[] { 9, 7, 4, 6 };
            expected[2] = new int[] { 3, 4, 5, 6, 7 };
            expected[3] = new int[] { 1, 2 };
            expected[4] = new int[] { 1 };

            JaggedArraySorter.SortByMinDown(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        public void SortByMin_NullAsParam_ArgumentNullExeption(int[][] array)
        {
            Assert.Throws<ArgumentNullException>(() => JaggedArraySorter.SortByMinUp(array));
        }

        [Test]
        public void SortByMin_IncorrectParam()
        {
            int[][] array = new int[5][];
            array[0] = new int[2] { 1, 2 };
            array[1] = new int[] { 9, 7, 4, 6 };
            array[2] = new int[3] { 8, 9, 10 };
            array[3] = new int[] { 3, 4, 5, 6, 7 };

            Assert.Throws<ArgumentNullException>(() => JaggedArraySorter.SortByMinUp(array));
        }

        [Test]
        public void SortByMaxUp_CorrectParam()
        {
            int[][] actual = new int[testArray.Length][];
            testArray.CopyTo(actual, 0);

            int[][] expected = new int[5][];
            expected[0] = new int[] { 1 };
            expected[1] = new int[] { 1, 2 };
            expected[2] = new int[] { 3, 4, 5, 6, 7 };
            expected[3] = new int[] { 9, 7, 4, 6 };
            expected[4] = new int[3] { 8, 9, 10 };

            JaggedArraySorter.SortByMaxUp(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void SortByMaxDown_CorrectParam()
        {
            int[][] actual = new int[testArray.Length][];
            testArray.CopyTo(actual, 0);

            int[][] expected = new int[5][];
            expected[0] = new int[] { 8, 9, 10 };
            expected[1] = new int[] { 9, 7, 4, 6 };
            expected[2] = new int[] { 3, 4, 5, 6, 7 };
            expected[3] = new int[] { 1, 2 };
            expected[4] = new int[] { 1 };

            JaggedArraySorter.SortByMaxDown(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCase(null)]
        public void SortByMax_NullAsParam_ArgumentNullExeption(int[][] array)
        {
            Assert.Throws<ArgumentNullException>(() => JaggedArraySorter.SortByMaxUp(array));
        }

        [Test]
        public void SortByMax_IncorrectParam()
        {
            int[][] array = new int[5][];
            array[0] = new int[2] { 1, 2 };
            array[1] = new int[] { 9, 7, 4, 6 };
            array[2] = new int[3] { 8, 9, 10 };
            array[3] = new int[] { 3, 4, 5, 6, 7 };

            Assert.Throws<ArgumentNullException>(() => JaggedArraySorter.SortByMaxUp(array));
        }
    }
}
