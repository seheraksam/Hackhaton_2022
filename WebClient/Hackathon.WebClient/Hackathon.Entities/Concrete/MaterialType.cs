using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Entities.Concrete
{
    public class MaterialType:EntityBase
    {
        public string? Name { get; set; }
        public IEnumerable<Material>? Materials { get; set; }
        public string? ImagePath { get; set; }
    }
}
