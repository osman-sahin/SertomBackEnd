using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class LogConfiguration
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Text)
                .IsRequired();

            builder.Property(e => e.Type)
                .IsRequired();

            builder.Property(e => e.Date)
               .IsRequired();
        }
    }
}
