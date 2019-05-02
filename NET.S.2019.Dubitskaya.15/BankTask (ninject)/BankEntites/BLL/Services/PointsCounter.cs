using System;
using BankEntites.BLL.Interfaces;

namespace BankEntites.BLL.Services
{
    /// <summary>
    /// Represents points counter abstraction and provides it's method
    /// </summary>
    public class PointsCounter : IPointsCounter
    {
        /// <summary>
        /// Calculates new points value
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="amount"></param>
        /// <param name="mult"></param>
        /// <param name="currPoints"></param>
        /// <returns>int</returns>
        public int CountPoints(decimal balance, decimal amount, int mult, int currPoints)
        {
            if (balance < 0)
                return 0;
            else
            {
                return (currPoints += (int)amount / mult);
            }
        }
    }
}
