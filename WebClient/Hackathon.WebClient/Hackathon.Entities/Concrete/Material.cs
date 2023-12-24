using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Entities.Concrete
{
    public class Material:EntityBase
    {
        public string? Name { get; set; }
        public MaterialType? MaterialType { get; set; }
        public int MaterialTypeId { get; set; }
        public int Value { get; set; }
        public string? ImagePath { get; set; }
    }
}
