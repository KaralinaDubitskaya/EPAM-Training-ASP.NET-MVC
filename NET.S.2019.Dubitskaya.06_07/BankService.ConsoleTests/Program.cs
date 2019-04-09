using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountHolder holder = new AccountHolder("Caroline", "Dubitskaya");
            var storage = new BankService.Entities.BankAccountsStorage();
            var bankService = new BankService.Entities.BankService(storage);
            string id = bankService.OpenAccount(new IdGenerator(), holder, "Gold");
            bankService.Deposit(id, 600);
            bankService.Deposit(id, 10000);
            bankService.Withdraw(id, 9000);
            Console.WriteLine(storage.GetBankAccountById(id).ToString());
        }
    }
}
