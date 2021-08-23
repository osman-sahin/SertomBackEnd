using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Infrastructure.Data.Entities;

namespace Infrastructure.Data
{
    public class MedyanaDbContext:DbContext
    {
        public MedyanaDbContext(DbContextOptions<MedyanaDbContext> options)
            : base(options)
        {
        }


        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // https://www.learnentityframeworkcore.com/configuration/fluent-api
            // modelBuilder.ApplyConfiguration(new CategoryConfiguration());   // Tekil hali, her model icin ayrı ayrı uygulanır.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  // tara ve configuration dosyalarını bul
        }
    }
}
