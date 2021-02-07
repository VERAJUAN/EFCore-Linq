using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.Database.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class TagConfig
    {
        public TagConfig(EntityTypeBuilder<Tag> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.Nombre)                
                .HasMaxLength(10).IsRequired();
            entityTypeBuilder.HasIndex(u => u.Nombre)
                .IsUnique();
        }
    }
}
