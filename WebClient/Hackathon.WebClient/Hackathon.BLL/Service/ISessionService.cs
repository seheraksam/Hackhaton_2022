using Hackathon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.BLL.Service
{
    public interface ISessionService
    {
        void StartSession(string userId);
        void EndSession(string userId);
        void AddSessionRecord(SessionRecord record, string userId);
        Session GetCurrentSession(string userId);
    }
}
