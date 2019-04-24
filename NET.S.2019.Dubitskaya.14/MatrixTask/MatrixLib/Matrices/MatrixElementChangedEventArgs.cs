using System;

namespace MatrixLib.Matrices
{
    /// <summary>
    /// Represents argument abstraction for matrix event
    /// </summary>
    public class MatrixElementChangedEventArgs : EventArgs
    {
        public readonly int i;
        public readonly int j;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns>instance</returns>
        public MatrixElementChangedEventArgs(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }
}
