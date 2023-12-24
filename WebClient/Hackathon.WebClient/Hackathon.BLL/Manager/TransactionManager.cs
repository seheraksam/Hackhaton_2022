using Hackathon.BLL.Service;
using Hackathon.DAL.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.BLL.Manager
{
    public class TransactionManager : ITransactionService
    {
        private readonly UserRepository _userRepository;
        public TransactionManager(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void InterUserTransaction(string senderTCKN, string recipientTCKN, int amount)
        {
            if (senderTCKN == recipientTCKN)
                return;
            var databaseTransaction = _userRepository.DbContext.Database.BeginTransaction();
            try
            {
                var sender=_userRepository.GetByTCKN(senderTCKN);
                if (sender != null && sender.Balance < amount)
                    return;

                var recipient=_userRepository.GetByTCKN(recipientTCKN);
                if (recipient !=null)
                {
                    sender.Balance -= amount;
                    recipient.Balance += amount;
                    _userRepository.DbContext.Update(sender);
                    _userRepository.DbContext.Update(recipient);
                    _userRepository.DbContext.SaveChanges();
                    databaseTransaction.Commit();
                }
                
            }
            catch (Exception)
            {
                databaseTransaction.Rollback();
            }
            finally
            {
                databaseTransaction.Dispose();
            }
        }

        public void SystemTransaction(string userId, int amount)
        {
            var databaseTransaction = _userRepository.DbContext.Database.BeginTransaction();
            try
            {
                var recipient = _userRepository.GetUserById(userId);

                recipient.Balance += amount;
                _userRepository.DbContext.Update(recipient);
                _userRepository.DbContext.SaveChanges();
                databaseTransaction.Commit();
            }
            catch (Exception)
            {
                databaseTransaction.Rollback();
            }
            finally
            {
                databaseTransaction.Dispose();
            }
        }
    }
}
