using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Accounts
{
    public abstract class BankAccount
    {
        #region Fields

        private string _id;
        private AccountHolder _holder;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="AccHolder">The account holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        protected BankAccount(AccountHolder accHolder, IAccountIdGenerator idGenerator)
        {
            Holder = accHolder;
            Id = idGenerator.Generate();
        }

        #endregion

        #region Properties    
        
        /// <summary>
        /// Holder of the account.
        /// </summary>
        public AccountHolder Holder
        {
            get => _holder;
            protected set => _holder = value ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Unique identifier of the account.
        /// </summary>
        public string Id
        {
            get => _id;
            protected set => _id = value ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Balance of the account.
        /// </summary>
        public decimal Balance { get; protected set; }

        /// <summary>
        /// Bonus points of the account.
        /// </summary>
        public decimal BonusPoints { get; protected set; }

        /// <summary>
        /// Indicates wheather the account is active or closed.
        /// </summary>
        public bool IsActive { get; protected set; }

        #endregion

        #region Public methods

        /// <summary>
        /// Deposit some cash into the account.
        /// </summary>
        /// <param name="deposit">The deposit value.</param>
        /// <exception cref="ArgumentException">Thrown if invalid value of the deposit is given.</exception>
        public void Deposit(decimal deposit)
        {
            if (deposit <= 0)
            {
                throw new ArgumentException("Deposit value cannot be negative.");
            }

            ValidateDeposit(deposit);

            Balance += deposit;
            CountBonusPoints(deposit);
        }

        /// <summary>
        /// Withdraw some cash from the account.
        /// </summary>
        /// <param name="withdraw">The withdraw value.</param>
        /// <exception cref="ArgumentException">Thrown if invalid value of the withdraw is given.</exception>
        public void Withdraw(decimal withdraw)
        {
            if (withdraw <= 0)
            {
                throw new ArgumentException("Withdraw value cannot be negative.");
            }

            ValidateWithdraw(withdraw);

            Balance -= withdraw;
            CountBonusPoints(withdraw);
        }

        /// <summary>
        /// Returns a string that contains information about the account.
        /// </summary>
        /// <returns>A string that contains information about the account.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(
                "Bank account {0}. ID: {1}. Holder: {2} {3}. Balance: {4}. Bonus points: {5}.",
                this.GetType(), 
                Id, 
                Holder.FirstName, 
                Holder.LastName, 
                Balance, 
                BonusPoints);

            return sb.ToString();
        }

        #endregion

        #region Protected methods

        protected abstract void ValidateDeposit(decimal value);

        protected abstract void ValidateWithdraw(decimal value);

        protected abstract void CountBonusPoints(decimal value);

        #endregion
    }
}
