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
    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).UseIdentityColumn();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Ignore(x => x.CreateUserId);
            builder.Ignore(x => x.UpdateUserId);
            builder.Property(x => x.CreatedTime).IsRequired(false).HasDefaultValueSql("getdate()");
            builder.Property(x => x.UpdateTime).IsRequired(false).HasDefaultValueSql("getdate()");



            builder.Property(x => x.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.IdentityNumber)
              .HasMaxLength(11)
              .IsRequired();
            builder.Property(x => x.BirthYear)
                .HasMaxLength(4).
                IsRequired();
            builder.HasIndex(x=>x.IdentityNumber).IsUnique();
        }
    }
}
