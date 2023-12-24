using Hackathon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.DAL.Concrete.Maps
{
    public class MaterialTypeMap : IEntityTypeConfiguration<MaterialType>
    {
        public void Configure(EntityTypeBuilder<MaterialType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Ignore(x => x.CreateUserId);
            builder.Ignore(x => x.UpdateUserId);
            builder.Property(x => x.CreatedTime).IsRequired(false).HasDefaultValueSql("getdate()");
            builder.Property(x => x.UpdateTime).IsRequired(false).HasDefaultValueSql("getdate()");

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ImagePath).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
