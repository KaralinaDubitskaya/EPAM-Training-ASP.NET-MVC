using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankEntites.BLL.Entities;

namespace BankEntites.BLL.Interfaces
{
    /// <summary>
    /// Avaliable account types
    /// </summary>
    public enum AccountTypes
    {
        Basic,
        Golden,
        Platinum
    }

    /// <summary>
    /// Avaliable storage types
    /// </summary>
    public enum StorageTypes
    {
        StorageWithList
    }

    /// <summary>
    /// Interface that defines boundaries for a new bank storage service  
    /// </summary>
    public interface IService
    {
        string CreateNewAccount(AccountTypes accType, AccountOwner owner, IidGenerator generator, IPointsCounter counter);
        void DeleteAccount(string id);
        string AccInfo(string id);
        void Deposit(string id, decimal amount);
        void Withdraw(string id, decimal amount);
        void SaveAccounts(string filename);
        void LoadAccounts(string filename);
    }
}
