using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEntites.BLL.Entities
{
    /// <summary>
    /// Represents account owner abstraction
    /// </summary>
    [Serializable]
    public class AccountOwner
    {
        private string firstName;
        private string lastName;

        /// <summary>
        /// Represents access to firstName field
        /// </summary>
        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                ValidateName(value);
                firstName = value;
            }
        }

        /// <summary>
        /// Represents access to lastName field
        /// </summary>
        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                ValidateName(value);
                lastName = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the owner class.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>instance</returns>
        public AccountOwner(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// Checks if the name has a correct format
        /// </summary>
        /// <param name="name"></param>
        private void ValidateName(string name)
        {
            if (name == null)
                throw new ArgumentNullException();

            if (name == string.Empty)
                throw new ArgumentException("Name can't be empty");

            name = name.Trim();
            if (char.IsLower(name[0]))
                throw new ArgumentException("Name must start with capital letter");

            if (name.Length > 20)
                throw new ArgumentException("Name can't be that long");

            for (int i = 0; i < name.Length; i++)
            {
                if (!(char.IsLetter(name[i])) && name[i] != '-')
                    throw new ArgumentException("Unavailable characters in name");
            } 
        }

    }
}
