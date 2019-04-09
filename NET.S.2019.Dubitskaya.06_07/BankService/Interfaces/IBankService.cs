using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Interfaces
{
    /// <summary>
    /// Provides operations with bank accounts.
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Open a new bank account.
        /// </summary>
        /// <param name="generator">Generates the account id.</param>
        /// <param name="holder">Holder of the account.</param>
        /// <param name="accountType">Type of the account.</param>
        /// <returns>Id of the created account.</returns>
        string OpenAccount(IAccountIdGenerator generator, AccountHolder holder, string accountType);

        /// <summary>
        /// Close an account.
        /// </summary>
        /// <param name="accountId">Id of the account to be closed.</param>
        void CloseAccount(string accountId);

        /// <summary>
        /// Deposit some cash into an account.
        /// </summary>
        /// <param name="accountId">Id of the account.</param>
        /// <param name="value">Value of the deposit.</param>
        void Deposit(string accountId, decimal value);

        /// <summary>
        /// Withdraw some cash from the account.
        /// </summary>
        /// <param name="accountId">Id of the account.</param>
        /// <param name="value">Value of the withdraw.</param>
        void Withdraw(string accountId, decimal value);
    }
}
