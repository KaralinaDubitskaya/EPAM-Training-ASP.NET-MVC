using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExtension
{
    public static class ArrayExtension
    {
        #region QuickSort
        /// <summary>
        /// Recursive quick sort algorithm realization for an integer array.
        /// </summary>
        /// <param name="array">An array to be sorted.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array is null.</exception>
        public static void QuickSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            // Array is already sorted.
            if (array.Length <= 1)
            {
                return;
            }

            QuickSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Recursive quick sort algorithm realization for the part of an integer array.
        /// </summary>
        /// <param name="array">An array to be sorted.</param>
        /// <param name="left">A start index of the subarray to be sorted.</param>
        /// <param name="right">An end index of the subarray to be sorted.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array is null.</exception>
        /// <exception cref="ArgumentException">Thrown if left or right index is negative number.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown if the right index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if the left index is greater than the right.</exception>
        public static void QuickSort(int[] array, int left, int right)
        {
            CheckArrayRange(array, left, right);
            SortArrayByQuickSort(array, left, right);
        }

        /// <summary>
        /// Recursive quick sort. Warning: The parameters aren't checked.
        /// </summary>
        /// <param name="array">An array to be sorted.</param>
        /// <param name="left">A start index of the subarray to be sorted.</param>
        /// <param name="right">An end index of the subarray to be sorted.</param>
        private static void SortArrayByQuickSort(int[] array, int left, int right)
        {
            if (left >= right)
            {
                return;
            }

            int partition = Partition(array, left, right);
            SortArrayByQuickSort(array, left, partition);
            SortArrayByQuickSort(array, partition + 1, right);
        }

        /// <summary>
        /// Reorder the array so that all elements with values less than the pivot
        /// come before the pivot, while all elements with values equal or greater 
        /// than the pivot come after it. 
        /// </summary>
        /// <param name="array">An array to be sorted.</param>
        /// <param name="left">A start index of the subarray to be reordered.</param>
        /// <param name="right">An end index of the subarray to be reordered.</param>
        /// <returns>Index of the pivot.</returns>
        private static int Partition(int[] array, int left, int right)
        {
            int i = left;
            int j = right;

            int pivot = GetPivotIndex(array, left, right);

            while (i <= j)
            {
                // Find element that is left to the pivot and is larger than it. 
                while (array[i] < pivot) { i++; }

                // Find element that is right to the pivot and is smaller than it. 
                while (array[j] > pivot) { j--; }

                if (i >= j) { break; }
                Swap(ref array[i], ref array[j]);

                i++;
                j--;
            }

            return j;
        }

        /// <summary>
        /// "Median of three rule". For more info, https://en.wikipedia.org/wiki/Quicksort#Choice_of_pivot.
        /// </summary>
        /// <param name="array">An array to be sorted.</param>
        /// <param name="left">A start index of the subarray to be reordered.</param>
        /// <param name="right">An end index of the subarray to be reordered.</param>
        /// <returns>Indxe of the pivot.</returns>
        private static int GetPivotIndex(int[] array, int left, int right)
        {
            int median = (left + right) / 2;

            if (array[median] < array[left])
            {
                Swap(ref array[left], ref array[median]);
            }

            if (array[right] < array[left])
            {
                Swap(ref array[left], ref array[right]);
            }

            if (array[median] < array[right])
            {
                Swap(ref array[median], ref array[right]);
            }

            return right;
        }

        /// <summary>
        /// Swap two elements.
        /// </summary>
        /// <param name="a">The first element to be swapped.</param>
        /// <param name="b">The second element to be swapped.</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        #endregion

        #region MergeSort
        /// <summary>
        /// A merge sort realization for an integer array.
        /// </summary>
        /// <param name="array">An array to be sorted.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array is null.</exception>
        public static void MergeSort(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            // Array is already sorted.
            if (array.Length <= 1)
            {
                return;
            }

            MergeSort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Merge sort algorithm realization for the part of an integer array.
        /// </summary>
        /// <param name="array">An array to be sorted.</param>
        /// <param name="left">A start index of the subarray to be sorted.</param>
        /// <param name="right">An end index of the subarray to be sorted.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array is null.</exception>
        /// <exception cref="ArgumentException">Thrown if left or right index is negative number.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown if the right index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if the left index is greater than the right.</exception>
        public static void MergeSort(int[] array, int left, int right)
        {
            CheckArrayRange(array, left, right);
            SortArrayByMergeSort(array, left, right);
        }

        /// <summary>
        /// Merge sort. Warning: The parameters aren't checked.
        /// </summary>
        /// <param name="array">An array to be sorted.</param>
        /// <param name="left">A start index of the subarray to be sorted.</param>
        /// <param name="right">An end index of the subarray to be sorted.</param>
        private static void SortArrayByMergeSort(int[] array, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            int middle = (left + right + 1) / 2;
            MergeSort(array, left, middle - 1);
            MergeSort(array, middle, right);
            Merge(array, left, middle, right);
        }

        /// <summary>
        /// Merge two sorted subarrays of the array.
        /// </summary>
        /// <param name="array">Array with two sorted subarrays to be merged.</param>
		/// <param name="left">The star index of the first subarray.</param>
		/// <param name="middle">The start index of the second subarray.</param>
		/// <param name="right">The end index of the second subarray.</param>
		public static void Merge(int[] array, int left, int middle, int right)
        {
            // Temporary result array for the merged subarrays.
            var result = new int[right - left + 1];

            // Index for the first subarray.
            int index1 = 0;
            // Index for the second subarray.
            int index2 = 0;
            // Index for the result array.
            int indexResult = 0;
            
            // Until one of the subarrays is fully iterarted.
            while (index1 + left < middle && index2 + middle <= right)
            {
                // Get min element from the subarrays and write it to the result array.
                if (array[index1 + left] < array[middle + index2])
                {
                    result[indexResult] = array[index1 + left];
                    index1++;
                }
                else
                {
                    result[indexResult] = array[middle + index2];
                    index2++;
                }

                indexResult++;
            }

            // If some elements left in the first subarray, add them to the result array.
            while (index1 + left < middle)
            {
                result[indexResult] = array[index1 + left];
                indexResult++;
                index1++;
            }

            // If some elements left in the second subarray, add them to the result array.
            while (middle + index2 <= right)
            {
                result[indexResult] = array[middle + index2];
                indexResult++;
                index2++;
            }

            // Copy sorted elements to the source array.
            Array.Copy(result, 0, array, left, result.Length);
        }
        #endregion

        #region Validation 
        /// <summary>
        /// Validate an array range.
        /// </summary>
        /// <param name="array">An array to be validated.</param>
        /// <param name="left">A start index of the subarray.</param>
        /// <param name="right">An end index of the subarray.</param>
        /// <exception cref="ArgumentNullException">Thrown if the array is null.</exception>
        /// <exception cref="ArgumentException">Thrown if left or right index is negative number.</exception>
        /// <exception cref="IndexOutOfRangeException">Thrown if the right index is out of range.</exception>
        /// <exception cref="ArgumentException">Thrown if the left index is greater than the right.</exception>
        private static void CheckArrayRange(int[] array, int left, int right)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (left < 0 || right < 0)
            {
                throw new ArgumentException("Left and right indexes should be positive numbers.");
            }

            if (right > array.Length)
            {
                throw new IndexOutOfRangeException("Invalid right index.");
            }

            if (left > right)
            {
                throw new ArgumentException("Left index cannot be greater than right.");
            }
        }
        #endregion
    }
} 