using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class PostConfig
    {
        public PostConfig(EntityTypeBuilder<Post> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            entityTypeBuilder.Property(x => x.Content).HasMaxLength(500).IsRequired();
        }
    }
}
