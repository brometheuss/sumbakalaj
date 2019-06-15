using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.HasMany(p => p.PostFeatures)
                .WithOne(pf => pf.Post)
                .HasForeignKey(pf => pf.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
