using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankEntites.DAL.Entities;

namespace BankEntites.DAL.Interfaces
{
    /// <summary>
    /// Interface that defines boundaries for a new account storage 
    /// </summary>
    internal interface IRepository
    {
        void Add(Account acc);
        void Remove(string accId);
        Account GetAcc(string accId);
        void SaveAccounts(string name);
        void LoadAccounts(string name);
    }
}
