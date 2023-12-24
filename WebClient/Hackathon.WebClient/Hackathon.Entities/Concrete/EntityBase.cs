using Hackathon.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Entities.Concrete
{
    public class EntityBase:IEntityBase
    {
        public int Id { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string? CreateUserId { get; set; }
        public string? UpdateUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
