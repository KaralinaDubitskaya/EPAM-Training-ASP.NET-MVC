using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService.Accounts
{
    public class GoldAccount : BankAccount
    {
        #region Constants

        private const decimal MaxBalance = 1000000000;
        private const decimal MinBalance = -100000000;

        #endregion

        #region Constructor      

        /// <summary>
        /// Initializes a new instance of the <see cref="GoldAccount"/> class.
        /// </summary>
        /// <param name="holder">The account holder.</param>
        /// <param name="idGenerator">The identifier generator.</param>
        public GoldAccount(AccountHolder holder, IAccountIdGenerator idGenerator) : base(holder, idGenerator)
        {
        }

        #endregion

        #region Protected methods

        protected override void CountBonusPoints(decimal value)
        {
            this.BonusPoints = (this.Balance < 0) ? 0 : this.BonusPoints + (0.3M * value);
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
