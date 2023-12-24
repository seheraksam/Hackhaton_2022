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
    internal class SessionMap : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Ignore(x => x.IsDeleted);
            builder.Ignore(x => x.CreateUserId);
            builder.Ignore(x => x.UpdateUserId);
            builder.Ignore(x => x.CreatedTime);
            builder.Ignore(x => x.UpdateTime);

            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.LoginTime).IsRequired();
            builder.Property(x=>x.LogoutTime).IsRequired().HasDefaultValueSql(null);

        }
    }
}
