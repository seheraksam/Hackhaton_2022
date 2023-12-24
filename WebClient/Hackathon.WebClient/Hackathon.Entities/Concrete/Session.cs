using Hackathon.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Entities.Concrete
{
    public class Session:EntityBase
    {
        public User? User { get; set; }
        public string? UserId { get; set; }
        public DateTime? LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }
        public IList<SessionRecord>? SessionRecord { get; set; }
    }
}
