using BankService.Accounts;
using BankService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Entities
{
    public class BankService : IBankService
    {
        private IBankAccountsStorage _storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankService"/> class.
        /// </summary>
        /// <param name="storage">Store the accounts.</param>
        /// <exception cref="ArgumentNullException">The argument is null.</exception>
        public BankService(IBankAccountsStorage storage)
        {
            if (storage == null)
            {
                throw new ArgumentNullException();
            }

            _storage = storage;
        }

        /// <summary>
        /// Open a new bank account.
        /// </summary>
        /// <param name="generator">Generates the account id.</param>
        /// <param name="holder">Holder of the account.</param>
        /// <param name="accountType">Type of the account.</param>
        /// <returns>Id of the created account.</returns>
        /// <exception cref="ArgumentNullException">Some argument is null.</exception>
        /// <exception cref="ArgumentException">The account type is not defined./exception>
        public string OpenAccount(IAccountIdGenerator generator, AccountHolder holder, string accountType)
        {
            if (generator == null || holder == null || accountType == null)
            {
                throw new ArgumentNullException();
            }

            BankAccount account = null;

            switch (accountType.ToLower())
            {
                case "base":
                    {
                        _storage?.AddBankAccount(account = new BaseAccount(holder, generator));
                        break;
                    }
                case "platinum":
                    {
                        _storage?.AddBankAccount(account = new PlatinumAccount(holder, generator));
                        break;
                    }
                case "gold":
                    {
                        _storage?.AddBankAccount(account = new GoldAccount(holder, generator));
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(nameof(accountType) + " is not defined.");
                    }
            }

            return account?.Id;
        }

        /// <summary>
        /// Close the account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <exception cref="ArgumentNullException">The argument is null.</exception>
        /// <exception cref="ArgumentException">The argument is empty.</exception>
        public void CloseAccount(string accountId)
        {
            if (accountId == null)
            {
                throw new ArgumentNullException();
            }

            if (accountId == string.Empty)
            {
                throw new ArgumentException();
            }

            _storage.DeleteBankAccount(accountId);
        }

        /// <summary>
        /// Deposits some money from the specidied account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="value">The deposit value.</param>
        public void Deposit(string accountId, decimal value) => _storage.GetBankAccountById(accountId).Deposit(value);

        /// <summary>
        /// Withdraws some money from the specidied account.
        /// </summary>
        /// <param name="accountId">The account identifier.</param>
        /// <param name="value">The withdraw value.</param>
        public void Withdraw(string accountId, decimal value) => _storage.GetBankAccountById(accountId).Withdraw(value);
    }
}
