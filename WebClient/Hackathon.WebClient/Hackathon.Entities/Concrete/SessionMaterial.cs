using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Entities.Concrete
{
    public class SessionMaterial:EntityBase
    {
        public SessionRecord? Record { get; set; }
        public int RecordId { get; set; }
        public Material? Material { get; set; }
        public int Quantity { get; set; }
        public int  MaterialId { get; set; }
    }
}
