using Hackathon.BLL.Service;
using Hackathon.DAL.Concrete.Repositories;
using Hackathon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.BLL.Manager
{
    public class SessionManager : ISessionService
    {
        private readonly SessionRepository _sessionRepository;
        public SessionManager(SessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public void AddSessionRecord(SessionRecord record, string userId)
        {
            var session = _sessionRepository.GetCurrentSession(userId);
            session.SessionRecord.Add(record);
            _sessionRepository.Update(session);
            _sessionRepository.SaveChanges();
        }

        public void EndSession(string userId)
        {
            var session = _sessionRepository.GetCurrentSession(userId);
            session.LogoutTime=DateTime.Now;
            _sessionRepository.Update(session);
            _sessionRepository.SaveChanges();
        }

        public Session GetCurrentSession(string userId)
        {
            return _sessionRepository.GetCurrentSession(userId);
        }

        public void StartSession(string userId)
        {
            Session session = new();
            session.LoginTime = DateTime.Now;
            session.UserId = userId;
            _sessionRepository.Add(session);
            _sessionRepository.SaveChanges();
        }
    }
}
