using BankService.Accounts;
using BankService.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Entities
{
    public class BankAccountsStorage : IBankAccountsStorage
    {
        private List<BankAccount> accounts = new List<BankAccount>();

        #region Public methods

        /// <summary>
        /// Add a new <see ref="BankAccount"/> object.
        /// If it is already added, nothing will happen.
        /// </summary>
        /// <param name="account">An account to be added.</param>
        public void AddBankAccount(BankAccount account)
        {
            if (!accounts.Contains(account))
            {
                accounts.Add(account);
            }
        }

        /// <summary>
        /// Returns <see ref="BankAccount"/> object by it's id.
        /// </summary>
        /// <param name="id">Id of the account to be loaded.</param>
        /// <returns>Requested object. If it was not found, returns null.</returns>
        /// <exception cref="ArgumentNullException">Id is null.</exception>
        public BankAccount GetBankAccountById(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var account in accounts)
            {
                if (account?.Id == id)
                {
                    return account;
                }
            }

            return null;
        }

        /// <summary>
        /// Delete the <see ref="BankAccount"/> object.
        /// </summary>
        /// <param name="id">Id of the account to be deleted.</param>
        /// <exception cref="ArgumentNullException">Null account was sent</exception>
        public void DeleteBankAccount(string id)
        {
            BankAccount account = GetBankAccountById(id);
            accounts.Remove(account);
        }
        
        #endregion
    }
}
