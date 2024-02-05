using EF.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel;
using System.Text.Json;

namespace EF.API.Persistence
{
    public class ApplicationDatabaseConfiguration : 
        IEntityTypeConfiguration<Company>,
        IEntityTypeConfiguration<Driver>,
        IEntityTypeConfiguration<Vehicle>,
        IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Drivers).WithOne(x => x.Company);
            builder.HasMany(x => x.Vehicles).WithMany();
        }

        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Name);
            builder.OwnsMany(x => x.Licenses);
        }

        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ComplexProperty(x => x.Registration);
        }

        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Vehicle).WithMany();
            builder.HasOne(x => x.Driver).WithMany();
            builder.HasOne(x => x.Company).WithMany();
        }
    }
}
