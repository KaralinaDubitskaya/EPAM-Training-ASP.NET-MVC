using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    /// <summary>
    /// Interface that allows to generate an unique account identificator.
    /// </summary>
    public interface IAccountIdGenerator
    {
        /// <summary>
        /// Generates an unique account identificator.
        /// </summary>
        /// <returns>An unique identificator.</returns>
        string Generate();
    }
}
