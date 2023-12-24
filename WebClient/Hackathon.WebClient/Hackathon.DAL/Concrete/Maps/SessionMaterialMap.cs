﻿using Hackathon.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.DAL.Concrete.Maps
{
    public class SessionMaterialMap : IEntityTypeConfiguration<SessionMaterial>
    {
        public void Configure(EntityTypeBuilder<SessionMaterial> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.IsDeleted).IsRequired();
            builder.Property(x=>x.CreateUserId).IsRequired();
            builder.Property(x=>x.CreatedTime).IsRequired();
            builder.Property(x=>x.Quantity).IsRequired();
        }
    }
}
