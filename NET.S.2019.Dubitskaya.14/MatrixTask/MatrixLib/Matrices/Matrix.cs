using System;

namespace MatrixLib.Matrices
{
    /// <summary>
    /// Represents basis for matrixv bstraction and provides it's methods
    /// </summary>
    public abstract class Matrix<T> where T : struct, IComparable<T>
    {
        protected T[,] elements;
        public event EventHandler<MatrixElementChangedEventArgs> MatrixElementChanged;

        /// <summary>
        /// Represents access to the base array's length
        /// </summary>
        public int MatrixSize
        {
            get
            {
                if (elements == null)
                    throw new NullReferenceException();

                return elements.Length;
            }
        }

        /// <summary>
        /// Represents access to the base array
        /// </summary>
        internal T[,] GetBase
        {
            get
            {
                if (elements == null)
                    throw new NullReferenceException();

                return elements;
            }
        }

        /// <summary>
        /// Represents access to matrix's array by index
        /// </summary>
        public T this[int i, int j]
        {
            get
            {
                if (elements == null)
                    throw new NullReferenceException();

                if (elements.GetLength(0) <= i || elements.GetLength(1) <= j)
                    throw new ArgumentOutOfRangeException();

                return elements[i, j];
            }
        }

        /// <summary>
        /// Initializes basis for a new instance of the Matrix class.
        /// </summary>
        /// <param name="accOwner"></param>
        /// <returns>instance</returns>
        public Matrix(T[,] baseArray)
        {
            if (baseArray == null)
                throw new ArgumentNullException();

            if (!(ValidateArray(baseArray)))
                throw new ArgumentException("Invalid parameter");

            elements = baseArray.Clone() as T[,];
        }

        /// <summary>
        /// Replaces element in the matrix
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="item"></param>
        public abstract void NewElement(int i, int j, T item);

        /// <summary>
        /// Validates array for current matrix type
        /// </summary>
        /// <param name="array"></param>
        /// <returns>bool</returns>
        protected abstract bool ValidateArray(T[,] array);

        /// <summary>
        /// Method, that invokes the event
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        protected void OnMatrixElementChanged(int i, int j)
        {
            MatrixElementChanged?.Invoke(this, new MatrixElementChangedEventArgs(i, j));
        }
    }
}
