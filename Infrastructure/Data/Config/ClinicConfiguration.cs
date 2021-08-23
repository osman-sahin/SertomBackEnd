using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
    {
        public void Configure(EntityTypeBuilder<Clinic> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.Name)
                .IsRequired();

            builder.Property(c => c.CreationDate)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.HasMany(c => c.Equipments)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(e => e.ClinicId)
                .IsRequired();

        }
    }
}
