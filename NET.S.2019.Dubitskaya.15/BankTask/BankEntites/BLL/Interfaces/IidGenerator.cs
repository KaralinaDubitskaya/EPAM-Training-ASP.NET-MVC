using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEntites.BLL.Interfaces
{
    /// <summary>
    /// Interface that defines boundaries for a new id generator 
    /// </summary>
    public interface IidGenerator
    {
        string Generate();
    }
}
