using Application.Settings.UrlHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Application.Entities.EntityConfiguration
{
    public class ParentConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
          
            builder.ToTable("Parents");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(256);
           
        }
    }
}
