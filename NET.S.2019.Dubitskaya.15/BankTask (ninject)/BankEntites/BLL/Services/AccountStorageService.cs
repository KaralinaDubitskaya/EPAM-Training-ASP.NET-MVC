using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankEntites.BLL.Interfaces;
using BankEntites.BLL.Entities;
using BankEntites.DAL.Interfaces;
using BankEntites.DAL.Entities;
using BankEntites.DAL.Repositories;
using Ninject;

namespace BankEntites.BLL.Services
{
    /// <summary>
    /// Provides abstracition and it's methods to work with the account storage
    /// </summary>
    public class AccountStorageService : IService
    {
        private IRepository currStorage;

        /// <summary>
        /// Initializes a new instance of the AccountStorageService class.
        /// </summary>
        /// <param name="repo"></param>
        /// <returns>instance</returns>
        public AccountStorageService(IRepository repo)
        {
            currStorage = repo;
        }

        /// <summary>
        /// Creates new account and adds it to the storage
        /// </summary>
        /// <param name="kern"></param>
        /// <returns>account's id</returns>
        public string CreateNewAccount(IKernel kern)
        {
            Account acc = kern.Get<Account>();
            currStorage.Add(acc);
                        
            return acc.Accid;
        }

        /// <summary>
        /// Checks if the id has a correct format
        /// </summary>
        /// <param name="id"></param>
        private static void CheckId(string id)
        {
            if (id == null)
                throw new ArgumentNullException();

            if (id.Length != 32 && id.Length != 18)
                throw new ArgumentException("Account id must be 32 or 18 characters");
        }

        /// <summary>
        /// Deletes account with given id from the storage
        /// </summary>
        /// <param name="accType"></param>
        public void DeleteAccount(string id)
        {
            CheckId(id);
            try
            {
                currStorage.Remove(id);
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Converts account with given id to it's string form
        /// </summary>
        /// <param name="id"></param>
        /// <returns>string</returns>
        public string AccInfo(string id)
        {
            CheckId(id);
            try
            {
                return currStorage.GetAcc(id).ToString();
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Provides deposit operation for account with given id and amount
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void Deposit(string id, decimal amount)
        {
            CheckId(id);
            try
            {
                currStorage.GetAcc(id).Deposit(amount);
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Provides withdraw operation for account with given id and amount
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public void Withdraw(string id, decimal amount)
        {
            CheckId(id);
            try
            {
                currStorage.GetAcc(id).Withdraw(amount);
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException();
            }
        }

        /// <summary>
        /// Saves the storage in file
        /// </summary>
        /// <param name="filename"></param>
        public void SaveAccounts(string filename)
        {
            currStorage.SaveAccounts(filename);
        }

        /// <summary>
        /// Loads the storage from file
        /// </summary>
        /// <param name="filename"></param>
        public void LoadAccounts(string filename)
        {
            currStorage.LoadAccounts(filename);
        }
    }
}
