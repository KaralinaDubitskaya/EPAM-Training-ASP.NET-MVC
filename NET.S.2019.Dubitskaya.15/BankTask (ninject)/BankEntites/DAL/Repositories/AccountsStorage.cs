using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using BankEntites.DAL.Interfaces;
using BankEntites.DAL.Entities;

namespace BankEntites.DAL.Repositories
{
    /// <summary>
    /// Represents basic bank account storage abstraction and provides it's methods
    /// </summary>
    [Serializable]
    public class AccountsStorage : IRepository
    {
        private List<Account> accs;

        /// <summary>
        /// Initializes a new instance of the AccountsStorage class.
        /// </summary>
        /// <returns>instance</returns>
        public AccountsStorage()
        {
            accs = new List<Account>();
        }

        #region Instance methods for interface

        /// <summary>
        /// Adds account to the list
        /// </summary>
        /// <param name="acc"></param>
        public void Add(Account acc)
        {
            accs.Add(acc);
        }

        /// <summary>
        /// Removes account with given id from the list
        /// </summary>
        /// <param name="id"></param>
        public void Remove(string accId)
        {
            accs.Remove(GetAcc(accId));
        }

        /// <summary>
        /// Finds account in the list by given id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Account</returns>
        public Account GetAcc(string id)
        {
            if (id == null)
                throw new ArgumentNullException();

            if (id == string.Empty)
                throw new ArgumentException();

            if (accs.Count == 0)
                throw new ArgumentException("No accounts in storage");

            foreach (Account acc in accs)
            {
                if (acc.Accid == id)
                {
                    return acc;
                }
            }

            return null;
        }

        /// <summary>
        /// Converts byte array to the list of accounts
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>list</returns>
        public void LoadAccounts(string filename)
        {
            if (File.Exists(filename))
            {
                using (BinaryReader breader = new BinaryReader(File.Open(filename, FileMode.Open)))
                {
                    byte[] byteArr = breader.ReadBytes((int)breader.BaseStream.Length);
                    List<Account> loadedList = ByteArrayToList(byteArr);
                    if (loadedList != null)
                        RemoveExistingElements(loadedList);

                    accs.AddRange(loadedList);
                }
            }
        }

        /// <summary>
        /// Saves accounts from the list in file.
        /// </summary>
        /// <param name="filename"></param>
        public void SaveAccounts(string filename)
        {
            if (filename == null || filename.Length == 0)
                throw new ArgumentNullException();

            using (FileStream bwriter = new FileStream(filename, FileMode.Create))
            {
                byte[] byteArr = ListToByteArray(accs);
                bwriter.Write(byteArr, 0, byteArr.Length);
            }
        }

        #endregion
                        
        private static List<Account> ByteArrayToList(byte[] arr)
        {
            List<Account> dserList;
            using (MemoryStream memStream = new MemoryStream())
            {
                BinaryFormatter binForm = new BinaryFormatter();
                memStream.Write(arr, 0, arr.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                dserList = (List<Account>)binForm.Deserialize(memStream);

                return dserList;
            }
        }

        /// <summary>
        /// Converts the list of accounts to byte array
        /// </summary>
        /// <param name="list"></param>
        /// <returns>array of bytes</returns>
        private static byte[] ListToByteArray(List<Account> list)
        {
            BinaryFormatter binForm = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream())
            {
                binForm.Serialize(memStream, list);
                return memStream.ToArray();
            }
        }

        /// <summary>
        /// Removes accounts from the loaded list if they are already in the current list of accounts
        /// </summary>
        /// <param name="list"></param>
        private void RemoveExistingElements(List<Account> list)
        {
            foreach (Account oldAcc in accs)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (oldAcc.Accid == list[i].Accid)
                    {
                        list.Remove(list[i]);
                        i--;
                    }
                }
            }
        }
    }
}
