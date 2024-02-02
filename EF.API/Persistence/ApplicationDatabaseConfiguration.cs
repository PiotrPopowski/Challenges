using EF.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.API.Persistence
{
    public class ApplicationDatabaseConfiguration : 
        IEntityTypeConfiguration<Company>,
        IEntityTypeConfiguration<Driver>,
        IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Drivers).WithOne(x => x.Company);
            builder.HasMany(x => x.Vehicles);
        }

        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(x => x.Name);
        }

        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ComplexProperty(x => x.Registration);
        }
    }
}
