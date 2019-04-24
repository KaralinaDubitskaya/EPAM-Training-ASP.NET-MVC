using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearchLib
{
    /// <summary>
    /// Provides methods that find index of the element in the array
    /// </summary>
    public class Searcher
    {
        /// <summary>
        /// Method, that invokes correct index finding algorithm and returns it's result
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="value"></param>
        /// <returns>string</returns>
        public static string SearchForIndex<T>(IEnumerable<T> enumerable, T value) 
        {
            if (enumerable == null || value == null)
                throw new ArgumentNullException();

            List<T> localList = enumerable.ToList<T>();
            if (!(typeof(IComparable).IsAssignableFrom(typeof(T))))
                throw new ArgumentException("Argument type must implement IComparable interface");

            if (IsSorter(localList, (value1, value2) => { return ((IComparable<T>)value1).CompareTo(value2); }))
                return RecursiveSearch(localList, value, 0, localList.Count, (value1, value2) => { return ((IComparable<T>)value1).CompareTo(value2); });
            else
            {
                if (IsSorter(localList, (value1, value2) => { return ((IComparable<T>)value2).CompareTo(value1); }))
                {
                    return RecursiveSearch(localList, value, 0, localList.Count, (value1, value2) => { return ((IComparable<T>)value2).CompareTo(value1); });
                }
                else
                    throw new ArgumentException("Enumerable sequence must me sorted");
            }
        }        
                
        /// <summary>
        /// Recursive function that returns index of the element in the array in string form
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="value"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="Comparer"></param>
        /// <returns>string</returns>
        private static string RecursiveSearch<T>(List<T> list, T value, int left, int right, Comparison<T> Comparer)
        {
            if (left == right)
                return ("No such value in the array");

            int middle = left + (right - left) / 2;
            if (((IComparable<T>)list[middle]).CompareTo(value) == 0)
            {
                while (((IComparable<T>)list[middle - 1]).CompareTo(value) == 0)
                {
                    middle -= 1;
                    if (middle == left)
                        break;
                }
                return string.Format("Index of the element is {0}", middle);
            }

            if (Comparer(list[middle], value) < 0)
                return RecursiveSearch(list, value, left, middle, Comparer);
            else
                return RecursiveSearch(list, value, middle + 1, right, Comparer);
        }
        

        /// <summary>
        /// Checks if the array is sorted in any direction
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="Comparer"></param>
        /// <returns>bool</returns>
        private static bool IsSorter<T>(List<T> list, Comparison<T> Comparer)
        {
            for (int i = 1; i < list.Count; i++)
            {
                if (Comparer(list[i - 1], list[i]) < 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}