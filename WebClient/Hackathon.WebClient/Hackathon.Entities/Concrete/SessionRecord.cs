using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Entities.Concrete
{
    public class SessionRecord:EntityBase
    {
        public Session? Session { get; set; }
        public int SessionId { get; set; }
        public IEnumerable<SessionMaterial>? SessionMaterials { get; set; } 
    }
}
