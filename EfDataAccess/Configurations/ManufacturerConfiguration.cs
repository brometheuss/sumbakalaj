using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
    {
        public void Configure(EntityTypeBuilder<Manufacturer> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(30).IsRequired();
            builder.HasIndex(m => m.Name).IsUnique();
            builder.Property(m => m.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
