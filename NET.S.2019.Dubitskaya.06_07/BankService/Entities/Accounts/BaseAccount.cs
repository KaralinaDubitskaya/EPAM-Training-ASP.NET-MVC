﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Accounts
{
    public class BaseAccount : BankAccount
    {
        #region Constants

        private const decimal MaxBalance = 100000000;
        private const decimal MinBalance = -1000;

        #endregion

        #region Constructor      
        
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseAccount"/> class.
        /// </summary>
        /// <param name="holder">The account holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        public BaseAccount(AccountHolder holder, IAccountIdGenerator idGenerator) : base(holder, idGenerator)
        {
        }

        #endregion

        #region Protected methods

        protected override void CountBonusPoints(decimal value)
        {
            this.BonusPoints = (this.Balance < 0) ? 0 : this.BonusPoints + (0.005M * value);
        }

        protected override void ValidateWithdraw(decimal value)
        {
            if (this.Balance - value < MinBalance)
            {
                throw new ArgumentException($"The withdraw is too large, min balance value is {MinBalance}");
            }
        }

        protected override void ValidateDeposit(decimal value)
        {
            if (value + this.Balance > MaxBalance)
            {
                throw new ArgumentException($"The deposit is too large, max balance value is {MaxBalance}");
            }
        }

        #endregion
    }
}
