using System;
using MatrixLib.Matrices;

namespace MatrixLib
{
    /// <summary>
    /// Provides method to sum two matrices
    /// </summary>
    public static class MatrixSummator
    {
        /// <summary>
        /// Sums two matrices and return new one as a result
        /// </summary>
        /// <param name="firstMatrix"></param>
        /// <param name="secondMatrix"></param>
        /// <returns>Matrix</returns>
        public static Matrix<T> SumMatrices<T>(this Matrix<T> firstMatrix, Matrix<T> secondMatrix) where T : struct, IComparable<T>
        {
            if (firstMatrix == null || secondMatrix == null)
                throw new ArgumentNullException();

            T[,] destMatrixBase;
            Matrix<T> smallerMatrix;
            if (firstMatrix.MatrixSize > secondMatrix.MatrixSize)
            {
                destMatrixBase = firstMatrix.GetBase.Clone() as T[,];
                smallerMatrix = secondMatrix;
            }
            else
            {
                destMatrixBase = secondMatrix.GetBase.Clone() as T[,];
                smallerMatrix = firstMatrix;
            }

            int smallerMatrixLength = smallerMatrix.GetBase.GetLength(0);
            for (int i = 0; i < smallerMatrixLength; i++)
                for (int j = 0; j < smallerMatrixLength; j++)
                    destMatrixBase[i, j] += (dynamic)smallerMatrix[i, j];

            if (firstMatrix.GetType() == secondMatrix.GetType())
                return (Matrix<T>)Activator.CreateInstance(firstMatrix.GetType(), destMatrixBase);
            else
                return new SquareMatrix<T>(destMatrixBase);
        }
    }
}
