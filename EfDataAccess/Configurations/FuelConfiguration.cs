using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.Property(f => f.Name).HasMaxLength(20).IsRequired();
            builder.HasIndex(f => f.Name).IsUnique();
            builder.Property(f => f.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
