using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.BLL.Service
{
    public interface ITransactionService
    {
        void InterUserTransaction(string sender, string recipient, int amount);
        void SystemTransaction(string userId, int amount);
    }
}
