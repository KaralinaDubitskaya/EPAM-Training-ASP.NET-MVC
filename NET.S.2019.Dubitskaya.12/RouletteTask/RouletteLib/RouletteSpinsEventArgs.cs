using System;

namespace RouletteLib
{
    /// <summary>
    /// Represents argument abstraction for roulette event
    /// </summary>
    public class RouletteSpinsEventArgs : EventArgs
    {
        private int _winningNum;

        public int WinningNum
        {
            get
            {
                return _winningNum;
            }
        }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>instance</returns>
        public RouletteSpinsEventArgs(int value)
        {
            _winningNum = value;
        }
    }
}
