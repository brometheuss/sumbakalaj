using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class PostFeatureConfiguration : IEntityTypeConfiguration<PostFeature>
    {
        public void Configure(EntityTypeBuilder<PostFeature> builder)
        {
            builder.HasKey(pf => new
            {
                pf.PostId,
                pf.FeatureId
            });
        }
    }
}
