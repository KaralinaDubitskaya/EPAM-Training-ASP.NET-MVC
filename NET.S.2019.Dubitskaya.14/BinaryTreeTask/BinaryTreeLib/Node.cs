using System;

namespace BinaryTreeLib
{
    /// <summary>
    /// Represents tree node abstraction
    /// </summary>
    internal sealed class Node<T>
    {
        internal Node<T> left;
        internal Node<T> rigth;
        internal T value;

        /// <summary>
        /// Initializes a new instance of the node class.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>instance</returns>
        internal Node(T value)
        {
            this.value = value;
            left = null;
            rigth = null;
        }
    }
}
