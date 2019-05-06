using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankEntites.BLL.Entities;
using BankEntites.DAL.Entities;
using Ninject;

namespace BankEntites.BLL.Interfaces
{
    /// <summary>
    /// Interface that defines boundaries for a new bank storage service  
    /// </summary>
    public interface IService
    {
        string CreateNewAccount(IKernel kernel);
        void DeleteAccount(string id);
        string AccInfo(string id);
        void Deposit(string id, decimal amount);
        void Withdraw(string id, decimal amount);
        void SaveAccounts(string filename);
        void LoadAccounts(string filename);
    }
}
