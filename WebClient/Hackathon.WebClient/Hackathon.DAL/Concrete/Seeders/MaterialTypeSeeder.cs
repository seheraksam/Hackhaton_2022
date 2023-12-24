using Hackathon.DAL.Contexts;
using Hackathon.DAL.Interface;
using Hackathon.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hackathon.DAL.Concrete.Seeders
{
    public class MaterialTypeSeeder : IMaterialTypeSeeder
    {

        public MaterialTypeSeeder(
            HackathonDbContext dbContext
            )
        {
            DbContext = dbContext;
        }

        public HackathonDbContext DbContext { get; }

        public void Seed(IEnumerable<MaterialType> materialTypes)
        {
            ArgumentNullException.ThrowIfNull(DbContext.MaterialTypes);
            ArgumentNullException.ThrowIfNull(DbContext.Materials);
            if (DbContext.MaterialTypes.Any()) return;
            DbContext.AddRange(materialTypes);
            DbContext.SaveChanges();
        }
    }
}
