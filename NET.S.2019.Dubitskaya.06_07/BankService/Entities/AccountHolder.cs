using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankService
{
    public class AccountHolder
    {
        private string _firstName;
        private string _lastName;

        /// <summary>
        /// Initialize a new instance of the account holder class.
        /// </summary>
        /// <param name="firstName">First name of the account holder.</param>
        /// <param name="lastName">Last name of the account holder.</param>
        /// <exception cref="ArgumentNullException">An argument is null.</exception>
        /// <exception cref="ArgumentException">A name is empty, too long or contains invalid characters.</exception>
        public AccountHolder(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// First name of the account holder.
        /// </summary>
        public string FirstName
        {
            get => _firstName;

            private set
            {
                ValidateName(value);
                _firstName = value;
            }
        }

        /// <summary>
        /// Last name of the account holder.
        /// </summary>
        public string LastName
        {
            get => _lastName;

            private set
            {
                ValidateName(value);
                _lastName = value;
            }
        }

        // Validate name of the account holder.
        private void ValidateName(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException();
            }

            if (name == string.Empty)
            {
                throw new ArgumentException("Name cannot be empty");
            }

            if (name.Length > 30)
            {
                throw new ArgumentException("Name cannot be longer than 30 characters.");
            }

            if (name.All(c => char.IsLetter(c) || "- '".Contains(c)))
            {
                return;
            }
            else
            {
                throw new ArgumentException("Invalid characters.");
            }
        }
    }
}
