using Hackathon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.DAL.Concrete.Maps
{
    public class MaterialMap : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Ignore(x => x.CreateUserId);
            builder.Ignore(x => x.UpdateUserId);
            builder.Property(x => x.CreatedTime).IsRequired(false).HasDefaultValueSql("getdate()");
            builder.Property(x => x.UpdateTime).IsRequired(false).HasDefaultValueSql("getdate()");

            builder.Property(x=>x.Name).IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.MaterialTypeId).IsRequired();
            builder.Property(x=>x.Value).IsRequired();
            builder.Property(x=>x.ImagePath).IsRequired(false);

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
