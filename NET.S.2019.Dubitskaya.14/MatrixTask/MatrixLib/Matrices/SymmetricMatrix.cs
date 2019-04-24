using System;

namespace MatrixLib.Matrices
{
    /// <summary>
    /// Represents symmetric matrix abstraction and provides it's methods
    /// </summary>
    public class SymmetricMatrix<T> : Matrix<T> where T : struct, IComparable<T>
    {
        /// <summary>
        /// Initializes a new instance of the SymmetricMatrix class.
        /// </summary>
        /// <param name="baseArray"></param>
        /// <returns>instance</returns>
        public SymmetricMatrix(T[,] baseArray) : base(baseArray)
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
            elements[j, i] = item;
            OnMatrixElementChanged(i, j);
            if (i != j)
                OnMatrixElementChanged(j, i);
        }

        /// <summary>
        /// Validates array for symmetric matrix type
        /// </summary>
        /// <param name="array"></param>
        /// <returns>bool</returns>
        protected override bool ValidateArray(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
                return false;

            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < i; j++)
                    if (array[i, j].CompareTo(array[j, i]) != 0)
                        return false;

            return true;
        }
    } 
}
