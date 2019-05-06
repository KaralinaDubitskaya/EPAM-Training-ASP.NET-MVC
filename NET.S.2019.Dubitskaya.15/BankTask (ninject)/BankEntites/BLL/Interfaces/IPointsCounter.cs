using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEntites.BLL.Interfaces
{
    /// <summary>
    /// Interface that defines boundaries for a new points counter 
    /// </summary>
    public interface IPointsCounter
    {
        int CountPoints(decimal balance, decimal amount, int mult, int currPoints);
    }
}
