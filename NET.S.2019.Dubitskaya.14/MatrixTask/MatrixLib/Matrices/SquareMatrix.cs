using System;

namespace MatrixLib.Matrices
{
    /// <summary>
    /// Represents square matrix abstraction and provides it's methods
    /// </summary>
    public class SquareMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the SquareMatrix class.
        /// </summary>
        /// <param name="baseArray"></param>
        /// <returns>instance</returns>
        public SquareMatrix(T[,] baseArray) : base(baseArray)
        {
        }

        /// <summary>
        /// Replaces element in the matrix
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="item"></param>
        public override void NewElement(int i, int j, T item)
        {
            if (elements.GetLength(0) <= i || elements.GetLength(1) <= j)
                throw new ArgumentOutOfRangeException();

            elements[i, j] = item;
            OnMatrixElementChanged(i, j);
        }

        /// <summary>
        /// Validates array for square matrix type
        /// </summary>
        /// <param name="array"></param>
        /// <returns>bool</returns>
        protected override bool ValidateArray(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
                return false;

            return true;
        }
    }
}
