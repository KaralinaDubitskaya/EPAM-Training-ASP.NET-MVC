using System;

namespace MatrixLib.Matrices
{
    /// <summary>
    /// Represents diagonal matrix abstraction and provides it's methods
    /// </summary>
    public class DiagonalMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the DigonalMatrix class.
        /// </summary>
        /// <param name="baseArray"></param>
        /// <returns>instance</returns>
        public DiagonalMatrix(T[,] baseArray) : base(baseArray)
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

            if (i != j)
                throw new ArgumentException("You can add elements only on matrix's diagonal");

            elements[i, j] = item;
            OnMatrixElementChanged(i, j);
        }

        /// <summary>
        /// Validates array for diagonal matrix type
        /// </summary>
        /// <param name="array"></param>
        /// <returns>bool</returns>
        protected override bool ValidateArray(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
                return false;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (i != j && (array[i, j].CompareTo(default(T)) != 0))
                        return false;

            return true;
        }
    } 
}
