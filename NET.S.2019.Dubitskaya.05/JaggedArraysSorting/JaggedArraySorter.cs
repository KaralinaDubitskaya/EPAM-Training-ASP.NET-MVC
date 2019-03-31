using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArraysSorting
{
    /// <summary>
    /// Provides methods that sort jagged arrays.
    /// </summary>
    public class JaggedArraySorter
    {
        /// <summary>
        /// Sorts a jugged array rows by sum of elements in ascending order.
        /// </summary>
        /// <param name="array">A jagged array to be sorted</param>
        /// <exception cref="ArgumentNullException">Thrown when the jagged array or one of it's internal arrays is null.</exception>
        /// <exception cref="ArgumentException>">Thrown when the jagged array's or one of it's internal arrays' length is 0.</exception>
        public static void SortBySumUp(int[][] jaggedArray)
            => Sort(jaggedArray, (arr1, arr2) => arr1.Sum() > arr2.Sum());

        /// <summary>
        /// Sorts a jugged array rows by sum of elements in descending order.
        /// </summary>
        /// <param name="array">A jagged array to be sorted</param>
        /// <exception cref="ArgumentNullException">Thrown when the jagged array or one of it's internal arrays is null.</exception>
        /// <exception cref="ArgumentException>">Thrown when the jagged array's or one of it's internal arrays' length is 0.</exception>
        public static void SortBySumDown(int[][] jaggedArray)
            => Sort(jaggedArray, (arr1, arr2) => arr1.Sum() < arr2.Sum());

        /// <summary>
        /// Sorts a jugged array rows by min element in ascending order.
        /// </summary>
        /// <param name="array">A jagged array to be sorted</param>
        /// <exception cref="ArgumentNullException">Thrown when the jagged array or one of it's internal arrays is null.</exception>
        /// <exception cref="ArgumentException>">Thrown when the jagged array's or one of it's internal arrays' length is 0.</exception>
        public static void SortByMinUp(int[][] jaggedArray)
            => Sort(jaggedArray, (arr1, arr2) => arr1.Min() > arr2.Min());

        /// <summary>
        /// Sorts a jugged array rows by min element in descending order.
        /// </summary>
        /// <param name="array">A jagged array to be sorted</param>
        /// <exception cref="ArgumentNullException">Thrown when the jagged array or one of it's internal arrays is null.</exception>
        /// <exception cref="ArgumentException>">Thrown when the jagged array's or one of it's internal arrays' length is 0.</exception>
        public static void SortByMinDown(int[][] jaggedArray)
            => Sort(jaggedArray, (arr1, arr2) => arr1.Min() < arr2.Min());

        /// <summary>
        /// Sorts a jugged array rows by max element in ascending order.
        /// </summary>
        /// <param name="array">A jagged array to be sorted</param>
        /// <exception cref="ArgumentNullException">Thrown when the jagged array or one of it's internal arrays is null.</exception>
        /// <exception cref="ArgumentException>">Thrown when the jagged array's or one of it's internal arrays' length is 0.</exception>
        public static void SortByMaxUp(int[][] jaggedArray)
            => Sort(jaggedArray, (arr1, arr2) => arr1.Max() > arr2.Max());

        /// <summary>
        /// Sorts a jugged array rows by max element in descending order.
        /// </summary>
        /// <param name="array">A jagged array to be sorted</param>
        /// <exception cref="ArgumentNullException">Thrown when the jagged array or one of it's internal arrays is null.</exception>
        /// <exception cref="ArgumentException>">Thrown when the jagged array's or one of it's internal arrays' length is 0.</exception>
        public static void SortByMaxDown(int[][] jaggedArray)
            => Sort(jaggedArray, (arr1, arr2) => arr1.Max() < arr2.Max());

        /// <summary>
        /// Sorts a jugged array by rows according to specified comparator.
        /// </summary>
        /// <param name="array">The array to be sorted</param>
        /// <param name="NeedToBeSwapped">Function to compare rows.</param>
        /// <exception cref="ArgumentNullException">Thrown when the jagged array or one of it's internal arrays is null.</exception>
        /// <exception cref="ArgumentException>">Thrown when the jagged array's or one of it's internal arrays' length is 0.</exception>
        private static void Sort(int[][] array, Func<int[], int[], bool> needToBeSwapped)
        {
            CheckArray(array);

            for (int j = 0; j < array.GetLength(0); j++)
            {
                for (int i = 0; i < array.GetLength(0) - j - 1; i++)
                {
                    if (needToBeSwapped(array[i], array[i + 1]))
                    {
                        Swap(ref array[i], ref array[i + 1]);
                    }
                }
            }
        }

        /// <summary>
        /// Swap two arrays.
        /// </summary>
        /// <param name="arr1">An integer array to be swapped.</param>
        /// <param name="arr2">An integer array to be swapped.</param>
        private static void Swap(ref int[] arr1, ref int[] arr2)
        {
            int[] tempArr = arr1;
            arr1 = arr2;
            arr2 = tempArr;
        }

        /// <summary>
        /// Checks if the array is valid.
        /// </summary>
        /// <param name="arr">The array to be checked.</param>
        /// <exception cref="ArgumentNullException">Thrown when the jagged array or one of it's internal arrays is null.</exception>
        /// <exception cref="ArgumentException>">Thrown when the jagged array's or one of it's internal arrays' length is 0.</exception>
        private static void CheckArray(int[][] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null)
                {
                    throw new ArgumentNullException();
                }

                if (arr[i].Length == 0)
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}
