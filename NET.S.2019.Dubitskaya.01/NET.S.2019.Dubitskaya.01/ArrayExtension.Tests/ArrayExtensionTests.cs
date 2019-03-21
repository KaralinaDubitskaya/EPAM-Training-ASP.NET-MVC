using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArrayExtension.Tests
{
    [TestClass]
    public class ArrayExtensionTests
    {
        private bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                if (array[i] > array[i + 1])
                    return false;

            return true;
        }

        #region MergeSort Tests

        [TestMethod]
        public void MergeSortEmptyArrayTest()
        {
            int[] testArray = { };
            ArrayExtension.MergeSort(testArray);
            bool expected = IsSorted(testArray);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void MergeSortSortedArrayTest()
        {
            int[] testArray = { 1, 2, 3, 17, 28, 39, 111, 111 };
            ArrayExtension.MergeSort(testArray);
            bool expected = IsSorted(testArray);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void MergeSortReverceSortedArrayTest()
        {
            int[] testArray = { 123, 122, 80, 25, 14, 3, 1 };
            ArrayExtension.MergeSort(testArray);
            bool expected = IsSorted(testArray);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void MergeSortUnsortedArrayTest()
        {
            int[] testArray = { -4, 2, 7, 4, 9, 11, 0, 2, 1 };
            ArrayExtension.MergeSort(testArray);
            bool expected = IsSorted(testArray);
            Assert.IsTrue(expected);
        }

        #endregion

        #region QuickSort Tests

        [TestMethod]
        public void QuickSortEmptyArrayTest()
        {
            int[] testArray = { };
            ArrayExtension.QuickSort(testArray);
            bool expected = IsSorted(testArray);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void QuickSortSortedArrayTest()
        {
            int[] testArray = { 1, 4, 5, 7, 8, 9, 11, 11 };
            ArrayExtension.QuickSort(testArray);
            bool expected = IsSorted(testArray);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void QuickSortReverceSortedArrayTest()
        {
            int[] testArray = { 14, 12, 8, 5, 4, 3, 1 };
            ArrayExtension.QuickSort(testArray);
            bool expected = IsSorted(testArray);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void QuickSortUnsortedArrayTest()
        {
            int[] testArray = { -4, 2, 7, 4, 9, 11, 0, 2, 1 };
            ArrayExtension.QuickSort(testArray);
            bool expected = IsSorted(testArray);
            Assert.IsTrue(expected);
        }

        #endregion
    }
}
