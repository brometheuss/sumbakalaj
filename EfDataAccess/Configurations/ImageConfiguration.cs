using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.Property(i => i.Alt).HasMaxLength(30).IsRequired();
            builder.Property(i => i.Path).HasMaxLength(50).IsRequired();
            builder.Property(i => i.Title).HasMaxLength(30).IsRequired();
            builder.Property(i => i.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
