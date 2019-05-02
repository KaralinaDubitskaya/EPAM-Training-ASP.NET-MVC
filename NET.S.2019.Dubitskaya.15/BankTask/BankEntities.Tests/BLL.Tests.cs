using NUnit.Framework;
using System;
using BankEntites.BLL.Entities;
using BankEntites.BLL.Interfaces;
using BankEntites.BLL.Services;

namespace BankEntities.Tests
{
    [TestFixture]
    public class BLLTests
    {
        IService service = new AccountStorageService(StorageTypes.StorageWithList);

        [TestCase("Kirill", "Fidz", ExpectedResult = "Fidz")]
        [TestCase("Eugene", "Bas", ExpectedResult = "Bas")]
        [TestCase("Ivan", "Stas", ExpectedResult = "Stas")]
        public string AccountOwnerCreation_CorrectParams_ExpectedResult(string firstName, string lastName)
        {
            AccountOwner owner = new AccountOwner(firstName, lastName);
            return owner.LastName;
        }

        [TestCase("Kirill", "fidz")]
        [TestCase("Eugene", "")]
        [TestCase("Ivan", "St1244as")]
        public void AccountOwnerCreation_IncorrectParams_ExceptionThrown(string firstName, string lastName)
        {
            Assert.Throws<ArgumentException>(() => new AccountOwner(firstName, lastName));
        }

        [TestCase(18, ExpectedResult = true)]
        [TestCase(32, ExpectedResult = true)]
        [TestCase(33, ExpectedResult = false)]
        public bool IdGeneration_DifferentGenerators_ExpectedResult(int length)
        {
            IidGenerator gen;
            if (length < 20)
            {
                gen = new IdGeneratorIBAN();
            }
            else
            {
                gen = new IdGeneratorBIC();
            }

            return length == gen.Generate().Length;
        }

        [TestCase("")]
        [TestCase("123456")]
        [TestCase("1234561111111111111111111111111111111111111111111111111111111111111111111")]
        public void StorageService_IncorrectIdGiven_ThrowsException(string id)
        {
            Assert.Throws<ArgumentException>(() => service.DeleteAccount(id));
        }

        [TestCase(18, ExpectedResult = true)]
        [TestCase(32, ExpectedResult = true)]
        public bool StorageService_AccountsCreation_ExpectedResult(int length)
        {
            AccountOwner owner = new AccountOwner("Kirill", "Fidz");
            IidGenerator gen;
            IPointsCounter counter = new PointsCounter();
            if (length == 18)
            {
                gen = new IdGeneratorIBAN();
                return length == service.CreateNewAccount(AccountTypes.Basic, owner, gen, counter).Length;
            }
            else if (length == 32)
            {
                gen = new IdGeneratorBIC();
                return length == service.CreateNewAccount(AccountTypes.Basic, owner, gen, counter).Length;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        [TestCase("______\nName: Fidz Kirill\nId: tochange\nBalance: 1000\nPoints: 20\nType: BaseAccount", ExpectedResult = true)]
        public bool StorageService_WithdrawPointsCountInfoOutput_ExpectedResult(string info)
        {
            AccountOwner owner = new AccountOwner("Kirill", "Fidz");
            IidGenerator gen = new IdGeneratorBIC();
            IPointsCounter counter = new PointsCounter();
            string id = service.CreateNewAccount(AccountTypes.Basic, owner, gen, counter);
            service.Deposit(id, 1000);
            string result = info.Replace("tochange", id);

            return result == service.AccInfo(id);
        }

        [Test]
        public void StorageService_DeletingAccountTryingToGetDeletedInfo_ThrowsException()
        {
            AccountOwner owner = new AccountOwner("Ilya", "Priv");
            IidGenerator gen = new IdGeneratorBIC();
            IPointsCounter counter = new PointsCounter();
            string id = service.CreateNewAccount(AccountTypes.Basic, owner, gen, counter);
            service.DeleteAccount(id);

            Assert.Throws<NullReferenceException>(() => service.AccInfo(id));
        }

        [Test]
        public void StorageService_IncorrectWithdrawForAccType_ThrowsException()
        {
            AccountOwner owner = new AccountOwner("Ilya", "Priv");
            IidGenerator gen = new IdGeneratorBIC();
            IPointsCounter counter = new PointsCounter();
            string id = service.CreateNewAccount(AccountTypes.Basic, owner, gen, counter); 

            Assert.Throws<ArgumentException>(() => service.Withdraw(id, 1000));
        }
    }
}
