using System;
using BankEntites.BLL.Entities;
using BankEntites.BLL.Interfaces;

namespace BankEntites.DAL.Entities
{
    /// <summary>
    /// Represents basis for bank account abstraction and provides it's methods
    /// </summary>
    [Serializable]
    public abstract class Account
    {
        protected string accId;
        protected AccountOwner owner;
        protected decimal balance;
        protected int bonusPoints;

        [NonSerialized]
        protected IPointsCounter pointsCounter;

        /// <summary>
        /// Initializes basis for a new instance of the Account class.
        /// </summary>
        /// <param name="accOwner"></param>
        /// <returns>instance</returns>
        protected Account(AccountOwner accOwner, IidGenerator idGenerator, IPointsCounter counter)
        {
            Owner = accOwner;
            accId = idGenerator.Generate();
            pointsCounter = counter;
        }

        #region Properties

        /// <summary>
        /// Represents access to owner field
        /// </summary>
        internal AccountOwner Owner
        {
            get
            {
                return owner;
            }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException();
                else
                    owner = value;
            }
        }

        /// <summary>
        /// Represents access to accId field
        /// </summary>
        internal string Accid
        {
            get
            {
                return accId;
            }
        }

        /// <summary>
        /// Represents access to balance field
        /// </summary>
        internal decimal Balance
        {
            get
            {
                return balance;
            }
        }

        /// <summary>
        /// Represents access to bonusPoints field
        /// </summary>
        internal int BonusPoints
        {
            get
            {
                return bonusPoints;
            }
        }
        #endregion

        /// <summary>
        /// Converts currect instance to string
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return string.Format("______\nName: {0} {1}\nId: {2}\nBalance: {3}\nPoints: {4}\nType: " + GetType().Name,
                owner.LastName, owner.FirstName, accId, balance, bonusPoints);
        }

        /// <summary>
        /// Adds amount to the account balance
        /// </summary>
        public void Deposit(decimal amount)
        {
            if (amount < (decimal)0.001)
                throw new ArgumentException("Can't perform deposit with this amount");

            ValidateDeposit(amount);
            balance += amount;
            UpdateBonusPoints(amount);
        }

        /// <summary>
        /// Subtacks amount from the account balance
        /// </summary>
        public void Withdraw(decimal amount)
        {
            if (amount < (decimal)0.001)
                throw new ArgumentException("Can't perform deposit with this amount");

            ValidateWithdraw(amount);
            balance -= amount;
            UpdateBonusPoints(amount);
        }

        /// <summary>
        /// Validates deposit operation for current account with given amount
        /// </summary>
        /// <param name="amount"></param>
        protected abstract void ValidateDeposit(decimal amount);

        /// <summary>
        /// Validates withdraw operation for current account with given amount
        /// </summary>
        /// <param name="amount"></param>
        protected abstract void ValidateWithdraw(decimal amount);

        /// <summary>
        /// Updates bonus points for current account with given amount
        /// </summary>
        /// <param name="amount"></param>
        protected abstract void UpdateBonusPoints(decimal amount);

        /// <summary>
        /// Counts transaction points
        /// </summary>
        /// <param name="bal"></param>
        /// <param name="amount"></param>
        /// <param name="mult"></param>
        /// <param name="currPoints"></param>
        /// <returns>int</returns>
        protected int CountPoint(decimal bal, decimal amount, int mult, int currPoints)
        {
            if (pointsCounter != null)
                return pointsCounter.CountPoints(bal, amount, mult, currPoints);
            else
            {
                if (balance < 0)
                    return 0;
                else
                {
                    return (currPoints += (int)amount / mult);
                }
            }
        }
    }
}
