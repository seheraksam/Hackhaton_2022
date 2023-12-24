using Hackathon.DAL.Contexts;
using Hackathon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.DAL.Concrete.Repositories
{
    public class UserRepository 
    {
        public HackathonDbContext DbContext { get; }

        public UserRepository(HackathonDbContext dbContext) 
        {
            DbContext = dbContext;
        }

        public User GetUserById(string userId)
        {
            var user = DbContext.Users.Where(x=>x.Id==userId).Include(x=>x.Profile).FirstOrDefault();
            return user;
        }

        public User GetByTCKN(string tckn)
        {
            var user = DbContext.Users.Include(x => x.Profile).Where(x => x.Profile.IdentityNumber == tckn).FirstOrDefault();
            return user;
        }

    }
}
