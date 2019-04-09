using BankService.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Interfaces
{
    public interface IBankAccountsStorage
    {
        /// <summary>
        /// Returns <see ref="BankAccount"/> object by it's id.
        /// </summary>
        /// <param name="id">Id of the account to be loaded.</param>
        /// <returns>Requested object.</returns>
        BankAccount GetBankAccountById(string id);

        /// <summary>
        /// Add a new <see ref="BankAccount"/> object.
        /// </summary>
        /// <param name="account">An account to be added.</param>
        void AddBankAccount(BankAccount account);

        /// <summary>
        /// Delete the <see ref="BankAccount"/> object.
        /// </summary>
        /// <param name="id">Id of the account to be deleted.</param>
        void DeleteBankAccount(string id);
    }
}
