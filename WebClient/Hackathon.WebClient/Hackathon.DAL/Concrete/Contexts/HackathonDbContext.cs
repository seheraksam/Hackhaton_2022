using Hackathon.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.DAL.Contexts
{
    public class HackathonDbContext:IdentityDbContext<User>
    {
        public HackathonDbContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(HackathonDbContext).Assembly);
            base.OnModelCreating(builder);
        }

        public DbSet<Material> Materials { get; set; } = default!;
        public DbSet<MaterialType> MaterialTypes { get; set; } = default!;
        public DbSet<Profile> Profiles { get; set; } = default!;
        public DbSet<Session> Sessions { get; set; } = default!;
        public DbSet<SessionMaterial> SessionMaterials { get; set; } = default!;
        public DbSet<SessionRecord> SessionRecords  { get; set; } = default!;

        public override int SaveChanges()
        {
            Extensions.ChangeTrackerExtensions.SetAuditProperties(ChangeTracker);
            return base.SaveChanges();
        }
     
    }
}
