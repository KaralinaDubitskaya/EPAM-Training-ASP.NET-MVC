using System;
using System.Globalization;
using BankEntites.BLL.Interfaces;

namespace BankEntites.BLL.Services
{
    /// <summary>
    /// Represents IBAN id generator abstraction and provides it's method
    /// </summary>
    public class IdGeneratorIBAN : IidGenerator
    {
        private static Random rand = new Random();

        /// <summary>
        /// Generates new id
        /// </summary>
        /// <returns>string</returns>
        public string Generate()
        {
            string result = string.Empty;
            result += CultureInfo.CurrentCulture.EnglishName.Substring(0, 2).ToUpper();
            int startLen = result.Length;
            for (int i = 0; i < 18 - startLen; i++)
            {
                result += rand.Next(0, 10).ToString();
            }

            return result;
        }
    }
}
