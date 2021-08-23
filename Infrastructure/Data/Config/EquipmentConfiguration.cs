using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class EquipmentConfiguration
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(e => e.Quantity)
                .IsRequired();

            builder.Property(e => e.UnitPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(e => e.UtilizationRatio)
               .HasPrecision(4, 1)
               .IsRequired();

            builder.Property(e => e.CreationDate)
                .ValueGeneratedOnAdd()
                .IsRequired();

        }
    }
}
