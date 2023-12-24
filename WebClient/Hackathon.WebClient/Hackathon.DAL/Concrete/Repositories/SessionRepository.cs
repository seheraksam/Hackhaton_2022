using Hackathon.DAL.Contexts;
using Hackathon.DAL.Interface;
using Hackathon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.DAL.Concrete.Repositories
{
    public class SessionRepository:GenericRepository<Session>
    {

        public SessionRepository(HackathonDbContext dbContext) : base(dbContext)
        {
        }
        
        public void Add(Session session)
        {
            _table.Add(session);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Session> GetAll() => _table
                .Include(x => x.User)
                .ThenInclude(x => x.Profile)
                .Include(x => x.SessionRecord)
                .ThenInclude(x => x.SessionMaterials)
                .ThenInclude(x => x.Material)
                .AsSplitQuery()
                .AsNoTracking()
                .ToList();

        public IEnumerable<Session>GetByUserId(string userId)
        {
            return _table.Where(x =>x.UserId==userId).ToList();
        }

        public Session GetCurrentSession(string userId)
        {
            return _table.Include(x => x.SessionRecord).ThenInclude(x => x.SessionMaterials).Where(x => x.UserId == userId).OrderByDescending(x => x.LoginTime).FirstOrDefault();
        }
    }
}
