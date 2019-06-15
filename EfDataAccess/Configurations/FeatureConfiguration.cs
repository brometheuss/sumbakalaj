using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.Property(f => f.Name).HasMaxLength(30).IsRequired();
            builder.HasIndex(f => f.Name).IsUnique();
            builder.Property(f => f.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasMany(f => f.PostFeatures)
                .WithOne(pf => pf.Feature)
                .HasForeignKey(pf => pf.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
