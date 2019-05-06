using System;
using BankEntites.BLL.Interfaces;

namespace BankEntites.BLL.Services
{
    /// <summary>
    /// Represents BIC id generator abstraction and provides it's method
    /// </summary>
    public class IdGeneratorBIC : IidGenerator
    {
        private static Random rand = new Random();
        private static string sourceStr = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Generates new id
        /// </summary>
        /// <returns>string</returns>
        public string Generate()
        {
            string result = string.Empty;
            for (int i = 0; i < 32; i++)
            {
                result += sourceStr[rand.Next(0, sourceStr.Length - 1)];
            }

            return result;
        }
    }
}
